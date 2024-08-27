
using Cadastro.Application.Queries;
using Cadastro.Dominio.Entidades;
using Cadastro.Service.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace Cadastro.Application.Controls
{
    public class ClienteQueryHandler :  IRequestHandler<BuscarCliente, List<BuscarCliente>>,
                                        IRequestHandler<BuscarClientePorId, BuscarCliente>
    {
        private readonly IClienteService _clienteService;
        public ClienteQueryHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public Task<List<BuscarCliente>> Handle(BuscarCliente request, CancellationToken cancellationToken)
        {
            List<BuscarCliente> lista = new List<BuscarCliente>();
            var clientes = _clienteService.ObterTodos();

            foreach (var cliente in clientes)
            {
                lista.Add(this.ConverterParaBuscarCliente(cliente));
            }

            return Task.FromResult(lista);
        }

        public Task<BuscarCliente> Handle(BuscarClientePorId request, CancellationToken cancellationToken)
        {
            var cliente = _clienteService.ObterPorId(request.Id);

            if (!this.ObterResultadoValidacao(request).IsValid) return null;

            return Task.FromResult(this.ConverterParaBuscarCliente(cliente));
        }

        private BuscarCliente ConverterParaBuscarCliente(Cliente cliente)
        {
            return new BuscarCliente()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                TipoCliente = cliente.TipoCliente,
                NumeroDocumento = cliente.NumeroDocumento
            };
        }

        public ValidationResult ObterResultadoValidacao(BuscarClientePorId buscarClientePorId)
        {
            return new ValidadorBuscarClientePorId().Validate(buscarClientePorId);
        }
    }
}
