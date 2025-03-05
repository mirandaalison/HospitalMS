window.onload = function () {
    ListarFacturas();
    CargarPacientes();
};

let objFacturacion;

function CargarPacientes() {
    fetchGet("Facturacion/ListarPacientesDropdown", "json", function (res) {
        let contenido = '<option value="">Seleccione un paciente</option>';

        res.forEach(function (paciente) {
            contenido += `<option value="${paciente.id}">${paciente.apellido}, ${paciente.nombre}</option>`;
        });

        document.getElementById("buscarPacienteId").innerHTML = contenido;
    });
}

async function ListarFacturas() {
    objFacturacion = {
        url: "Facturacion/ListarFacturas",
        cabeceras: ["Id", "Paciente", "Monto", "Método de Pago", "Fecha de Pago"],
        propiedades: ["id", "pacienteId", "monto", "metodoPago", "fechaPago"],
        editar: true,
        eliminar: false,
        propiedadId: "id"
    }
    pintar(objFacturacion);
}

function BuscarFacturas() {
    let forma = document.getElementById("frmBusquedaFacturas");
    let frm = new FormData(forma);

    fetchPost("Facturacion/FiltrarFacturas", "json", frm, function (res) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(res);
    })
}

function LimpiarBusquedaFacturas() {
    LimpiarDatos("frmBusquedaFacturas");
    ListarFacturas();
}

function VerResumenTratamientosPorPaciente() {
    fetchGet("Facturacion/ObtenerTotalTratamientosPorPaciente", "json", function (res) {
        if (res && res.length > 0) {
            let contenidoTabla = `
            <div class="table-responsive">
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>Paciente</th>
                            <th>Total Tratamientos</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>`;

            res.forEach(function (item) {
                let buttonState = '';
                let tooltipText = '';

                if (item.monto <= 0) {
                    buttonState = 'disabled';
                    tooltipText = 'No hay tratamientos para facturar';
                }

                contenidoTabla += `
                <tr>
                    <td>${item.apellidoPaciente}, ${item.nombrePaciente}</td>
                    <td>${item.monto.toFixed(2)}</td>
                    <td>
                        <button class="btn btn-primary btn-sm" ${buttonState} 
                            onclick="GenerarFactura(${item.pacienteId}, ${item.monto})"
                            title="${tooltipText}">
                            Generar Factura
                        </button>
                    </td>
                </tr>`;
            });

            contenidoTabla += `
                    </tbody>
                </table>
            </div>`;

            Swal.fire({
                title: 'Resumen de Tratamientos por Paciente',
                html: contenidoTabla,
                width: '800px',
                showConfirmButton: false,
                showCloseButton: true
            });
        } else {
            Swal.fire({
                title: 'Sin Datos',
                text: 'No hay pacientes registrados en el sistema.',
                icon: 'info'
            });
        }
    });
}

function GenerarFactura(pacienteId, monto) {
    if (monto <= 0) {
        Swal.fire({
            title: 'Error',
            text: 'No se puede generar una factura con monto cero. El paciente debe tener tratamientos registrados.',
            icon: 'error'
        });
        return;
    }

    Swal.fire({
        title: 'Método de Pago',
        input: 'select',
        inputOptions: {
            'Efectivo': 'Efectivo',
            'Tarjeta de crédito': 'Tarjeta de crédito',
            'Tarjeta de débito': 'Tarjeta de débito',
            'Transferencia': 'Transferencia'
        },
        inputPlaceholder: 'Seleccione un método de pago',
        showCancelButton: true,
        confirmButtonText: 'Generar',
        cancelButtonText: 'Cancelar',
        preConfirm: (metodoPago) => {
            if (!metodoPago) {
                Swal.showValidationMessage('Por favor seleccione un método de pago');
                return false;
            }

            const formData = new FormData();
            formData.append('pacienteId', pacienteId);
            formData.append('monto', monto);
            formData.append('metodoPago', metodoPago);
            formData.append('fechaPago', new Date().toISOString());

            return fetch("Facturacion/GuardarFactura", {
                method: 'POST',
                body: formData
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Error al generar la factura');
                    }
                    return response.text();
                })
                .catch(error => {
                    Swal.showValidationMessage(`Error: ${error}`);
                });
        }
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: 'Factura Generada',
                text: 'La factura ha sido generada correctamente.',
                icon: 'success'
            }).then(() => {
                ListarFacturas();
                Swal.close();
            });
        }
    });
}

