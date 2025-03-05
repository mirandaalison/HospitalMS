# HospitalMS http://hospitalms.somee.com
Sistema de Gestión de una Base de Datos de un Hospital
Sistema completo para la Gestión Hospitalaria desarrollado en ASP.NET Core MVC con arquitectura por capas, modelo MVC (model - view - controller). Este proyecto permite administrar pacientes, médicos, citas médicas, tratamientos, especialidades y facturación.




## Descripción General
HospitalMS es un sistema diseñado para facilitar la administración de un hospital, permitiendo:
- Gestionar información de pacientes
- Administrar médicos y sus especialidades
- Programar citas médicas
- Registrar tratamientos
- Generar y consultar facturas




## Estructura del Proyecto
El proyecto sigue una arquitectura por capas, lo que mejora su mantenibilidad y escalabilidad. Cada capa tiene responsabilidades específicas:


### Capa Datos:
Contiene archivos responsables de la comunicación directa con la base de datos. En esta capa implementamos los procedimientos almacenados y consultas SQL, encapsulando toda la lógica de acceso a datos y manteniendo el resto del sistema aislado de los detalles de la base de datos.
- CadenaDAL.cs: Gestiona la conexión a la base de datos
      Maneja la cadena de conexión a la base HospitalDB
          Recupera la cadena de conexión desde el archivo de configuración appsettings.json.
          Crea un ConfigurationBuilder para leer archivos de configuración.
          Agrega el archivo appsettings.json desde el directorio actual de la aplicación.
          Construye la configuración y extrae la cadena de conexión identificada por la clave "cn".
       Sirve como clase base para todas las demás clases DAL (Data Access Layer), permitiéndoles heredar la propiedad cadena para conectarse a la base

- CitasDAL.cs: Maneja operaciones CRUD para las citas médicas
    Gestiona datos de citas médicas.
        Funciones: Listar, Filtrar, Guardar, Recuperar, Actualizar y Eliminar citas.
        Incluye métodos para obtener listas de pacientes y médicos para combos.
        Usa consultas SQL directas con JOINs entre tablas principales.
  
- EspecialidadesDAL.cs: Gestiona las especialidades médicas
  
- FacturacionDAL.cs: Acceso a datos para la facturación
  
- MedicosDAL.cs: Operaciones de base de datos para médicos
    Gestiona datos de médicos.
      Funciones: Listar, Filtrar, Guardar, Recuperar, Actualizar y Eliminar médicos.
      Combina procedimientos almacenados y consultas SQL directas.
      Maneja la relación con especialidades médicas.
  
- PacientesDAL.cs: Maneja la información de pacientes en la BD
    Gestiona datos de pacientes.
      Funciones: Listar, Filtrar, Guardar, Recuperar, Actualizar y Eliminar pacientes.
      Usa procedimientos almacenados para operaciones de consulta.
      Implementa manejo de excepciones y validación de nulos.
  
- TratamientosDAL.cs: Acceso a datos para tratamientos
  


## Capa Entidad:
Representa las entidades del sistema, puente entre la base de datos y la lógica de negocio. Estas clases contienen propiedades que mapean las columnas de las tablas en la base de datos.
- CitasCLS.cs: Modelo para citas médicas
    Modelo para citas médicas.
      Propiedades: ID, pacienteId, medicoId, fechaHora, estado.
      Incluye propiedades para información relacionada: nombres y apellidos del paciente y médico, y especialidad.
  
- EspecialidadesCLS.cs: Modelo para especialidades
  
- FacturacionCLS.cs: Modelo para facturas
  
- MedicosCLS.cs: Modelo para médicos
    Modelo para médicos.
      Propiedades básicas: id, nombre, apellido, especialidadId, telefono, email.
  
- PacientesCLS.cs: Modelo para pacientes
    Modelo para pacientes.
      Propiedades: id, nombre, apellido, fechaNacimiento, telefono, email, direccion.
  
- TratamientosCLS.cs: Modelo para tratamientos


## Capa Negocio:
Esta capa actúa como intermediaria entre la capa de presentación y la capa de datos, aplicando reglas de negocio, validaciones complejas y transformaciones de datos antes de pasarlos a la capa de datos o presentación.
- CitasBL.cs: Lógica de negocio para gestión de citas
    Maneja la lógica de negocio para citas médicas.
      Actúa como intermediario entre el controlador y la capa de datos.
      Métodos: ListarCitas, FiltrarCitas, GuardarCitas, RecuperarCitas, GuardarCambiosCitas, EliminarCitas.
      Incluye métodos auxiliares para obtener pacientes y médicos para listas desplegables.
  
- EspecialidadesBL.cs: Lógica para especialidades
  
- FacturacionBL.cs: Procesos de facturación
  
- MedicosBL.cs: Gestión de médicos
    Gestiona la lógica de negocio para médicos.
      Estructura similar a CitasBL, delegando todas las operaciones a MedicosDAL.
      Métodos: ListarMedicos, FiltrarMedicos, GuardarMedicos, RecuperarMedicos, GuardarCambiosMedicos, EliminarMedicos.
  
- PacientesBL.cs: Gestión de pacientes
    Gestiona la lógica de negocio para pacientes.
      Sigue el mismo patrón que las otras clases BL.
      Métodos: ListarPacientes, FiltrarPacientes, GuardarPacientes, RecuperarPacientes, GuardarCambiosPacientes, EliminarPacientes.
  
- TratamientosBL.cs: Lógica para tratamientos


