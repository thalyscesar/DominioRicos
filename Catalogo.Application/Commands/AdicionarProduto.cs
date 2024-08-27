using Catalogo.Dominio.Entidades;
using FluentValidation;
using MediatR;

namespace Catalogo.Application.Commands
{
    public class AdicionarProduto : IRequest<bool>
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public int QuantidadeEstoque { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public decimal Profundidade { get; set; }
        public Categoria Categoria { get; set; }

    }

    public class ValidadorAdicionarProduto : AbstractValidator<AdicionarProduto>
    {
        public ValidadorAdicionarProduto()
        {
            RuleFor(p => p.Nome).NotEmpty().NotNull().WithMessage("Informe o nome");
            RuleFor(p => p.Nome).MinimumLength(3).MaximumLength(30).WithMessage("{Nome} deve conter de 3 a 30 caracteres");
            RuleFor(p => p.Descricao).NotEmpty().NotNull().WithMessage("Informe uma descrição");
            RuleFor(p => p.Descricao).MinimumLength(10).MaximumLength(100).WithMessage("A descrição deve ter de 10 a 100 caracteres");
            RuleFor(p => p.Ativo).NotEmpty().NotNull().WithMessage("Informe a situação do produto");
            RuleFor(p => p.Valor).NotNull().NotEmpty().WithMessage("Informe o valor");
            RuleFor(p => p.Valor).Must(v => v >= 0.04M).WithMessage("O valor não pode ser menor que R$0.05 centavos");
            RuleFor(p => p.DataCadastro).NotEmpty().NotNull().WithMessage("Informe a data de cadastro");
            RuleFor(p => p.QuantidadeEstoque).NotNull().NotEmpty().WithMessage("Informe a quantidade em estoque");
            RuleFor(p => p.QuantidadeEstoque).Must(q => q > 0).WithMessage("O estoque não pode ser 0");
            RuleFor(p => p.Altura).NotNull().NotEmpty().WithMessage("Informe a altura");
            RuleFor(p => p.Altura).Must(a => a >= 1).WithMessage("Altura não pode ser menor que 1");
            RuleFor(p => p.Largura).NotNull().NotEmpty().WithMessage("Informe a largura");
            RuleFor(p => p.Largura).Must(l => l >= 1).WithMessage("Largura não pode ser menor que 1");
            RuleFor(p => p.Profundidade).NotNull().NotEmpty().WithMessage("Informe a profundidade");
            RuleFor(p => p.Profundidade).Must(p => p >= 1).WithMessage("Profundidade não pode ser menor que 1");

            //RuleFor(c => c.Categoria).Must(c => !new ProdutoServices().CategoriaExiste(c.Nome)).WithMessage("Categoria já cadastrada");
            RuleFor(p => p.Categoria.Nome).NotNull().NotEmpty().WithMessage("Informe o nome da categoria");
            RuleFor(p => p.Categoria.Nome).MinimumLength(5).MaximumLength(30).WithMessage("{Nome} deve conter de 5 a 30 caracteres");
        }
    }
}
