
using Cadastro.Dominio.Entidades;
using Cadastro.Service.Maps;
using Catalogo.Service.Repositorios;
using Shared.Data;

namespace Cadastro.Service.Repositorios
{
    public class RepositorioCliente : RepositorioBase<Cliente, ClienteMap>
    {
        public List<Cliente> BuscarClientes()
        {
            string querySelect = String.Format("select id, nome, tipocliente, numerodocumento from cadastro.cliente;");

            return DBHelper<Cliente>.InstanciaNpgsql.GetQuery(querySelect);
        }

        public bool AtualizarNome(Int64 id, string nome)
        {
            var queryUpdate = $"UPDATE cadastro.cliente SET nome= '{nome}' WHERE id = {id};";

            return DBHelper<Cliente>.InstanciaNpgsql.Get(queryUpdate) != null;
        }
    }
}
