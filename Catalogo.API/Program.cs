using Catalogo.Application.Commands;
using Catalogo.Application.Control;
using Catalogo.Application.Queries;
using Catalogo.Service.Interfaces;
using Catalogo.Service.Services;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
// Produto
builder.Services.AddScoped<IRequestHandler<AdicionarProduto, bool>, ProdutoHandler>();
builder.Services.AddScoped<IRequestHandler<BuscarProduto, List<BuscarProduto>>, ProdutoQueryHandler>();
builder.Services.AddScoped<IRequestHandler<BuscarProdutoId, BuscarProduto>, ProdutoQueryHandler>();
builder.Services.AddScoped<IRequestHandler<DeletarProduto, bool>, ProdutoHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarDescricaoProduto, bool>, ProdutoHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarAtivoProduto, bool>, ProdutoHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarValorProduto, bool>, ProdutoHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarQuantidadeEmEstoqueProduto, bool>, ProdutoHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarProduto, bool>, ProdutoHandler>();
//Categoria
builder.Services.AddScoped<IRequestHandler<AtualizarCategoria, bool>, CategoriaHandler>();
builder.Services.AddScoped<IRequestHandler<BuscarCategoria, List<BuscarCategoria>>, CategoriaQueryHandler>();
builder.Services.AddScoped<IRequestHandler<BuscarCategoriaId, BuscarCategoria>, CategoriaQueryHandler>();
//Services
builder.Services.AddScoped<IProdutoServices, ProdutoServices>();
builder.Services.AddScoped<ICategoriaServices, CategoriaServices>();

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
