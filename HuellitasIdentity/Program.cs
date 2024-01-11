using HuellitasIdentity.Areas.Identity.Data;
using HuellitasIdentity.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using QRCoder;

var builder = WebApplication.CreateBuilder(args);

//Identity configuration
var connectionString = builder.Configuration.GetConnectionString("RazorPagesPetAuthConnection");
builder.Services.AddDbContext<RazorPagesPetAuth>(options =>
    options.UseSqlServer(connectionString)); builder.Services.AddDbContext<RazorPagesPetAuth>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<RazorPagesPetUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<RazorPagesPetAuth>();

// Add services to the container.
builder.Services.AddRazorPages();

//Dependecies injection
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddSingleton(new QRCodeService(new QRCodeGenerator()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
//Identity configuration
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
