using Catalogo.Application.Commands;
using Catalogo.Service.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace Catalogo.Application.Control
{
    public class CategoriaHandler : IRequestHandler<AtualizarCategoria, bool>
    {
        private readonly ICategoriaServices _categoriaServices;

        public CategoriaHandler(ICategoriaServices categoriaServices)
        {
            _categoriaServices = categoriaServices;
        }

        public Task<bool> Handle(AtualizarCategoria request, CancellationToken cancellationToken)
        {
            if (!ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            return Task.FromResult(_categoriaServices.Atualizar(request.Id, request.Nome));
        }

        public ValidationResult ObterResultadoValidacao(AtualizarCategoria atualizarCategoria)
        {
            return new ValidadorAtualizarCategoria().Validate(atualizarCategoria);
        }
    }
}
