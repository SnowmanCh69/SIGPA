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
builder.Services.AddScoped<IMetodoControlRepository, MetodoControlRepository>();
builder.Services.AddScoped<INivelRepository, NivelRepository>();
builder.Services.AddScoped<IPartidaLogroRepository, PartidaLogroRepository>();
builder.Services.AddScoped<IPartidaRepository, PartidaRepository>();
builder.Services.AddScoped<IRecolectaControlCalidadRepository, RecolectaControlCalidadRepository>();
builder.Services.AddScoped<IRecolectaResiduosRepository, RecolectaResiduosRepository>();
builder.Services.AddScoped<IResiduosPartidaRepository, ResiduosPartidaRepository>();
builder.Services.AddScoped<IResiduosRepository, ResiduosRepository>();
builder.Services.AddScoped<IResultadoRepository, ResultadoRepository>();
builder.Services.AddScoped<IRolUsuarioRepository, RolUsuarioRepository>();
builder.Services.AddScoped<IRutaRecolectaRepository, RutaRecolectaRepository>();
builder.Services.AddScoped<ITipoLogroRepository, TipoLogroRepository>();
builder.Services.AddScoped<ITipoVehiculoRepository, TipoVehiculoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();


#endregion

#region AppServices

builder.Services.AddScoped<IControlCalidadService, ControlCalidadService>();
builder.Services.AddScoped<IEstadoResiduosService, EstadoResiduosService>();
builder.Services.AddScoped<IEstadoRutaService, EstadoRutaService>();
builder.Services.AddScoped<ILogroService, LogroService>();
builder.Services.AddScoped<IMetodoControlService, MetodoControlService>();
builder.Services.AddScoped<INivelService, NivelService>();
builder.Services.AddScoped<IPartidaLogroService, PartidaLogroService>();
builder.Services.AddScoped<IPartidaService, PartidaService>();
builder.Services.AddScoped<IRecolectaControlCalidadService, RecolectaControlCalidadService>();
builder.Services.AddScoped<IRecolectaResiduosService, RecolectaResiduosService>();
builder.Services.AddScoped<IResiduosPartidaService, ResiduosPartidaService>();
builder.Services.AddScoped<IResiduosService, ResiduosService>();
builder.Services.AddScoped<IResultadoService, ResultadoService>();
builder.Services.AddScoped<IRolUsuarioService, RolUsuarioService>();
builder.Services.AddScoped<IRutaRecolectaService, RutaRecolectaService>();
builder.Services.AddScoped<ITipoLogroService, TipoLogroService>();
builder.Services.AddScoped<ITipoVehiculoService, TipoVehiculoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
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
