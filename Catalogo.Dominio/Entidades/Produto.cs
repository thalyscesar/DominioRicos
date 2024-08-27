using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Dominio.Entidades
{
    public class Produto
    {
        public Produto()
        {

        }

        public Produto(Int64 id, Int64 categoriaId, string? nome, string? descricao, bool ativo, decimal valor, DateTime dataCadastro, int quantidadeEstoque, decimal altura, decimal largura, decimal profundidade, Categoria categoria)
        {
            Id = id;
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            QuantidadeEstoque = quantidadeEstoque;
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
            Categoria = categoria;
        }

        public Int64 Id { get; private set; }
        public Int64 CategoriaId { get; private set; }
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }
        public Categoria Categoria { get; private set; }

        public void SetCategoriaId(Int64 id)
        {
            this.Categoria = null;
            this.CategoriaId = id;
        }
    }
}