function Editar(id) {
    fetchGet("Facturacion/ListarPacientesDropdown", "json", function (pacientes) {
        fetchGet("Facturacion/RecuperarFactura/?id=" + id, "json", function (data) {
            let optionsPacientes = '<option value="">Seleccione un paciente</option>';

            pacientes.forEach(function (paciente) {
                const selected = paciente.id === data.pacienteId ? 'selected' : '';
                optionsPacientes += `<option value="${paciente.id}" ${selected}>${paciente.apellido}, ${paciente.nombre}</option>`;
            });

            const modalContent = `
            <form id="frmEditarFacturaModal" class="row g-3">
                <input type="hidden" name="id" value="${data.id}">

                <div class="col-md-12">
                    <label for="pacienteIdModal" class="form-label">Paciente</label>
                    <select class="form-select" name="pacienteId" id="pacienteIdModal" required>
                        ${optionsPacientes}
                    </select>
                </div>

                <div class="col-md-6">
                    <label for="montoModal" class="form-label">Monto</label>
                    <input type="number" step="0.01" class="form-control" name="monto" id="montoModal" value="${data.monto}" placeholder="0.00" required>
                </div>

                <div class="col-md-6">
                    <label for="metodoPagoModal" class="form-label">Método de Pago</label>
                    <select class="form-select" name="metodoPago" id="metodoPagoModal" required>
                        <option value="">Seleccione un método</option>
                        <option value="Efectivo" ${data.metodoPago === 'Efectivo' ? 'selected' : ''}>Efectivo</option>
                        <option value="Tarjeta de crédito" ${data.metodoPago === 'Tarjeta de crédito' ? 'selected' : ''}>Tarjeta de crédito</option>
                        <option value="Tarjeta de débito" ${data.metodoPago === 'Tarjeta de débito' ? 'selected' : ''}>Tarjeta de débito</option>
                        <option value="Transferencia" ${data.metodoPago === 'Transferencia' ? 'selected' : ''}>Transferencia</option>
                    </select>
                </div>

                <div class="col-md-12">
                    <label for="fechaPagoModal" class="form-label">Fecha de Pago</label>
                    <input type="date" class="form-control" name="fechaPago" id="fechaPagoModal" value="${data.fechaPago ? new Date(data.fechaPago).toISOString().substring(0, 10) : ''}" required>
                </div>
            </form>`;

            Swal.fire({
                title: 'Editar Factura',
                html: modalContent,
                icon: 'info',
                showCancelButton: true,
                confirmButtonText: 'Guardar Cambios',
                cancelButtonText: 'Cancelar',
                preConfirm: () => {
                    const form = document.getElementById('frmEditarFacturaModal');
                    const formData = new FormData(form);

                    return fetch("Facturacion/GuardarCambiosFactura", {
                        method: 'POST',
                        body: formData
                    })
                        .then(response => {
                            if (!response.ok) {
                                throw new Error('Error al guardar los cambios');
                            }
                            return response.text();
                        })
                        .catch(error => {
                            Swal.showValidationMessage(`Error: ${error}`);
                        });
                }
            }).then((result) => {
                if (result.isConfirmed) {
                    ListarFacturas();
                    Swal.fire({
                        title: 'Actualizado',
                        text: 'La factura ha sido modificada con éxito.',
                        icon: 'success'
                    });
                }
            });
        });
    });
}