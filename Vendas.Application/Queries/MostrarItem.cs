
namespace Vendas.Application.Queries
{
    public class MostrarItem
    {
        public Int64 Id { get; set; }
        public Int64 IdPedido { get; set; }
        public Int64 IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorItem { get; set; }
    }
}
