using Catalogo.Service.Services;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Commands
{
    public class AtualizarCategoria : IRequest<bool>
    {
        public long Id { get; set; }
        public string Nome { get; set; }
    }

    public class ValidadorAtualizarCategoria : AbstractValidator<AtualizarCategoria>
    {
        public ValidadorAtualizarCategoria()
        {
            RuleFor(c => c).Must(e => new CategoriaServices().CategoriaExiste(e.Id)).WithMessage("A categoria não existe");
            RuleFor(p => p.Nome).NotEmpty().NotNull().WithMessage("Informe um novo valor para nome");
            RuleFor(p => p.Nome).MinimumLength(10).MaximumLength(100).WithMessage("O tamanho deve ser de 3 a 30 caracteres");
        }
    }
}
