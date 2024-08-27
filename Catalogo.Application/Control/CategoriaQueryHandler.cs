using Catalogo.Application.Queries;
using Catalogo.Dominio.Entidades;
using Catalogo.Service.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace Catalogo.Application.Control
{
    public class CategoriaQueryHandler : IRequestHandler<BuscarCategoria, List<BuscarCategoria>>, IRequestHandler<BuscarCategoriaId, BuscarCategoria>
    {
        private readonly ICategoriaServices _categoriaServices;

        public CategoriaQueryHandler(ICategoriaServices categoriaServices)
        {
            _categoriaServices = categoriaServices;
        }

        public Task<List<BuscarCategoria>> Handle(BuscarCategoria request, CancellationToken cancellationToken)
        {
            List<BuscarCategoria> lista = new List<BuscarCategoria>();

            foreach (var categoria in _categoriaServices.ObterTodas())
            {
                lista.Add(ConverterParaBuscarCategoria(categoria));
            }

            return Task.FromResult(lista);
        }

        public Task<BuscarCategoria> Handle(BuscarCategoriaId request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(new BuscarCategoria() { Id = 0 });

            return Task.FromResult(ConverterParaBuscarCategoria(_categoriaServices.ObterPorId(request.Id)));
        }

        public BuscarCategoria ConverterParaBuscarCategoria(Categoria categoria)
        {
            return new BuscarCategoria() { Id = categoria.Id, Nome = categoria.Nome };
        }

        public ValidationResult ObterResultadoValidacao(BuscarCategoriaId buscarCategoriaId)
        {
            return new ValidadorBuscarCategoriaId().Validate(buscarCategoriaId);
        }
    }
}
