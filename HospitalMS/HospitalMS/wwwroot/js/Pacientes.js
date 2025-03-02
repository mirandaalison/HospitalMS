window.onload = function () {
    ListarPacientes();
};

let objPacientes;



async function ListarPacientes() {
    objPacientes = {
        url: "Pacientes/ListarPacientes",
        cabeceras: ["Id", "Nombre", "Apellido", "FechaNacimiento", "Telefono", "Email", "Direccion"],
        propiedades: ["Id", "Nombre", "Apellido", "FechaNacimiento", "Telefono", "Email", "Direccion"],
        editar: true,
        eliminar: true,
        propiedadId: "Id"
    }
    pintar(objPacientes);
}



function FiltrarPacientes() {
    let Nombre = get("txtPacientes");
    if (Nombre == "") {
        ListarPacientes();
    } else {
        objPacientes.url = "Pacientes/FiltrarPacientes/?Nombre=" + Nombre;
        pintar(objPacientes);
    }

}



function BuscarPacientes() {
    let forma = document.getElementById("frmBusqueda");

    let frm = new FormData(forma);

    fetchPost("Pacientes/FiltrarPacientes", "json", frm, function (res) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(res);
    })
}



function LimpiarPacientes() {
    LimpiarDatos("frmGuardarPacientes");
    ListarPacientes();
}



function GuardarPacientes() {
    let forma = document.getElementById("frmGuardarPacientes");
    let frm = new FormData(forma);
    fetchPost("Pacientes/GuardarPacientes", "text", frm, function (res) {
        ListarPacientes();
        LimpiarDatos("frmGuardarPacientes");

    })
}



function EditarPacientes(Id) {
    fetchGet("Pacientes/RecuperarPacientes/?Id=" + Id, "json", function (data) {
        const modalContent = `

        <form Id="frmEditarPacientesModal" class="row g-3">
            <input type="hidden" name="Id" value="${data.Id}">

            <div class="col-md-6">
                <label for="NombreModal" class="form-label">Nombre</label>
                <input type="text" class="form-control" name="Nombre" Id="NombreModal" value="${data.Nombre}" placeholder="Nombre del Paciente">
            </div>

            <div class="col-md-6">
                <label for="ApellidoModal" class="form-label">Apellido</label>
                <input type="text" class="form-control" name="Apellido" Id="ApellidoModal" value="${data.Apellido}" placeholder="Apellido del Paciente">
            </div>

            <div class="col-md-6">
                <label for="FechaNacimientoModal" class="form-label">Fecha de Nacimiento</label>
                <input type="date" class="form-control" name="FechaNacimiento" Id="FechaNacimientoModal" value="${data.FechaNacimiento ? new Date(data.FechaNacimiento).toISOString().substring(0, 10) : ''}" placeholder="Fecha de Nacimiento">
            </div>

            <div class="col-md-6">
                <label for="TelefonoModal" class="form-label">Teléfono</label>
                <input type="tel" class="form-control" name="Telefono" Id="TelefonoModal" value="${data.Telefono}" placeholder="Número de Teléfono">
            </div>

            <div class="col-md-6">
                <label for="EmailModal" class="form-label">Email</label>
                <input type="email" class="form-control" name="Email" Id="EmailModal" value="${data.Email}" placeholder="Correo Electrónico">
            </div>

            <div class="col-md-6">
                <label for="DireccionModal" class="form-label">Dirección</label>
                <input type="text" class="form-control" name="Direccion" Id="DireccionModal" value="${data.Direccion}" placeholder="Dirección del Paciente">
            </div>

        </form>`;

        Swal.fire({
            title: 'Editar Pacientes',
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



function EliminarPacientes(Id) {
    showConfirmationModal({
        title: "¿Está seguro?",
        text: "¿Desea eliminar este Paciente?",
        icon: "warning",
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "Cancelar",
        onConfirm: function () {
            fetchGet("Pacientes/EliminarPacientes/?Id=" + Id, "text", function (res) {
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
