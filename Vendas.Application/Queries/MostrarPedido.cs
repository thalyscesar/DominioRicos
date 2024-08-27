using Vendas.Dominio.Entidades;

namespace Vendas.Application.Queries
{
    public class MostrarPedido
    {
        public Int64 Id { get; set; }
        public Int64 IdCliente { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataCadastro { get; set; }
        public Status Status { get; set; }
    }
}
