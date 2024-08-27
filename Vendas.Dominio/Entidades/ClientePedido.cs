
namespace Vendas.Dominio.Entidades
{
    public class ClientePedido
    {
        public ClientePedido(Int64 id, string nome, string numeroDocumento)
        {
            Id = id;
            Nome = nome;
            NumeroDocumento = numeroDocumento;
        }

        public Int64 Id { get; private set; }
        public string Nome { get; private set; }
        public string NumeroDocumento { get; private set; }
    }
}
