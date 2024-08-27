using System.Reflection;
using Cadastro.Application.Commands;
using Cadastro.Application.Controls;
using Cadastro.Application.Queries;
using Cadastro.Service.Interfaces;
using Cadastro.Service.Services;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Cliente
builder.Services.AddScoped<IRequestHandler<AdicionarCliente, bool>, ClienteHandler>();
builder.Services.AddScoped<IRequestHandler<DeletarCliente, bool>, ClienteHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarCliente, bool>, ClienteHandler>();
builder.Services.AddScoped<IRequestHandler<BuscarCliente, List<BuscarCliente>>, ClienteQueryHandler>();
builder.Services.AddScoped<IRequestHandler<BuscarClientePorId, BuscarCliente>, ClienteQueryHandler>();

// Services
builder.Services.AddScoped<IClienteService, ClienteService>();
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
