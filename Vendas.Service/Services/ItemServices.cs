
using Vendas.Dominio.Entidades;
using Vendas.Service.Interfaces;
using Vendas.Service.Repositorios;

namespace Vendas.Service.Services
{
    public class ItemServices : IItemServices
    {
        private RepositorioItem repositorioItem = new RepositorioItem();
        private RepositorioProduto repositorioProduto = new RepositorioProduto();
        private RepositorioPedido repositorioPedido = new RepositorioPedido();
        private RepositorioCliente repositorioCliente = new RepositorioCliente();

        public bool Adicionar(Item item)
        {
            // variáveis que armazenarão o id
            var clienteId = 0;
            var pedidoId = 0;
            var produtoId = 0;

            //inserção do cliente
            clienteId = this.Adicionar(item.Pedido.Cliente);

            item.Pedido.SetIdCliente(clienteId);

            // Inserção do pedido
            pedidoId = this.Adicionar(item.Pedido);

            item.SetIdPedido(pedidoId);

            // Inserção do produto
            produtoId = this.Adicionar(item.Produto);

            item.SetIdProduto(produtoId);

            // Conclusão do item
            item.CalcularValorDoItem(item.Quantidade, repositorioProduto.BuscarPorId(produtoId).Valor);

            var itemAdicionado = repositorioItem.Inserir(item) > 0;

            // Calculando o valor total do pedido
            var pedido = repositorioPedido.BuscarPorId(pedidoId);
            var valorTotalPedido = pedido.CalcularValorTotalPedido(repositorioItem.MostrarItensPorPedido(pedidoId));
            repositorioPedido.AtualizarValorTotal(pedidoId, valorTotalPedido);

            // Atualizando o estoque
            if (itemAdicionado) this.AtualizarEstoque(produtoId, item.Quantidade, true);

            return itemAdicionado;
        }

        public bool Adicionar(Int64 idPedido, Int64 idProduto, int quantidade)
        {

            // criação do item
            var produto = repositorioProduto.BuscarPorId(idProduto);
            var pedido = repositorioPedido.BuscarPorId(idPedido);
            Item item = new Item(0,pedido, produto, quantidade);
            item.SetIdProduto(produto.Id);
            item.SetIdPedido(pedido.Id);

            // Conclusão do item
            item.CalcularValorDoItem(item.Quantidade, repositorioProduto.BuscarPorId(produto.Id).Valor);

            var itemAdicionado = repositorioItem.Inserir(item) > 0;

            // Calculando o valor total do pedido
            var valorTotalPedido = pedido.CalcularValorTotalPedido(repositorioItem.MostrarItensPorPedido(pedido.Id));
            repositorioPedido.AtualizarValorTotal(pedido.Id, valorTotalPedido);

            // Atualizando o estoque
            if (itemAdicionado) this.AtualizarEstoque(produto.Id, item.Quantidade, true);

            return itemAdicionado;
        }

        public void AtualizarEstoque(Int64 id, int quantidade, bool tipo)
        {
            var produto = repositorioProduto.BuscarPorId(id);

            produto.AtualizarEstoque(quantidade, tipo);

            repositorioProduto.AtualizarEstoque(id, produto.QuantidadeEmEstoque);
        }

        public bool AtualizarQuantidadeItem(Int64 id, int quantidade)
        {
            // item antes da atualização
            var itemAtigo = repositorioItem.BuscarPorId(id);

            // atualização do item
            var itemAtualizado = repositorioItem.AtualizarQuantidadeItem(id, quantidade);
            // item com valor atualizado
            var buscarNovoItem = repositorioItem.BuscarPorId(id);
            // busca do produto para alteração do estoque
            var buscarProduto = repositorioProduto.BuscarPorId(buscarNovoItem.IdProduto);
            // calculo e atualização do valor do item
            buscarNovoItem.CalcularValorDoItem(quantidade, buscarProduto.Valor);
            repositorioItem.AtualizarValorItem(id, buscarNovoItem.ValorItem);

            // atualizando o estoque
            if (itemAtualizado)
            {
                var valor = quantidade - itemAtigo.Quantidade;
                if (itemAtigo.Quantidade < quantidade) 
                {
                    this.AtualizarEstoque(buscarProduto.Id, valor, true);
                }
                else
                {
                    this.AtualizarEstoque(buscarProduto.Id, valor, false);
                }
                
            }
            // retorno da operação
            return itemAtualizado;
        }

        public Item MostrarItemPorId(long id)
        {
            return repositorioItem.BuscarPorId(id);
        }

        public List<Item> MostrarItensPedido(long idPedido)
        {
            return repositorioItem.MostrarItensPorPedido(idPedido);
        }

        public Item MostrarItemPorPedidoEProduto(long idPedido, long idProduto)
        {
            var busca = repositorioItem.ItemPorPedidoEProduto(idPedido, idProduto);

            if(busca == null) return null;
            
            return busca;
        }

        public bool Remover(long id)
        {
            var item = repositorioItem.BuscarPorId(id);

            var itemDeletado = repositorioItem.Excluir(item);

            if (itemDeletado) this.AtualizarEstoque(item.IdProduto, item.Quantidade, false);

            return itemDeletado;
        }

        // validação de itens
        public bool ItemExiste(Int64 id)
        {
            var resultadoBusca = repositorioItem.BuscarPorId(id);

            if (resultadoBusca == null) return false;

            return resultadoBusca.Id > 0;
        }

        public bool ItemPedidoExiste(Int64 idPedido)
        {
            var resultadoBusca = repositorioItem.MostrarItensPorPedido(idPedido);

            if(resultadoBusca.Count == 0) return false;

            return resultadoBusca.Count > 0;
        }

        public bool ProdutoExiste(Int64 id)
        {
            var resultadoBusca = repositorioItem.ProdutoExiste(id);

            return resultadoBusca;
        }

        public bool ProdutoCadastrado(Int64 id)
        {
            return repositorioProduto.ProdutoExiste(id);
        }

        public bool PedidoExiste(Int64 id)
        {
            var resultadoBusca = repositorioItem.PedidoExiste(id);

            return resultadoBusca;
        }


        // inserção das entidades complementares ao item
        public int Adicionar(ClientePedido cliente)
        {
            var clienteAdicionado = repositorioCliente.BuscarPorDocumento(cliente.NumeroDocumento);

            if (clienteAdicionado > 0)
            {
                return clienteAdicionado;
            }
            else
            {
                return (int)repositorioCliente.Inserir(cliente);
            }
        }

        public int Adicionar(Pedido pedido)
        {
            var pedidoAdicionado = repositorioPedido.PedidoPorCodigoExiste(pedido.Codigo); ;

            if (pedidoAdicionado > 0)
            {
                return (int)pedidoAdicionado;
            }
            else
            {
                return (int)repositorioPedido.Inserir(pedido);
            }
        }

        public int Adicionar(Produto produto)
        {
            var produtoAdicionado = repositorioProduto.ProdutoPorCodigoExiste(produto.Codigo);

            if (produtoAdicionado > 0)
            {
                return (int)produtoAdicionado;
            }
            else
            {
                return (int)repositorioProduto.Inserir(produto);
            }
        }
    }
}
