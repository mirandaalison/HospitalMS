window.onload = function () {
    ListarCitas();
    CargarPacientesCombo();
    CargarMedicosCombo();
};

let objCitas;
let pacientesCombo = [];
let medicosCombo = [];

function CargarPacientesCombo() {
    fetchGet("Citas/ListarPacientesCombo", "json", function (res) {
        pacientesCombo = res;
        let contenido = '<option value="">-- Seleccione Paciente --</option>';
        for (let i = 0; i < res.length; i++) {
            contenido += `<option value="${res[i].id}">${res[i].nombre}</option>`;
        }
        document.getElementById("buscarPacienteId").innerHTML = contenido;
    });
}

function CargarMedicosCombo() {
    fetchGet("Citas/ListarMedicosCombo", "json", function (res) {
        medicosCombo = res;
        let contenido = '<option value="">-- Seleccione Médico --</option>';
        for (let i = 0; i < res.length; i++) {
            contenido += `<option value="${res[i].id}">${res[i].nombre}</option>`;
        }
        document.getElementById("buscarMedicoId").innerHTML = contenido;
    });
}

function ListarCitas() {
    fetchGet("Citas/ListarCitas", "json", function (res) {
        for (let i = 0; i < res.length; i++) {
            res[i].pacienteCompleto = res[i].nombrePaciente + " " + res[i].apellidoPaciente;
            res[i].medicoCompleto = res[i].nombreMedico + " " + res[i].apellidoMedico;

            if (res[i].fechaHora) {
                const fecha = new Date(res[i].fechaHora);
                res[i].fechaFormateada = fecha.toLocaleString();
            } else {
                res[i].fechaFormateada = '';
            }
        }

        objCitas = {
            url: "Citas/ListarCitas",
            cabeceras: ["ID", "Paciente", "Médico", "Especialidad", "Fecha y Hora", "Estado"],
            propiedades: ["id", "pacienteCompleto", "medicoCompleto", "especialidad", "fechaFormateada", "estado"],
            editar: true,
            eliminar: true,
            propiedadId: "id"
        }

        let contenido = "";
        contenido = "<div id='divContenedorTabla'>";
        contenido += generarTablaCitas(res);
        contenido += "</div>";
        document.getElementById("divTable").innerHTML = contenido;

        setTimeout(() => {
            if (typeof DataTable !== "undefined") {
                if (dataTable) {
                    dataTable.destroy();
                }
                try {
                    dataTable = new DataTable('#tablaData');
                } catch (error) {
                    console.error("Error al inicializar DataTables:", error);
                }
            }
        }, 300);
    });
}

function generarTablaCitas(res) {
    let contenido = "";
    let cabeceras = objCitas.cabeceras;

    contenido += "<table id='tablaData' class='table table-striped'>";
    contenido += "<thead>";
    contenido += "<tr>";

    for (let i = 0; i < cabeceras.length; i++) {
        contenido += "<th>" + cabeceras[i] + "</th>";
    }
    contenido += "<th>Operaciones</th>";
    contenido += "</tr>";
    contenido += "</thead>";

    contenido += "<tbody>";
    for (let i = 0; i < res.length; i++) {
        let obj = res[i];
        contenido += "<tr>";

        contenido += "<td>" + obj.id + "</td>";
        contenido += "<td>" + obj.nombrePaciente + " " + obj.apellidoPaciente + "</td>";
        contenido += "<td>" + obj.nombreMedico + " " + obj.apellidoMedico + "</td>";
        contenido += "<td>" + obj.especialidad + "</td>";

        let fechaFormateada = "";
        if (obj.fechaHora) {
            const fecha = new Date(obj.fechaHora);
            fechaFormateada = fecha.toLocaleString();
        }
        contenido += "<td>" + fechaFormateada + "</td>";

        contenido += "<td>" + obj.estado + "</td>";

        contenido += "<td>";
        contenido += `<i onclick="EditarCitas(${obj.id})" class="btn btn-primary"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
<path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
<path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z"/>
</svg> </i>`;

        contenido += `<i onclick="EliminarCitas(${obj.id})" class="btn btn-danger"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3-fill" viewBox="0 0 16 16">
<path d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5m-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5M4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06m6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528M8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5"/>
</svg> </i>`;

        contenido += "</td>";
        contenido += "</tr>";
    }
    contenido += "</tbody>";
    contenido += "</table>";

    return contenido;
}

function BuscarCitas() {
    let forma = document.getElementById("frmBusquedaCitas");
    let frm = new FormData(forma);
    fetchPost("Citas/FiltrarCitas", "json", frm, function (res) {

        for (let i = 0; i < res.length; i++) {
            res[i].pacienteCompleto = res[i].nombrePaciente + " " + res[i].apellidoPaciente;
            res[i].medicoCompleto = res[i].nombreMedico + " " + res[i].apellidoMedico;

            if (res[i].fechaHora) {
                const fecha = new Date(res[i].fechaHora);
                res[i].fechaFormateada = fecha.toLocaleString();
            } else {
                res[i].fechaFormateada = '';
            }
        }

        document.getElementById("divContenedorTabla").innerHTML = generarTablaCitas(res);
    });
}

function LimpiarCitas() {
    LimpiarDatos("frmGuardarCitas");
    ListarCitas();
}

function LimpiarBusquedaCitas() {
    LimpiarDatos("frmBusquedaCitas");
    ListarCitas();
}

