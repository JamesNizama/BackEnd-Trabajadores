using BackEnd_Trabajadores.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ApplicationDbContext

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

builder.Services.AddScoped<BackEnd_Trabajadores.Service.DepartamentoService>();
builder.Services.AddScoped<BackEnd_Trabajadores.Service.DistritoService>();
builder.Services.AddScoped<BackEnd_Trabajadores.Service.ProvinciaService>();
builder.Services.AddScoped<BackEnd_Trabajadores.Service.TrabajadorService>();

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
