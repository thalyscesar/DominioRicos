using Catalogo.Dominio.Entidades;
using MediatR;

namespace Catalogo.Application.Queries
{
    public class BuscarProduto : IRequest<List<BuscarProduto>>
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }
        public decimal Valor { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public decimal Profundidade { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
