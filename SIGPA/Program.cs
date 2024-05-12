using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using SIGPA.Repositories;
using SIGPA.Services;
using System.Configuration;
using SIGPA.Models;
using SIGPA.Helpers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("DefaultConnection");



builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region AppRepositories

builder.Services.AddScoped<IControlCalidadRepository, ControlCalidadRepository>();
builder.Services.AddScoped<IEstadoResiduosRepository, EstadoResiduosRepository>();
builder.Services.AddScoped<IEstadoRutaRepository, EstadoRutaRepository>();
builder.Services.AddScoped<IMetodoControlRepository, MetodoControlRepository>();
builder.Services.AddScoped<INivelRepository, NivelRepository>();
builder.Services.AddScoped<IPartidaRepository, PartidaRepository>();
builder.Services.AddScoped<IRecolectaResiduosRepository, RecolectaResiduosRepository>();
builder.Services.AddScoped<IResiduosPartidaRepository, ResiduosPartidaRepository>();
builder.Services.AddScoped<IResiduosRepository, ResiduosRepository>();
builder.Services.AddScoped<IRolUsuarioRepository, RolUsuarioRepository>();
builder.Services.AddScoped<IRutaRecolectaRepository, RutaRecolectaRepository>();
builder.Services.AddScoped<ITipoVehiculoRepository, TipoVehiculoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();


#endregion

#region AppServices

builder.Services.AddScoped<IControlCalidadService, ControlCalidadService>();
builder.Services.AddScoped<IEstadoResiduosService, EstadoResiduosService>();
builder.Services.AddScoped<IEstadoRutaService, EstadoRutaService>();
builder.Services.AddScoped<IMetodoControlService, MetodoControlService>();
builder.Services.AddScoped<INivelService, NivelService>();
builder.Services.AddScoped<IPartidaService, PartidaService>();
builder.Services.AddScoped<IRecolectaResiduosService, RecolectaResiduosService>();
builder.Services.AddScoped<IResiduosPartidaService, ResiduosPartidaService>();
builder.Services.AddScoped<IResiduosService, ResiduosService>();
builder.Services.AddScoped<IRolUsuarioService, RolUsuarioService>();
builder.Services.AddScoped<IRutaRecolectaService, RutaRecolectaService>();
builder.Services.AddScoped<ITipoVehiculoService, TipoVehiculoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();


#endregion


// Authentication
builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddSwaggerGen(swagger =>
{
    // To Enable authorization using Swagger (JWT)
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}

        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcoGestor V1");
});


app.UseHttpsRedirection();



app.MapControllers();

// Redirect to the Swagger URL
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html");
    }
    else
    {
        await next();
    }
});

app.UseMiddleware<JwtMiddleware>();
app.UseAuthorization();

app.Run();
