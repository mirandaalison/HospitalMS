window.onload = function () {
    ListarTratamientos();
};

let objTratamientos;

async function ListarTratamientos() {
    objTratamientos = {
        url: "Tratamientos/ListarTratamientos",
        cabeceras: ["Id", "Paciente Id", "Descripción", "Fecha", "Costo"],
        propiedades: ["id", "pacienteId", "descripcion", "fecha", "costo"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    }
    pintar(objTratamientos);
}

function FiltrarTratamientos() {
    let descripcion = get("txtTratamientos");
    if (descripcion == "") {
        ListarTratamientos();
    } else {
        objTratamientos.url = "Tratamientos/FiltrarTratamientos/?descripcion=" + descripcion;
        pintar(objTratamientos);
    }
}

function BuscarTratamientos() {
    let forma = document.getElementById("frmBusquedaTratamientos");
    let frm = new FormData(forma);

    fetchPost("Tratamientos/FiltrarTratamientos", "json", frm, function (res) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(res);
    })
}

function LimpiarTratamientos() {
    LimpiarDatos("frmGuardarTratamientos");
    ListarTratamientos();
}

function LimpiarBusquedaTratamientos() {
    LimpiarDatos("frmBusquedaTratamientos");
    ListarTratamientos();
}

function GuardarTratamientos() {
    const modalContent = `
    <form id="frmGuardarTratamientosModal" class="row g-3">
        <div class="col-md-6">
            <label for="pacienteIdModal" class="form-label">Paciente Id</label>
            <input type="number" class="form-control" name="pacienteId" id="pacienteIdModal" placeholder="Id del Paciente">
        </div>
        <div class="col-md-6">
            <label for="descripcionModal" class="form-label">Descripción</label>
            <input type="text" class="form-control" name="descripcion" id="descripcionModal" placeholder="Descripción del Tratamiento">
        </div>
        <div class="col-md-6">
            <label for="fechaModal" class="form-label">Fecha</label>
            <input type="date" class="form-control" name="fecha" id="fechaModal" placeholder="Fecha del Tratamiento">
        </div>
        <div class="col-md-6">
            <label for="costoModal" class="form-label">Costo</label>
            <input type="number" step="0.01" class="form-control" name="costo" id="costoModal" placeholder="Costo del Tratamiento">
        </div>
    </form>`;

    Swal.fire({
        title: 'Agregar Nuevo Tratamiento',
        html: modalContent,
        icon: 'info',
        showCancelButton: true,
        confirmButtonText: 'Guardar',
        cancelButtonText: 'Cancelar',
        preConfirm: () => {
            const form = document.getElementById('frmGuardarTratamientosModal');
            const formData = new FormData(form);

            return fetch("Tratamientos/GuardarTratamientos", {
                method: 'POST',
                body: formData
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Error al guardar el tratamiento');
                    }
                    return response.text();
                })
                .catch(error => {
                    Swal.showValidationMessage(`Error: ${error}`);
                });
        }
    }).then((result) => {
        if (result.isConfirmed) {
            ListarTratamientos();
            Swal.fire({
                title: 'Guardado',
                text: 'El Tratamiento ha sido agregado con éxito.',
                icon: 'success'
            });
        }
    });
}

function Editar(id) {
    fetchGet("Tratamientos/RecuperarTratamientos/?id=" + id, "json", function (data) {
        const modalContent = `
        <form id="frmEditarTratamientosModal" class="row g-3">
            <input type="hidden" name="id" value="${data.id}">

            <div class="col-md-6">
                <label for="pacienteIdModal" class="form-label">Paciente Id</label>
                <input type="number" class="form-control" name="pacienteId" id="pacienteIdModal" value="${data.pacienteId}" placeholder="Id del Paciente">
            </div>

            <div class="col-md-6">
                <label for="descripcionModal" class="form-label">Descripción</label>
                <input type="text" class="form-control" name="descripcion" id="descripcionModal" value="${data.descripcion}" placeholder="Descripción del Tratamiento">
            </div>

            <div class="col-md-6">
                <label for="fechaModal" class="form-label">Fecha</label>
                <input type="date" class="form-control" name="fecha" id="fechaModal" value="${data.fecha ? new Date(data.fecha).toISOString().substring(0, 10) : ''}" placeholder="Fecha del Tratamiento">
            </div>

            <div class="col-md-6">
                <label for="costoModal" class="form-label">Costo</label>
                <input type="number" step="0.01" class="form-control" name="costo" id="costoModal" value="${data.costo}" placeholder="Costo del Tratamiento">
            </div>
        </form>`;

        Swal.fire({
            title: 'Editar Tratamiento',
            html: modalContent,
            icon: 'info',
            showCancelButton: true,
            confirmButtonText: 'Guardar Cambios',
            cancelButtonText: 'Cancelar',
            preConfirm: () => {
                const form = document.getElementById('frmEditarTratamientosModal');
                const formData = new FormData(form);

                return fetch("Tratamientos/GuardarCambiosTratamientos", {
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
                ListarTratamientos();
                Swal.fire({
                    title: 'Actualizado',
                    text: 'El Tratamiento ha sido modificado con éxito.',
                    icon: 'success'
                });
            }
        });
    });
}

function Eliminar(id) {
    showConfirmationModal({
        title: "¿Está seguro?",
        text: "¿Desea eliminar este Tratamiento?",
        icon: "warning",
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "Cancelar",
        onConfirm: function () {
            fetchGet("Tratamientos/EliminarTratamientos/?id=" + id, "text", function (res) {
                ListarTratamientos();
                Swal.fire({
                    title: "Eliminado",
                    text: "El Tratamiento ha sido eliminado.",
                    icon: "success"
                });
            });
        },
        onCancel: function () {
            Swal.fire({
                title: "Cancelado",
                text: "El Tratamiento está seguro.",
                icon: "info"
            });
        }
    });
}
