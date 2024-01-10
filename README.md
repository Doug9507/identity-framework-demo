# identity-framework-demo

Instale el proveedor de scaffolding de código ASP.NET Core:
dotnet tool install dotnet-aspnet-codegenerator --version 6.0.2 --global
(Se usa para agregar los componentes predeterminados de Identity al proyecto.)

Agregue los siguientes paquetes NuGet al proyecto:
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 6.0.2
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 6.0.3
dotnet add package Microsoft.AspNetCore.Identity.UI --version 6.0.3
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.3
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.3
(Estos paquetes instalan plantillas y dependencias de generación de código que usa el proveedor de scaffolding.)

Use el proveedor de scaffolding para agregar los componentes de Identity predeterminados al proyecto. Ejecute el siguiente comando en el terminal:
dotnet aspnet-codegenerator identity --useDefaultUI --dbContext RazorPagesPetAuth
(El generador identificado como identity se usa para agregar el marco de identidad al proyecto.
La opción --useDefaultUI indica que se usa una biblioteca de clases de Razor (RCL) que contiene los elementos predeterminados de la interfaz de usuario. Bootstrap se usa para aplicar estilo a los componentes.
La opción --dbContext especifica el nombre de una clase de contexto de base de datos de EF Core que se va a generar.)

# Actualizar la base de datos

Ejecute el siguiente comando para compilar la aplicación:
dotnet build

Instale la herramienta de migración de Entity Framework Core:
dotnet tool install dotnet-ef --version 6.0.3 --global
(Genera código denominado migración para crear y actualizar la base de datos que admite el modelo de entidad de Identity.
Ejecuta migraciones en una base de datos existente.
Se invoca a través de dotnet ef en este módulo.)

Cree y ejecute una migración de EF Core para actualizar la base de datos:
dotnet ef migrations add CreateIdentitySchema
dotnet ef database update

# Prueba de la funcionalidad de Identity
Tras un inicio de sesión correcto:

Se le redirigirá a la página principal.
El encabezado de la aplicación muestra Hola [dirección de correo electrónico] y un vínculo Cerrar sesión.
Se crea una cookie llamada .AspNetCore.Identity.Application. Identity conserva las sesiones de usuario con autenticación basada en cookies. Y después de haber cerrado la sesión correctamente, se elimina la cookie .AspNetCore.Identity.Application para finalizar la sesión de usuario.

# Extensión del modelo de datos de Identity (IdentityUser)
Contendra propiedades para almacenar el nombre y los apellidos del usuario.

# Personalización de la interfaz de usuario de Identity
Los componentes predeterminados de la interfaz de usuario de Identity se empaquetan en una biblioteca de clases Razor (RCL) de .NET Standard. Como se utiliza una biblioteca de clases Razor, al usar la interfaz de usuario predeterminada se agregan pocos archivos al proyecto.

Al personalizar la interfaz de usuario, primero debe volver a usar la herramienta aspnet-codegenerator para crear archivos que se usarán en lugar de la RCL. La herramienta permite seleccionar explícitamente qué archivos se crean. Se usan los componentes de la interfaz de usuario de la RCL si los archivos correspondientes no están presentes.

# Personalización de los datos de la cuenta de usuario
Agregue los archivos de registro del usuario que se van a modificar en el proyecto:
dotnet aspnet-codegenerator identity --dbContext RazorPagesPetAuth --files "Account.Manage.EnableAuthenticator;Account.Manage.Index;Account.Register;Account.ConfirmEmail" --userClass RazorPagesPetUser --force

En el comando anterior:
La opción --dbContext proporciona a la herramienta conocimientos de la clase derivada de DbContext existente llamada RazorPagesPizzaAuth.
La opción --files especifica una lista delimitada por signos de punto y coma de archivos únicos que se van a agregar al área de Identity.
La opción --userClass da como resultado la creación de una clase derivada de IdentityUser llamada RazorPagesPizzaUser.
La opción --force hace que se sobrescriban los archivos existentes en el área de Identity.

Se agrega o modifica la nueva clase que hara uso del IdentityUser, y el html _LoginPartial ya que escapa del scope de la carpeta areas en su creacioin/modificacion

# Actualización de la base de datos
Cree y aplique una migración de EF Core para actualizar el almacén de datos subyacente:
dotnet ef migrations add UpdateUser
dotnet ef database update

# Personalización del formulario de registro de usuarios
En Areas/Identity/Pages/Account/Register.cshtml, agregue los nuevos campos
En Areas/Identity/Pages/Account/Register.cshtml.cs, agregue compatibilidad para los cnuevos campos

# Personalización del formulario de administración de perfiles
Ha agregado los campos nuevos al formulario de registro de usuario, pero también debe agregarlos al formulario de administración de perfiles para que los usuarios existentes puedan editarlos.
En Areas/Identity/Pages/Account/Manage/Index.cshtml

# Configuración del remitente del correo electrónico de confirmación
Para enviar el correo electrónico de confirmación, debe crear una implementación de IEmailSender y registrarla en el sistema de inserción de dependencias. Para simplificar el proceso, la implementación no envía realmente correo electrónico a un servidor SMTP. Solo escribe el contenido del correo electrónico en la consola.



