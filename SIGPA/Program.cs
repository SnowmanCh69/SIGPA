using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using SIGPA.Repositories;
using SIGPA.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region AppRepositories

builder.Services.AddScoped<IControlCalidadRepository, ControlCalidadRepository>();
builder.Services.AddScoped<IEstadoResiduosRepository, EstadoResiduosRepository>();
builder.Services.AddScoped<IEstadoRutaRepository, EstadoRutaRepository>();
builder.Services.AddScoped<ILogroRepository, LogroRepository>();

builder.Services.AddScoped<IRolUsuarioRepository, RolUsuarioRepository>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();


#endregion

#region AppServices

builder.Services.AddScoped<IControlCalidadService, ControlCalidadService>();
builder.Services.AddScoped<IEstadoResiduosService, EstadoResiduosService>();
builder.Services.AddScoped<IEstadoRutaService, EstadoRutaService>();
builder.Services.AddScoped<ILogroService, LogroService>();

builder.Services.AddScoped<IRolUsuarioService, RolUsuarioService>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
