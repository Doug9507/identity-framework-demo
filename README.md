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
