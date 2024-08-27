
using Vendas.Dominio.Entidades;
using Vendas.Service.Interfaces;
using Vendas.Service.Repositorios;

namespace Vendas.Service.Services
{
    public class PedidoServices : IPedidoServices
    {
        private RepositorioPedido repositorioPedido = new RepositorioPedido();
        private RepositorioCliente repositorioCliente = new RepositorioCliente();

        public bool AdicionarPedido(Pedido pedido)
        {
            var verificaCliente = repositorioCliente.BuscarPorDocumento(pedido.Cliente.NumeroDocumento);
            var clienteInserido = 0;

            if (verificaCliente > 0)
            {
                clienteInserido = verificaCliente;
            }
            else
            {
                clienteInserido = (int)repositorioCliente.Inserir(pedido.Cliente);
            }

            pedido.SetIdCliente(clienteInserido);

            return repositorioPedido.Inserir(pedido) > 0;
        }

        public bool AtualizarStatusPedido(Int64 id ,Status status)
        {
            return repositorioPedido.AtualizarStatusPedido(id, status);
        }

        public List<Pedido> MostrarPedidoPorCliente(long idCliente)
        {
            return repositorioPedido.PedidoPorClienteExiste(idCliente);
        }

        public Pedido MostrarPedidoPorId(long id)
        {
            return repositorioPedido.BuscarPorId(id);
        }

        public bool PedidoIdExiste(Int64 id)
        {
            var resultadoPedidoId = repositorioPedido.BuscarPorId(id);

            if (resultadoPedidoId == null) return false;

            return  resultadoPedidoId.Id > 0;
        }

        public bool PedidoClienteExiste(Int64 id)
        {
            return repositorioPedido.PedidoPorClienteExiste(id).Count > 0;
        }
    }
}
