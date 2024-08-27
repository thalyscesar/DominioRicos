using System.Reflection;
using MediatR;
using Vendas.Application.Commands;
using Vendas.Application.Control;
using Vendas.Application.Queries;
using Vendas.Service.Interfaces;
using Vendas.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Pedido 
builder.Services.AddScoped<IRequestHandler<AdicionarPedido, bool>, PedidoHandler>();
builder.Services.AddScoped<IRequestHandler<MostrarPedidoPorId, MostrarPedido>, PedidoQueryHandler>();
builder.Services.AddScoped<IRequestHandler<MostrarPedidoPorCliente, List<MostrarPedido>>, PedidoQueryHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarStatusPedido, bool>, PedidoHandler>();

// Item
builder.Services.AddScoped<IRequestHandler<AdicionarItem, bool>, ItemHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarQuantidadeItem, bool>, ItemHandler>();
builder.Services.AddScoped<IRequestHandler<MostrarItemPorId, MostrarItem>, ItemQueryHandler>();
builder.Services.AddScoped<IRequestHandler<MostrarItemPorPedido, List<MostrarItem>>, ItemQueryHandler>();
builder.Services.AddScoped<IRequestHandler<DeletarItem, bool>, ItemHandler>();
builder.Services.AddScoped<IRequestHandler<MostrarItemPorPedidoEProduto, MostrarItem>, ItemQueryHandler>();
builder.Services.AddScoped<IRequestHandler<AdicionarItemAoPedido, bool>, ItemHandler>();
// Services
builder.Services.AddScoped<IPedidoServices, PedidoServices>();
builder.Services.AddScoped<IItemServices, ItemServices>();

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
