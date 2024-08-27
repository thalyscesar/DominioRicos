using Catalogo.Application.Queries;
using Catalogo.Service.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace Catalogo.Application.Control
{
    public class ProdutoQueryHandler : IRequestHandler<BuscarProduto, List<BuscarProduto>>, IRequestHandler<BuscarProdutoId, BuscarProduto>
    {
        private readonly IMediator _mediator;
        private readonly IProdutoServices _produtoServices;

        public ProdutoQueryHandler(IMediator mediator, IProdutoServices produtoServices)
        {
            _mediator = mediator;
            _produtoServices = produtoServices;
        }

        public Task<List<BuscarProduto>> Handle(BuscarProduto request, CancellationToken cancellationToken)
        {
            List<BuscarProduto> list = new List<BuscarProduto>();

            foreach (var produto in _produtoServices.ObterTodos())
            {
                list.Add(ConverterParaBuscarProduto(produto));
            }

            return Task.FromResult(list);
        }

        public Task<BuscarProduto> Handle(BuscarProdutoId request, CancellationToken cancellationToken)
        {
            if (!ObterResultadoValidacao(request).IsValid) return Task.FromResult(new BuscarProduto() { Id = 0 });
            return Task.FromResult(ConverterParaBuscarProduto(_produtoServices.ObterPorId(request.Id)));
        }

        private BuscarProduto ConverterParaBuscarProduto(Dominio.Entidades.Produto produto)
        {
            return new BuscarProduto()
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Ativo = produto.Ativo,
                Valor = produto.Valor,
                Altura = produto.Altura,
                Largura = produto.Largura,
                Profundidade = produto.Profundidade,
                Categoria = produto.Categoria
            };
        }

        public ValidationResult ObterResultadoValidacao(BuscarProdutoId buscarProdutoId)
        {
            return new ValidadorBuscarPorId().Validate(buscarProdutoId);
        }
    }
}