## Capa Presentación:
Interactúa el usuario final:
### wwwroot
- Citas.js
      ListarCitas: Carga y muestra todas las citas en una tabla
      CargarPacientesCombo y CargarMedicosCombo: Pueblan los desplegables
      GuardarCitas: Crea una nueva cita mediante un modal
      EditarCitas: Permite modificar citas existentes
      EliminarCitas: Elimina citas con confirmación
      BuscarCitas: Filtra citas según criterios
      Usa SweetAlert2 para modales interactivos y DataTables para mejorar la visualización.

- Especialidades.js
  
- Facturacion.js
  
- generic.js
    Esta biblioteca sirve como base para todas las funcionalidades JavaScript del sistema.
      Gestión de formularios (get, set, LimpiarDatos)
      Comunicación con el servidor (fetchGet, fetchPost)
      Generación dinámica de tablas (pintar, generarTabla)
      Gestión de modales de confirmación con SweetAlert2
  
- Medicos.js
      ListarMedicos: Carga y muestra todos los médicos
      FiltrarMedicos y BuscarMedicos: Permiten buscar médicos
      GuardarMedicos: Crea un nuevo médico a través de modal
      EditarMedicos: Permite editar información de médicos existentes
      EliminarMedicos: Elimina médicos con confirmación
    
- Pacientes.js
      ListarPacientes: Carga y muestra todos los pacientes
      FiltrarPacientes y BuscarPacientes: Filtran pacientes
      GuardarPacientes: Registra nuevos pacientes
      EditarPacientes: Modifica información de pacientes existentes
      EliminarPacientes: Elimina pacientes con confirmación

- Tratamientos.js
  

### Controllers
Manejan las solicitudes HTTP
- CitasController.cs
    Implementa el patrón MVC utilizando la capa de negocio (CitasBL).
      Index(): Renderiza la vista principal de citas.
      ListarCitas(): Devuelve todas las citas en formato JSON.
      FiltrarCitas(CitasCLS): Filtra citas según criterios.
      GuardarCitas(CitasCLS), GuardarCambiosCitas(CitasCLS): Crean y actualizan citas.
      RecuperarCitas(int): Obtiene una cita específica para edición.
      EliminarCitas(int): Elimina citas por ID.
      ListarPacientesCombo(), ListarMedicosCombo(): Devuelven listas para controles desplegables.

- EspecialidadesController.cs
  
- FacturacionController.cs
  
- HomeController.cs
  
- MedicosController.cs
    A diferencia de CitasController, se conecta directamente a la capa de datos (MedicosDAL).
      Index(): Renderiza la vista principal de médicos.
      ListarMedicos(): Devuelve todos los médicos con depuración.
      FiltrarMedicos(MedicosCLS): Filtra médicos según criterios.
      GuardarMedicos(MedicosCLS), GuardarCambiosMedicos(MedicosCLS): Crean y actualizan médicos.
      RecuperarMedicos(int): Obtiene un médico específico.
      EliminarMedicos(int): Elimina médicos por ID.

- PacientesController.cs
    Similar a MedicosController, se conecta directamente a la capa de datos (PacientesDAL).
      Index(): Renderiza la vista principal de pacientes.
      ListarPacientes(): Devuelve todos los pacientes con depuración.
      FiltrarPacientes(PacientesCLS): Filtra pacientes según criterios.
      GuardarPacientes(PacientesCLS), GuardarCambiosPacientes(PacientesCLS): Crean y actualizan pacientes.
      RecuperarPacientes(int): Obtiene un paciente específico.
      EliminarPacientes(int): Elimina pacientes por ID.
  
- TratamientosController.cs
  
  
### Views
- Citas/Index.cshtml
      Botón para crear nuevas citas.
      Formulario de búsqueda con filtros por paciente, médico, fecha y estado.
      Área para la tabla de resultados (cargada dinámicamente por JS).
      Referencias a librerías externas (DataTables, SweetAlert2).
  
- Especialidades/Index.cshtml
  
- Facturacion/Index.cshtml
  
- Home/Index.cshtml
  
- Medicos/Index.cshtml
      Botón para agregar nuevos médicos.
      Formulario de búsqueda con filtros por nombre, apellido, especialidad, teléfono y email.
      Área para la tabla de resultados.

- Pacientes/Index.cshtml
      Botón para agregar nuevos pacientes.
      Formulario de búsqueda extenso con más campos (incluye dirección y fecha de nacimiento).
      Área para la tabla de resultados.
  
- Shared/_Layout.cshtml
    Plantilla maestra para todas las páginas de la aplicación.
      Sidebar lateral colapsable con menú de navegación.
      Iconos de Bootstrap para mejorar la interfaz.
      Sistema de diseño responsive.
      Áreas para renderizar contenido específico (@RenderBody).
      Sección para scripts (@RenderSectionAsync).
      Toggle para minimizar/expandir el menú lateral.
  
- Tratamientos/Index.cshtml
  

### appsettings.json
Configuración para logs (Info por defecto, Warning para ASP.NET)
Permite solicitudes desde cualquier host
Conexión a SQL Server: DESKTOP-DT5EATO\SQLEXPRESS, base HospitalDB, usuario sa


### Program.cs
Punto de entrada de la aplicación
Registra servicios MVC
Configura middleware: manejo de errores, HTTPS, archivos estáticos, rutas, autorización
Define ruta predeterminada: {controller=Home}/{action=Index}/{id?}
Inicia la aplicación
