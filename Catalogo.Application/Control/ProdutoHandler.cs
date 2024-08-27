using Catalogo.Application.Commands;
using Catalogo.Dominio.Entidades;
using Catalogo.Service.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace Catalogo.Application.Control
{
    public class ProdutoHandler : IRequestHandler<AdicionarProduto, bool>,
                                    IRequestHandler<DeletarProduto, bool>,
                                    IRequestHandler<AtualizarDescricaoProduto, bool>,
                                    IRequestHandler<AtualizarAtivoProduto, bool>,
                                    IRequestHandler<AtualizarValorProduto, bool>,
                                    IRequestHandler<AtualizarQuantidadeEmEstoqueProduto, bool>,
                                    IRequestHandler<AtualizarProduto, bool>
    {
        // Injeções de dependência

        private readonly IMediator _mediator;
        private readonly IProdutoServices _produtoServices;

        public ProdutoHandler(IMediator mediator, IProdutoServices produtoServices)
        {
            _mediator = mediator;
            _produtoServices = produtoServices;
        }

        // Handles

        public async Task<bool> Handle(AdicionarProduto request, CancellationToken cancellationToken)
        {
            if (!ObterResultadoValidacao(request).IsValid) return false;

            return _produtoServices.Adicionar(ConverterParaProduto(request));
        }

        public Task<bool> Handle(DeletarProduto request, CancellationToken cancellationToken)
        {
            if (!ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            return Task.FromResult(_produtoServices.Deletar(request.Id));
        }

        public Task<bool> Handle(AtualizarDescricaoProduto request, CancellationToken cancellationToken)
        {
            if (!ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            return Task.FromResult(_produtoServices.AtualizarDescricaoProduto(request.Id, request.Descricao));
        }

        public Task<bool> Handle(AtualizarAtivoProduto request, CancellationToken cancellationToken)
        {
            if (!ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            return Task.FromResult(_produtoServices.AtualizarAtivoProduto(request.Id, request.Ativo));
        }

        public Task<bool> Handle(AtualizarValorProduto request, CancellationToken cancellationToken)
        {
            if (!ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            return Task.FromResult(_produtoServices.AtualizarValorProduto(request.Id, request.Valor));
        }

        public Task<bool> Handle(AtualizarQuantidadeEmEstoqueProduto request, CancellationToken cancellationToken)
        {
            if (!ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            return Task.FromResult(_produtoServices.AtualizarQuantidadeEmEstoque(request.Id, request.QuantidadeEmEstoque));
        }

        public Task<bool> Handle(AtualizarProduto request, CancellationToken cancellationToken)
        {
            if (!ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            return Task.FromResult(_produtoServices.AtualizarProduto(request.Id, request.Descricao, request.Ativo, request.Valor, request.QuantidadeEmEstoque));
        }

        // Conversões

        private Produto ConverterParaProduto(AdicionarProduto adicionarProduto)
        {
            return new Produto(
                                0,
                                0,
                                adicionarProduto.Nome,
                                adicionarProduto.Descricao,
                                adicionarProduto.Ativo,
                                adicionarProduto.Valor,
                                adicionarProduto.DataCadastro,
                                adicionarProduto.QuantidadeEstoque,
                                adicionarProduto.Altura,
                                adicionarProduto.Largura,
                                adicionarProduto.Profundidade,
                                new Categoria(adicionarProduto.Categoria.Id, adicionarProduto.Categoria.Nome)
                              );
        }

        //Validações

        public ValidationResult ObterResultadoValidacao(AdicionarProduto adicionarProduto)
        {
            return new ValidadorAdicionarProduto().Validate(adicionarProduto);
        }

        public ValidationResult ObterResultadoValidacao(DeletarProduto deletarProduto)
        {
            return new ValidadorDeletarProduto().Validate(deletarProduto);
        }

        public ValidationResult ObterResultadoValidacao(AtualizarDescricaoProduto atualizarDescricaoProduto)
        {
            return new ValidadorAtualizarDescricaoProduto().Validate(atualizarDescricaoProduto);
        }

        public ValidationResult ObterResultadoValidacao(AtualizarAtivoProduto atualizarAtivoProduto)
        {
            return new ValidadorAtualizarAtivoProduto().Validate(atualizarAtivoProduto);
        }

        public ValidationResult ObterResultadoValidacao(AtualizarValorProduto atualizarValorProduto)
        {
            return new ValidadorAtualizarValorProduto().Validate(atualizarValorProduto);
        }

        public ValidationResult ObterResultadoValidacao(AtualizarQuantidadeEmEstoqueProduto atualizarQuantidadeEmEstoqueProduto)
        {
            return new ValidadorAtualizarQuantidadeEmEstoqueProduto().Validate(atualizarQuantidadeEmEstoqueProduto);
        }

        public ValidationResult ObterResultadoValidacao(AtualizarProduto atualizarProduto)
        {
            return new ValidadorAtualizarProduto().Validate(atualizarProduto);
        }
    }
}
