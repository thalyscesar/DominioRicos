
namespace Vendas.Dominio.Entidades
{
    public class Item
    {
        public Item()
        {

        }

        public Item(Int64 id, Pedido pedido , Produto produto, int quantidade)
        {
            Id = id;
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
        }

        public Int64 Id { get; private set; }
        public Pedido Pedido{ get; private set; }
        public Int64 IdPedido { get; private set; }
        public Produto Produto { get; private set; }
        public Int64 IdProduto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorItem { get; private set; } //{ get => ValorItem; set{ this.ValorItem = this.Quantidade * this.Produto.Valor; } }


        public void CalcularValorDoItem(int quantidade, decimal valor)
        {
            this.ValorItem = (decimal)quantidade * valor;
        }

        public void SetIdPedido(Int64 idPedido)
        {
            this.IdPedido = idPedido;
            this.Pedido = null;
        }

        public void SetIdProduto(Int64 idProduto)
        {
            this.IdProduto = idProduto;
            this.Produto = null;
        }

        public void SetValorItem()
        {
            this.ValorItem = 0;
        }
    }
}
