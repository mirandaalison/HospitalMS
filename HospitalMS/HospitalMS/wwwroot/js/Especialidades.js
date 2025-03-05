window.onload = function () {
    ListarEspecialidades();
};

let objEspecialidades;

async function ListarEspecialidades() {
    objEspecialidades = {
        url: "Especialidades/ListarEspecialidades",
        cabeceras: ["Id", "Nombre"],
        propiedades: ["id", "nombre"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    }
    pintar(objEspecialidades);
}

function FiltrarEspecialidades() {
    let nombre = get("txtEspecialidades");
    if (nombre == "") {
        ListarEspecialidades();
    } else {
        objEspecialidades.url = "Especialidades/FiltrarEspecialidades/?nombre=" + nombre;
        pintar(objEspecialidades);
    }
}

function BuscarEspecialidades() {
    let forma = document.getElementById("frmBusquedaEspecialidades");
    let frm = new FormData(forma);

    fetchPost("Especialidades/FiltrarEspecialidades", "json", frm, function (res) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(res);
    });
}

function LimpiarEspecialidades() {
    LimpiarDatos("frmGuardarEspecialidades");
    ListarEspecialidades();
}

function LimpiarBusquedaEspecialidades() {
    LimpiarDatos("frmBusquedaEspecialidades");
    ListarEspecialidades();
}

function GuardarEspecialidades() {
    const modalContent = `
    <form id="frmGuardarEspecialidadesModal" class="row g-3">
        <div class="col-md-12">
            <label for="nombreModal" class="form-label">Nombre</label>
            <input type="text" class="form-control" name="nombre" id="nombreModal" placeholder="Nombre de la Especialidad">
        </div>
    </form>`;

    Swal.fire({
        title: 'Agregar Nueva Especialidad',
        html: modalContent,
        icon: 'info',
        showCancelButton: true,
        confirmButtonText: 'Guardar',
        cancelButtonText: 'Cancelar',
        preConfirm: () => {
            const form = document.getElementById('frmGuardarEspecialidadesModal');
            const formData = new FormData(form);

            return fetch("Especialidades/GuardarEspecialidades", {
                method: 'POST',
                body: formData
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Error al guardar la especialidad');
                    }
                    return response.text();
                })
                .catch(error => {
                    Swal.showValidationMessage(`Error: ${error}`);
                });
        }
    }).then((result) => {
        if (result.isConfirmed) {
            ListarEspecialidades();
            Swal.fire({
                title: 'Guardado',
                text: 'La Especialidad ha sido agregada con éxito.',
                icon: 'success'
            });
        }
    });
}

function Editar(id) {
    fetchGet("Especialidades/RecuperarEspecialidades/?id=" + id, "json", function (data) {
        const modalContent = `
        <form id="frmEditarEspecialidadesModal" class="row g-3">
            <input type="hidden" name="id" value="${data.id}">
            <div class="col-md-12">
                <label for="nombreModal" class="form-label">Nombre</label>
                <input type="text" class="form-control" name="nombre" id="nombreModal" value="${data.nombre}" placeholder="Nombre de la Especialidad">
            </div>
        </form>`;

        Swal.fire({
            title: 'Editar Especialidad',
            html: modalContent,
            icon: 'info',
            showCancelButton: true,
            confirmButtonText: 'Guardar Cambios',
            cancelButtonText: 'Cancelar',
            preConfirm: () => {
                const form = document.getElementById('frmEditarEspecialidadesModal');
                const formData = new FormData(form);

                return fetch("Especialidades/GuardarCambiosEspecialidades", {
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
                ListarEspecialidades();
                Swal.fire({
                    title: 'Actualizado',
                    text: 'La Especialidad ha sido modificada con éxito.',
                    icon: 'success'
                });
            }
        });
    });
}

function Eliminar(id) {
    showConfirmationModal({
        title: "¿Está seguro?",
        text: "¿Desea eliminar esta Especialidad?",
        icon: "warning",
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "Cancelar",
        onConfirm: function () {
            fetchGet("Especialidades/EliminarEspecialidades/?id=" + id, "text", function (res) {
                ListarEspecialidades();
                Swal.fire({
                    title: "Eliminado",
                    text: "La Especialidad ha sido eliminada.",
                    icon: "success"
                });
            });
        },
        onCancel: function () {
            Swal.fire({
                title: "Cancelado",
                text: "La Especialidad está segura.",
                icon: "info"
            });
        }
    });
}
