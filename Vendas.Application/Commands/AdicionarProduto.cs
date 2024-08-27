
using FluentValidation;
using MediatR;

namespace Vendas.Application.Commands
{
    public class AdicionarProduto : IRequest<bool>
    {
        public string? Nome { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public decimal Valor { get; set; }
        public string? Codigo { get; set; }
    }

    public class ValidadorAdicionarProduto : AbstractValidator<AdicionarProduto>
    {
        public ValidadorAdicionarProduto()
        {
            RuleFor(p => p.Nome).NotEmpty().NotNull().WithMessage("Nome não pode ser nulo ou vazio");
            RuleFor(p => p.Nome).MinimumLength(3).MaximumLength(50).WithMessage("O nome deve conter de 3 a 50 caracteres");
            RuleFor(p => p.QuantidadeEmEstoque).NotEmpty().NotNull().WithMessage("A quantidade em estoque não pode ser nula ou vazia");
            RuleFor(p => p).Must(q => q.QuantidadeEmEstoque > 0).WithMessage("A quantidade em estoque deve ser maior que 0");
            RuleFor(p => p.Valor).NotNull().NotEmpty().WithMessage("O valor não pode ser nulo ou vazio");
            RuleFor(p => p).Must(v => v.Valor > 0).WithMessage("O valor não pode ser 0");
            RuleFor(p => p.Codigo).NotEmpty().NotNull().WithMessage("O codigo não pode ser nulo ou vazio");
            RuleFor(p => p.Codigo).MinimumLength(1).MaximumLength(10).WithMessage("O tamanho do codigo deve ser de 1 a 10 caracteres");
        }
    }
}
