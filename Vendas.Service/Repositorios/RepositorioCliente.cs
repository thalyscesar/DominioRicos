
using Vendas.Service.Maps;
using Vendas.Dominio.Entidades;
using Shared.Data;

namespace Vendas.Service.Repositorios
{
    public class RepositorioCliente : RepositorioBase<ClientePedido, ClienteMap>
    {
        public int BuscarPorDocumento(string numero)
        {
            var query = $"select * from vendas.cliente where numerodocumento = '{numero}';";

            return (int)DBHelper<ClientePedido>.InstanciaNpgsql.Get(query, null);
        }
    }
}
