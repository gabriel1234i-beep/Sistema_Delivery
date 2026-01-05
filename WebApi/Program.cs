using Aplication.Mapping;
using Aplication.UseCases;
using AutoMapper;
using Domain.Interfaces;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar la Conexión a SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContexts>(options =>
    options.UseSqlServer(connectionString));

// 2. Registrar Repositorios y UnitOfWork
// Cuando alguien pida IUnitOfWork, dale la clase UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// 3. Registrar Casos de Uso (UseCases)
builder.Services.AddScoped<CrearPedidoCompra>();
builder.Services.AddScoped<CrearPedidoEnvio>();

// 4. Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 5. Configurar Controladores y JSON
builder.Services.AddControllers().AddJsonOptions(x =>
{
    // Esto es vital para evitar errores de ciclos "Pedido -> Detalles -> Pedido"
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
