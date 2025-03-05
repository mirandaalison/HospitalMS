window.onload = function () {
    ListarPacientes();
};

let objPacientes;

async function ListarPacientes() {
    objPacientes = {
        url: "Pacientes/ListarPacientes",
        cabeceras: ["Id", "Nombre", "Apellido", "Fecha Nacimiento", "Teléfono", "Email", "Dirección"],
        propiedades: ["id", "nombre", "apellido", "fechaNacimiento", "telefono", "email", "direccion"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    }
    pintar(objPacientes);
}

function FiltrarPacientes() {
    let nombre = get("txtPacientes");
    if (nombre == "") {
        ListarPacientes();
    } else {
        objPacientes.url = "Pacientes/FiltrarPacientes/?nombre=" + nombre;
        pintar(objPacientes);
    }
}

function BuscarPacientes() {
    let forma = document.getElementById("frmBusquedaPacientes");

    let frm = new FormData(forma);

    fetchPost("Pacientes/FiltrarPacientes", "json", frm, function (res) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(res);
    })
}

function LimpiarPacientes() {
    LimpiarDatos("frmGuardarPacientes");
    ListarPacientes();
}

function LimpiarBusquedaPacientes() {
    LimpiarDatos("frmBusquedaPacientes");
    ListarPacientes();
}



function GuardarPacientes() {
    const modalContent = `
    <form id="frmGuardarPacientesModal" class="row g-3">
        <div class="col-md-6">
            <label for="nombreModal" class="form-label">Nombre</label>
            <input type="text" class="form-control" name="nombre" id="nombreModal" placeholder="Nombre del Paciente">
        </div>

        <div class="col-md-6">
            <label for="apellidoModal" class="form-label">Apellido</label>
            <input type="text" class="form-control" name="apellido" id="apellidoModal" placeholder="Apellido del Paciente">
        </div>

        <div class="col-md-6">
            <label for="fechaNacimientoModal" class="form-label">Fecha de Nacimiento</label>
            <input type="date" class="form-control" name="fechaNacimiento" id="fechaNacimientoModal" placeholder="Fecha de Nacimiento">
        </div>

        <div class="col-md-6">
            <label for="telefonoModal" class="form-label">Teléfono</label>
            <input type="tel" class="form-control" name="telefono" id="telefonoModal" placeholder="Número de Teléfono">
        </div>

        <div class="col-md-6">
            <label for="emailModal" class="form-label">Email</label>
            <input type="email" class="form-control" name="email" id="emailModal" placeholder="Correo Electrónico">
        </div>

        <div class="col-md-6">
            <label for="direccionModal" class="form-label">Dirección</label>
            <input type="text" class="form-control" name="direccion" id="direccionModal" placeholder="Dirección del Paciente">
        </div>
    </form>`;

    Swal.fire({
        title: 'Agregar Nuevo Paciente',
        html: modalContent,
        icon: 'info',
        showCancelButton: true,
        confirmButtonText: 'Guardar',
        cancelButtonText: 'Cancelar',
        preConfirm: () => {
            const form = document.getElementById('frmGuardarPacientesModal');
            const formData = new FormData(form);

            return fetch("Pacientes/GuardarPacientes", {
                method: 'POST',
                body: formData
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Error al guardar el paciente');
                    }
                    return response.text();
                })
                .catch(error => {
                    Swal.showValidationMessage(`Error: ${error}`);
                });
        }
    }).then((result) => {
        if (result.isConfirmed) {
            ListarPacientes();
            Swal.fire({
                title: 'Guardado',
                text: 'El Paciente ha sido agregado con éxito.',
                icon: 'success'
            });
        }
    });
}

function Editar(id) {
    fetchGet("Pacientes/RecuperarPacientes/?id=" + id, "json", function (data) {
        const modalContent = `
        <form id="frmEditarPacientesModal" class="row g-3">
            <input type="hidden" name="id" value="${data.id}">

            <div class="col-md-6">
                <label for="nombreModal" class="form-label">Nombre</label>
                <input type="text" class="form-control" name="nombre" id="nombreModal" value="${data.nombre}" placeholder="Nombre del Paciente">
            </div>

            <div class="col-md-6">
                <label for="apellidoModal" class="form-label">Apellido</label>
                <input type="text" class="form-control" name="apellido" id="apellidoModal" value="${data.apellido}" placeholder="Apellido del Paciente">
            </div>

            <div class="col-md-6">
                <label for="fechaNacimientoModal" class="form-label">Fecha de Nacimiento</label>
                <input type="date" class="form-control" name="fechaNacimiento" id="fechaNacimientoModal" value="${data.fechaNacimiento ? new Date(data.fechaNacimiento).toISOString().substring(0, 10) : ''}" placeholder="Fecha de Nacimiento">
            </div>

            <div class="col-md-6">
                <label for="telefonoModal" class="form-label">Teléfono</label>
                <input type="tel" class="form-control" name="telefono" id="telefonoModal" value="${data.telefono}" placeholder="Número de Teléfono">
            </div>

            <div class="col-md-6">
                <label for="emailModal" class="form-label">Email</label>
                <input type="email" class="form-control" name="email" id="emailModal" value="${data.email}" placeholder="Correo Electrónico">
            </div>

            <div class="col-md-6">
                <label for="direccionModal" class="form-label">Dirección</label>
                <input type="text" class="form-control" name="direccion" id="direccionModal" value="${data.direccion}" placeholder="Dirección del Paciente">
            </div>
        </form>`;

        Swal.fire({
            title: 'Editar Paciente',
            html: modalContent,
            icon: 'info',
            showCancelButton: true,
            confirmButtonText: 'Guardar Cambios',
            cancelButtonText: 'Cancelar',
            preConfirm: () => {
                const form = document.getElementById('frmEditarPacientesModal');
                const formData = new FormData(form);

                return fetch("Pacientes/GuardarCambiosPacientes", {
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
                ListarPacientes();
                Swal.fire({
                    title: 'Actualizado',
                    text: 'El Paciente ha sido modificado con éxito.',
                    icon: 'success'
                });
            }
        });
    });
}

function Eliminar(id) {
    showConfirmationModal({
        title: "¿Está seguro?",
        text: "¿Desea eliminar este Paciente?",
        icon: "warning",
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "Cancelar",
        onConfirm: function () {
            fetchGet("Pacientes/EliminarPacientes/?id=" + id, "text", function (res) {
                ListarPacientes();
                Swal.fire({
                    title: "Eliminado",
                    text: "El Paciente ha sido eliminado.",
                    icon: "success"
                });
            });
        },
        onCancel: function () {
            Swal.fire({
                title: "Cancelado",
                text: "El Paciente está seguro.",
                icon: "info"
            });
        }
    });
}