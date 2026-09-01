using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

// 1. Inicializar el builder
var builder = WebApplication.CreateBuilder(args);

// 2. Agregar los controladores de tu API
builder.Services.AddControllers();

// Configurar Swagger (Servicios)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Configurar DbContext (Conexión a tu SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 4. Configurar Inyección del Repositorio Genérico
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// 5. Configurar MediatR apuntando a la capa Application
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

// 6. Construir la aplicación (Nada de builder.Services puede ir después de esta línea)
var app = builder.Build();

// Habilitar la interfaz visual de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 7. Mapear los endpoints y arrancar
app.MapControllers();
app.Run();