using Catalogo.Service.Services;
using FluentValidation;
using MediatR;

namespace Catalogo.Application.Commands
{
    public class AtualizarProduto : IRequest<bool>
    {
        public long Id { get; set; }
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }
        public decimal Valor { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }

    public class ValidadorAtualizarProduto : AbstractValidator<AtualizarProduto>
    {
        public ValidadorAtualizarProduto()
        {
            RuleFor(p => p).Must(a => new ProdutoServices().ProdutoExiste(a.Id)).WithMessage("O produto não existe");
            RuleFor(p => p.Descricao).NotEmpty().NotNull().WithMessage("Informe uma descrição");
            RuleFor(p => p.Descricao).MinimumLength(10).MaximumLength(100).WithMessage("A descrição deve ter de 10 a 100 caracteres");
            RuleFor(p => p.Ativo).NotNull().WithMessage("Informe a situação do produto");
            RuleFor(p => p.Valor).NotNull().NotEmpty().WithMessage("Informe o valor");
            RuleFor(p => p.Valor).Must(v => v >= 0.04M).WithMessage("O valor não pode ser menor que R$0.05 centavos");
            RuleFor(p => p.QuantidadeEmEstoque).NotNull().NotEmpty().WithMessage("Informe uma nova quantidade de estoque para o estado");
            RuleFor(p => p.QuantidadeEmEstoque).Must(v => v > 0).WithMessage("A quantidade em estoque não pode ser 0");
        }
    }
}
