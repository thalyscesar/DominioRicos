using FluentValidation.Results;
using MediatR;
using Vendas.Application.Commands;
using Vendas.Dominio.Entidades;
using Vendas.Service.Interfaces;

namespace Vendas.Application.Control
{
    public class ItemHandler :  IRequestHandler<AdicionarItem, bool>,
                                IRequestHandler<AtualizarQuantidadeItem, bool>,
                                IRequestHandler<DeletarItem, bool>,
                                IRequestHandler<AdicionarItemAoPedido, bool>
    {
        private readonly IItemServices _itemServices;

        public ItemHandler(IItemServices itemServices)
        {
            _itemServices = itemServices;
        }

        // Handlers

        public Task<bool> Handle(AdicionarItem request, CancellationToken cancellationToken)
        {
            if(!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            if (!this.ObterResultadoValidacao(request.Pedido).IsValid) return Task.FromResult(false);

            if (!this.ObterResultadoValidacao(request.Pedido.Cliente).IsValid) return Task.FromResult(false);

            if (!this.ObterResultadoValidacao(request.Produto).IsValid) return Task.FromResult(false);

            var itemAdicionado = _itemServices.Adicionar(ConverterParaItem(request));

            return Task.FromResult(itemAdicionado);
        }

        public Task<bool> Handle(AtualizarQuantidadeItem request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            var itemAtualizado = _itemServices.AtualizarQuantidadeItem(request.Id, request.Quantidade);

            return Task.FromResult(itemAtualizado);
        }

        public Task<bool> Handle(DeletarItem request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            var itemDeletado = _itemServices.Remover(request.Id);

            return Task.FromResult(itemDeletado);
        }

        public Task<bool> Handle(AdicionarItemAoPedido request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            var itemAdicionado = _itemServices.Adicionar(request.IdPedido, request.IdProduto, request.Quantidade);

            return Task.FromResult(itemAdicionado);
        }

        // Conversões

        private Item ConverterParaItem(AdicionarItem adicionarItem)
        {
            ClientePedido cliente = new ClientePedido(0, 
                                                      adicionarItem.Pedido.Cliente.Nome, 
                                                      adicionarItem.Pedido.Cliente.NumeroDocumento);
                
            Pedido pedido = new Pedido(0, 
                                       0, 
                                       adicionarItem.Pedido.DataCadastro, 
                                       cliente, 
                                       adicionarItem.Pedido.Codigo,
                                       0);

            Produto produto = new Produto(0,
                                          adicionarItem.Produto.Nome,
                                          adicionarItem.Produto.QuantidadeEmEstoque,
                                          adicionarItem.Produto.Valor,
                                          adicionarItem.Produto.Codigo);

            Item item = new(
                0,
                pedido,
                produto,
                adicionarItem.Quantidade
                );

            return item; 
        } 

        //validações

        public ValidationResult ObterResultadoValidacao(AdicionarItem adicionarItem)
        {
            return new ValidadorAdicionarItem().Validate(adicionarItem);
        }

        private ValidationResult ObterResultadoValidacao(AdicionarPedido pedido)
        {
            return new ValidadorAdicionarPedido().Validate(pedido);
        }

        private ValidationResult ObterResultadoValidacao(AdicionarClientePedido clientePedido)
        {
            return new ValidadorAdicionarClientePedido().Validate(clientePedido);
        }

        private ValidationResult ObterResultadoValidacao(AdicionarProduto produto)
        {
            return new ValidadorAdicionarProduto().Validate(produto);
        }

        private ValidationResult ObterResultadoValidacao(AtualizarQuantidadeItem atualizar)
        {
            return new ValidadorAtualizarQuantidadeItem().Validate(atualizar);
        }

        private ValidationResult ObterResultadoValidacao(DeletarItem deletarItem)
        {
            return new ValidadorDeletarItem().Validate(deletarItem);
        }

        private ValidationResult ObterResultadoValidacao(AdicionarItemAoPedido adicionarItemAoPedido)
        {
            return new ValidadorAdicionarItemAoPedido().Validate(adicionarItemAoPedido);
        }
    }
}
