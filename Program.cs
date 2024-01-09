using BlazorCrud.Data;
using BlazorCrud.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configurar Conexion a MSSQLLocalDB
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConexionSQLLocalDB"))); //cadena de conex -> appsetting.json


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


//se agrega como inyeccion de dependencias el repositorio
builder.Services.AddScoped<IRepository, Repository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
