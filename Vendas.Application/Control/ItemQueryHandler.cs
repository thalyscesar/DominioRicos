
using FluentValidation.Results;
using MediatR;
using Vendas.Application.Queries;
using Vendas.Dominio.Entidades;
using Vendas.Service.Interfaces;

namespace Vendas.Application.Control
{
    public class ItemQueryHandler : IRequestHandler<MostrarItemPorId, MostrarItem>,
                                    IRequestHandler<MostrarItemPorPedido, List<MostrarItem>>,
                                    IRequestHandler<MostrarItemPorPedidoEProduto, MostrarItem>
    {
        private readonly IItemServices _itemServices;

        public ItemQueryHandler(IItemServices itemServices)
        {
            _itemServices = itemServices;
        }

        public Task<MostrarItem> Handle(MostrarItemPorId request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(new MostrarItem());

            var itemBuscado = _itemServices.MostrarItemPorId(request.Id);

            return Task.FromResult(this.ConverterParaMostrarItem(itemBuscado));
        }

        public Task<List<MostrarItem>> Handle(MostrarItemPorPedido request, CancellationToken cancellationToken)
        {
            if(!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(new List<MostrarItem> { new MostrarItem() });

            List<MostrarItem> mostrarItens = new List<MostrarItem>();

            foreach(var item in _itemServices.MostrarItensPedido(request.IdPedido))
            {
                mostrarItens.Add(this.ConverterParaMostrarItem(item));
            }

            return Task.FromResult(mostrarItens);
        }

        public Task<MostrarItem> Handle(MostrarItemPorPedidoEProduto request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(new MostrarItem());

            var itemBuscado = _itemServices.MostrarItemPorPedidoEProduto(request.IdPedido, request.IdProduto);

            if (itemBuscado == null) return Task.FromResult(new MostrarItem());

            return Task.FromResult(this.ConverterParaMostrarItem(itemBuscado));
        }

        // Conversões
        private MostrarItem ConverterParaMostrarItem(Item item)
        {
            return new MostrarItem()
            {
                Id = item.Id,
                IdPedido = item.IdPedido,
                IdProduto = item.IdProduto,
                Quantidade = item.Quantidade,
                ValorItem = item.ValorItem
            };
        }

        public ValidationResult ObterResultadoValidacao(MostrarItemPorId mostrarItemPorId)
        {
            return new ValidadorMostrarItemPorId().Validate(mostrarItemPorId);
        }

        public ValidationResult ObterResultadoValidacao(MostrarItemPorPedido mostrarItemPorPedido)
        {
            return new ValidadorMostrarItemPorPedido().Validate(mostrarItemPorPedido);
        }

        public ValidationResult ObterResultadoValidacao(MostrarItemPorPedidoEProduto mostrarItemPorPedidoEProduto)
        {
            return new ValidadorMostrarItemPorPedidoEProduto().Validate(mostrarItemPorPedidoEProduto);
        }
    }
}
