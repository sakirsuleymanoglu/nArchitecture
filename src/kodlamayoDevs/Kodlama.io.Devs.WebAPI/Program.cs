using Application;
using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application;
using Kodlama.io.Devs.Persistence;
using Kodlama.io.Devs.WebAPI.Enumerations;
using Kodlama.io.Devs.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSecurityServices();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(ConnectionStrings.Local.ConvertToString());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
