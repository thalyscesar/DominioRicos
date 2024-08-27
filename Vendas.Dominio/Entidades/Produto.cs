
namespace Vendas.Dominio.Entidades
{
    public class Produto
    {
        public Produto()
        {

        }

        public Produto(Int64 id, string? nome, int quantidade, decimal valor, string codigo)
        {
            Id = id;
            Nome = nome;
            QuantidadeEmEstoque = quantidade;
            Valor = valor;
            Codigo = codigo;
        }

        public Int64 Id { get; private set; }
        public string? Nome { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }
        public decimal Valor { get; private set; }
        public string? Codigo { get; private set; }

        public void AtualizarEstoque(int quantidade, bool adicionou)
        {
            if (adicionou)
            {
                if(quantidade <= this.QuantidadeEmEstoque) this.QuantidadeEmEstoque -= quantidade;
            }
            else
            {
                this.QuantidadeEmEstoque += quantidade;
            }
        }
    }
}
