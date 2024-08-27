
namespace Cadastro.Dominio.Entidades
{
    public class Cliente
    {
        public Cliente()
        {

        }

        public Cliente(Int64 id, string? nome, TipoCliente tipoCliente, string? numeroDocumento)
        {
            Id = id;
            Nome = nome;
            TipoCliente = tipoCliente;
            NumeroDocumento = numeroDocumento;
        }
        public Int64 Id { get; private set; }
        public string? Nome { get; private set; }
        public TipoCliente TipoCliente { get; private set; }
        public string? NumeroDocumento { get; private set; }
    }

    public enum TipoCliente
    {
        PessoaFisica,
        PessoaJuridica
    }
}
