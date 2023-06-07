using Incidencias.Server.Services;
using Incidencias.Server.Services.Interfaces;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IDiaTrabajoService, DiaTrabajoService>();
builder.Services.AddScoped<IOcurrenciaService, OcurrenciaService>();
builder.Services.AddScoped<ITipoOcurrenciaService, TipoOcurrenciaService>();
builder.Services.AddScoped<IEstadoService, EstadoService>();
builder.Services.AddScoped<EstadoService>();
builder.Services.AddScoped<TipoOcurrenciaService>();
builder.Services.AddScoped<DiaTrabajoService>();
builder.Services.AddScoped<OcurrenciaService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlite(connectionString);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
