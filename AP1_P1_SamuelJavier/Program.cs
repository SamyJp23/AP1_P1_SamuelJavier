using AP1_P1_SamuelJavier.Components;
using AP1_P1_SamuelJavier.DAL;
using AP1_P1_SamuelJavier.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddBlazorBootstrap();

//Obteniendo el constructor
var ConStr = builder.Configuration.GetConnectionString("ConStr");

//Inyectando el contexto

 builder.Services.AddDbContext<Contexto>(Options => Options.UseSqlite(ConStr));

//Inyectamos el Sevicio

builder.Services.AddScoped<ArticulosServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
