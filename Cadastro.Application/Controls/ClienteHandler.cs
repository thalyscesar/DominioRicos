using Cadastro.Application.Commands;
using Cadastro.Dominio.Entidades;
using Cadastro.Service.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace Cadastro.Application.Controls
{
    public class ClienteHandler :   IRequestHandler<AdicionarCliente, bool>,
                                    IRequestHandler<DeletarCliente, bool>,
                                    IRequestHandler<AtualizarCliente, bool>
    {
        private readonly IClienteService _clienteService;

        public ClienteHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public Task<bool> Handle(AdicionarCliente request, CancellationToken cancellationToken)
        {
            if(!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            return Task.FromResult(_clienteService.Adicionar(this.ConverterParaCliente(request)));
        }

        public Task<bool> Handle(DeletarCliente request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            return Task.FromResult(_clienteService.Deletar(request.Id));
        }

        public Task<bool> Handle(AtualizarCliente request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            return Task.FromResult(_clienteService.AtualizarNome(request.Id, request.Nome));
        }

        // Converções

        private Cliente ConverterParaCliente(AdicionarCliente adicionarCliente)
        {
            return new Cliente(0, adicionarCliente.Nome, adicionarCliente.TipoCliente, adicionarCliente.NumeroDocumento);
        }

        // Validações

        public ValidationResult ObterResultadoValidacao(AdicionarCliente adicionarCliente)
        {
            return new ValidadorAdicionarCliente().Validate(adicionarCliente);
        }

        public ValidationResult ObterResultadoValidacao(DeletarCliente deletarCliente)
        {
            return new ValidadorDeletarCliente().Validate(deletarCliente);
        }

        public ValidationResult ObterResultadoValidacao(AtualizarCliente atualizarCliente)
        {
            return new ValidadorAtualizarCliente().Validate(atualizarCliente);
        }
    }
}