function GuardarCitas() {
    const opcionesPacientes = pacientesCombo.map(p => `<option value="${p.id}">${p.nombre}</option>`).join('');
    const opcionesMedicos = medicosCombo.map(m => `<option value="${m.id}">${m.nombre}</option>`).join('');

    const modalContent = `
    <form id="frmGuardarCitasModal" class="row g-3">
        <div class="col-md-12">
            <label for="pacienteIdModal" class="form-label">Paciente</label>
            <select class="form-select" name="pacienteId" id="pacienteIdModal" required>
                <option value="">-- Seleccione Paciente --</option>${opcionesPacientes}
            </select>
        </div>
        <div class="col-md-12">
            <label for="medicoIdModal" class="form-label">Médico</label>
            <select class="form-select" name="medicoId" id="medicoIdModal" required>
                <option value="">-- Seleccione Médico --</option>${opcionesMedicos}
            </select>
        </div>
        <div class="col-md-12">
            <label for="fechaHoraModal" class="form-label">Fecha y Hora</label>
            <input type="datetime-local" class="form-control" name="fechaHora" id="fechaHoraModal" required>
        </div>
        <div class="col-md-12">
            <label for="estadoModal" class="form-label">Estado</label>
            <select class="form-select" name="estado" id="estadoModal" required>
                <option value="Pendiente">Pendiente</option>
                <option value="Confirmada">Confirmada</option>
                <option value="Cancelada">Cancelada</option>
                <option value="Atendida">Atendida</option>
            </select>
        </div>
    </form>`;

    Swal.fire({
        title: 'Programar Nueva Cita',
        html: modalContent,
        icon: 'info',
        showCancelButton: true,
        confirmButtonText: 'Guardar',
        cancelButtonText: 'Cancelar',
        didOpen: () => {
            const now = new Date();
            now.setHours(now.getHours() + 1);
            now.setMinutes(0);
            now.setSeconds(0);
            document.getElementById('fechaHoraModal').value = now.toISOString().slice(0, 16);
        },
        preConfirm: () => {
            const form = document.getElementById('frmGuardarCitasModal');
            const formData = new FormData(form);
            return fetch("Citas/GuardarCitas", {
                method: 'POST',
                body: formData
            }).then(response => response.text());
        }
    }).then((result) => {
        if (result.isConfirmed) {
            ListarCitas();
            Swal.fire({
                title: 'Guardado',
                text: 'La cita ha sido programada con éxito.',
                icon: 'success'
            });
        }
    });
}

function EditarCitas(id) {
    fetchGet("Citas/RecuperarCitas/?id=" + id, "json", function (data) {
        const opcionesPacientes = pacientesCombo.map(p => `<option value="${p.id}" ${p.id == data.pacienteId ? 'selected' : ''}>${p.nombre}</option>`).join('');
        const opcionesMedicos = medicosCombo.map(m => `<option value="${m.id}" ${m.id == data.medicoId ? 'selected' : ''}>${m.nombre}</option>`).join('');

        let fechaHoraValue = '';
        if (data.fechaHora) {
            const fecha = new Date(data.fechaHora);
            fechaHoraValue = fecha.toISOString().slice(0, 16);
        }

        const modalContent = `
        <form id="frmEditarCitasModal" class="row g-3">
            <input type="hidden" name="id" value="${data.id}">
            <div class="col-md-12">
                <label for="pacienteIdModal" class="form-label">Paciente</label>
                <select class="form-select" name="pacienteId" id="pacienteIdModal" required>
                    <option value="">-- Seleccione Paciente --</option>${opcionesPacientes}
                </select>
            </div>
            <div class="col-md-12">
                <label for="medicoIdModal" class="form-label">Médico</label>
                <select class="form-select" name="medicoId" id="medicoIdModal" required>
                    <option value="">-- Seleccione Médico --</option>${opcionesMedicos}
                </select>
            </div>
            <div class="col-md-12">
                <label for="fechaHoraModal" class="form-label">Fecha y Hora</label>
                <input type="datetime-local" class="form-control" name="fechaHora" id="fechaHoraModal" value="${fechaHoraValue}" required>
            </div>
            <div class="col-md-12">
                <label for="estadoModal" class="form-label">Estado</label>
                <select class="form-select" name="estado" id="estadoModal" required>
                    <option value="Pendiente" ${data.estado === 'Pendiente' ? 'selected' : ''}>Pendiente</option>
                    <option value="Confirmada" ${data.estado === 'Confirmada' ? 'selected' : ''}>Confirmada</option>
                    <option value="Cancelada" ${data.estado === 'Cancelada' ? 'selected' : ''}>Cancelada</option>
                    <option value="Atendida" ${data.estado === 'Atendida' ? 'selected' : ''}>Atendida</option>
                </select>
            </div>
        </form>`;

        Swal.fire({
            title: 'Editar Cita',
            html: modalContent,
            icon: 'info',
            showCancelButton: true,
            confirmButtonText: 'Guardar Cambios',
            cancelButtonText: 'Cancelar',
            preConfirm: () => {
                const form = document.getElementById('frmEditarCitasModal');
                const formData = new FormData(form);
                return fetch("Citas/GuardarCambiosCitas", {
                    method: 'POST',
                    body: formData
                }).then(response => response.text());
            }
        }).then((result) => {
            if (result.isConfirmed) {
                ListarCitas();
                Swal.fire({
                    title: 'Actualizado',
                    text: 'La cita ha sido modificada con éxito.',
                    icon: 'success'
                });
            }
        });
    });
}

function EliminarCitas(id) {
    showConfirmationModal({
        title: "¿Está seguro?",
        text: "¿Desea eliminar esta cita?",
        icon: "warning",
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "Cancelar",
        onConfirm: function () {
            fetchGet("Citas/EliminarCitas/?id=" + id, "text", function (res) {
                ListarCitas();
                Swal.fire({
                    title: "Eliminada",
                    text: "La cita ha sido eliminada.",
                    icon: "success"
                });
            });
        },
        onCancel: function () {
            Swal.fire({
                title: "Cancelado",
                text: "La cita está segura.",
                icon: "info"
            });
        }
    });
}