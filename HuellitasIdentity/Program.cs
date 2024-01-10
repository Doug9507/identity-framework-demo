using HuellitasIdentity.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

//Identity configuration
var connectionString = builder.Configuration.GetConnectionString("RazorPagesPetAuthConnection");
builder.Services.AddDbContext<RazorPagesPetAuth>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<RazorPagesPetAuth>();

// Add services to the container.
builder.Services.AddRazorPages();

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
