
using Cadastro.Dominio.Entidades;
using Cadastro.Service.Interfaces;
using Cadastro.Service.Repositorios;

namespace Cadastro.Service.Services
{
    public class ClienteService : IClienteService
    {
        private RepositorioCliente repositorioCliente = new RepositorioCliente();
        public bool Adicionar(Cliente cliente)
        {
            return repositorioCliente.Inserir(cliente) > 0;
        }

        public bool Deletar(long id)
        {
            var clienteParaDeletar = repositorioCliente.BuscarPorId(id);

            return repositorioCliente.Excluir(clienteParaDeletar);
        }

        public bool AtualizarNome(Int64 id, string nome)
        {
            return repositorioCliente.AtualizarNome(id, nome);
        }

        public Cliente ObterPorId(long id)
        {
            return repositorioCliente.BuscarPorId(id);
        }

        public List<Cliente> ObterTodos()
        {
            return repositorioCliente.BuscarClientes();
        }

        public bool ClienteExiste(Int64 id)
        {
            var resultado = repositorioCliente.BuscarPorId(id);

            if (resultado == null) return false;

            return resultado.Id > 0;
        }
    }
}
