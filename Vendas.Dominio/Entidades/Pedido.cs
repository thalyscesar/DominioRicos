using System.Linq;

namespace Vendas.Dominio.Entidades
{
    public class Pedido
    {
        public Pedido()
        {

        }

        public Pedido(Int64 id, Int64 idCliente, DateTime dataCadastro, ClientePedido cliente, string codigo, decimal valorTotal)
        {
            Id = id;
            IdCliente = idCliente;
            DataCadastro = dataCadastro;
            Cliente = cliente;
            Status = Status.PENDENTE;
            Codigo = codigo;
            ValorTotal = valorTotal;
        }

        public Int64 Id { get; private set; }
        public Int64 IdCliente { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public ClientePedido Cliente { get; private set; }
        public Status Status { get; private set; }
        public string Codigo { get; private set; }

        public decimal CalcularValorTotalPedido(List<Item> itens)
        {
            this.ValorTotal = itens.Sum(i => i.ValorItem);

            return this.ValorTotal;
        }

        public void SetIdCliente(Int64 id)
        {
            this.IdCliente = id;
            this.Cliente = null;
        }

        public void SetValorTotal()
        {
            this.ValorTotal = 0;
        }
    }

    public enum Status
    {
        PENDENTE,
        CARREGANDO,
        PAGO,
        ENTREGUE
    }
}
