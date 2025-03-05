window.onload = function () {
    ListarMedicos();
};

let objMedicos;

async function ListarMedicos() {
    objMedicos = {
        url: "Medicos/ListarMedicos",
        cabeceras: ["Id", "Nombre", "Apellido", "Especialidad", "Teléfono", "Email"],
        propiedades: ["id", "nombre", "apellido", "especialidadId", "telefono", "email"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    }
    pintar(objMedicos);
}

function FiltrarMedicos() {
    let nombre = get("txtMedicos");
    if (nombre == "") {
        ListarMedicos();
    } else {
        objMedicos.url = "Medicos/FiltrarMedicos/?nombre=" + nombre;
        pintar(objMedicos);
    }
}

function BuscarMedicos() {
    let forma = document.getElementById("frmBusquedaMedicos");

    let frm = new FormData(forma);

    fetchPost("Medicos/FiltrarMedicos", "json", frm, function (res) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(res);
    })
}

function LimpiarMedicos() {
    LimpiarDatos("frmGuardarMedicos");
    ListarMedicos();
}

function LimpiarBusquedaMedicos() {
    LimpiarDatos("frmBusquedaMedicos");
    ListarMedicos();
}

function GuardarMedicos() {
    const modalContent = `
    <form id="frmGuardarMedicosModal" class="row g-3">
        <div class="col-md-6">
            <label for="nombreModal" class="form-label">Nombre</label>
            <input type="text" class="form-control" name="nombre" id="nombreModal" placeholder="Nombre del Médico">
        </div>

        <div class="col-md-6">
            <label for="apellidoModal" class="form-label">Apellido</label>
            <input type="text" class="form-control" name="apellido" id="apellidoModal" placeholder="Apellido del Médico">
        </div>

        <div class="col-md-6">
            <label for="especialidadIdModal" class="form-label">Especialidad ID</label>
            <input type="number" class="form-control" name="especialidadId" id="especialidadIdModal" placeholder="ID de Especialidad">
        </div>

        <div class="col-md-6">
            <label for="telefonoModal" class="form-label">Teléfono</label>
            <input type="tel" class="form-control" name="telefono" id="telefonoModal" placeholder="Número de Teléfono">
        </div>

        <div class="col-md-6">
            <label for="emailModal" class="form-label">Email</label>
            <input type="email" class="form-control" name="email" id="emailModal" placeholder="Correo Electrónico">
        </div>
    </form>`;

    Swal.fire({
        title: 'Agregar Nuevo Médico',
        html: modalContent,
        icon: 'info',
        showCancelButton: true,
        confirmButtonText: 'Guardar',
        cancelButtonText: 'Cancelar',
        preConfirm: () => {
            const form = document.getElementById('frmGuardarMedicosModal');
            const formData = new FormData(form);

            return fetch("Medicos/GuardarMedicos", {
                method: 'POST',
                body: formData
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Error al guardar el médico');
                    }
                    return response.text();
                })
                .catch(error => {
                    Swal.showValidationMessage(`Error: ${error}`);
                });
        }
    }).then((result) => {
        if (result.isConfirmed) {
            ListarMedicos();
            Swal.fire({
                title: 'Guardado',
                text: 'El Médico ha sido agregado con éxito.',
                icon: 'success'
            });
        }
    });
}

function Editar(id) {
    fetchGet("Medicos/RecuperarMedicos/?id=" + id, "json", function (data) {
        const modalContent = `
        <form id="frmEditarMedicosModal" class="row g-3">
            <input type="hidden" name="id" value="${data.id}">

            <div class="col-md-6">
                <label for="nombreModal" class="form-label">Nombre</label>
                <input type="text" class="form-control" name="nombre" id="nombreModal" value="${data.nombre}" placeholder="Nombre del Médico">
            </div>

            <div class="col-md-6">
                <label for="apellidoModal" class="form-label">Apellido</label>
                <input type="text" class="form-control" name="apellido" id="apellidoModal" value="${data.apellido}" placeholder="Apellido del Médico">
            </div>

            <div class="col-md-6">
                <label for="especialidadIdModal" class="form-label">Especialidad ID</label>
                <input type="number" class="form-control" name="especialidadId" id="especialidadIdModal" value="${data.especialidadId}" placeholder="ID de Especialidad">
            </div>

            <div class="col-md-6">
                <label for="telefonoModal" class="form-label">Teléfono</label>
                <input type="tel" class="form-control" name="telefono" id="telefonoModal" value="${data.telefono}" placeholder="Número de Teléfono">
            </div>

            <div class="col-md-6">
                <label for="emailModal" class="form-label">Email</label>
                <input type="email" class="form-control" name="email" id="emailModal" value="${data.email}" placeholder="Correo Electrónico">
            </div>
        </form>`;

        Swal.fire({
            title: 'Editar Médico',
            html: modalContent,
            icon: 'info',
            showCancelButton: true,
            confirmButtonText: 'Guardar Cambios',
            cancelButtonText: 'Cancelar',
            preConfirm: () => {
                const form = document.getElementById('frmEditarMedicosModal');
                const formData = new FormData(form);

                return fetch("Medicos/GuardarCambiosMedicos", {
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
                ListarMedicos();
                Swal.fire({
                    title: 'Actualizado',
                    text: 'El Médico ha sido modificado con éxito.',
                    icon: 'success'
                });
            }
        });
    });
}

function Eliminar(id) {
    showConfirmationModal({
        title: "¿Está seguro?",
        text: "¿Desea eliminar este Médico?",
        icon: "warning",
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "Cancelar",
        onConfirm: function () {
            fetchGet("Medicos/EliminarMedicos/?id=" + id, "text", function (res) {
                ListarMedicos();
                Swal.fire({
                    title: "Eliminado",
                    text: "El Médico ha sido eliminado.",
                    icon: "success"
                });
            });
        },
        onCancel: function () {
            Swal.fire({
                title: "Cancelado",
                text: "El Médico está seguro.",
                icon: "info"
            });
        }
    });
}