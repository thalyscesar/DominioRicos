using Cadastro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Service.Interfaces
{
    public interface IClienteService
    {
        bool Adicionar(Cliente cliente);
        bool Deletar(Int64 id);
        bool AtualizarNome(Int64 id, string nome);
        List<Cliente> ObterTodos();
        Cliente ObterPorId(Int64 id);
    }
}
