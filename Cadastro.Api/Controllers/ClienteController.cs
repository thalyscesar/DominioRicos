using Cadastro.Application.Commands;
using Cadastro.Application.Queries;
using Cadastro.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarCliente adicionarCliente)
        {
            var clienteAdicionado = await _mediator.Send(adicionarCliente);

            return Ok(clienteAdicionado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Int64 id)
        {
            var clienteDeletado = await _mediator.Send(new DeletarCliente() { Id = id});

            if (clienteDeletado) return Ok(clienteDeletado);

            return BadRequest(clienteDeletado);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromBody] AtualizarCliente atualizarCliente)
        {
            var clienteAtualizado = await _mediator.Send(atualizarCliente);

            if (clienteAtualizado) return Ok(clienteAtualizado);

            return BadRequest(clienteAtualizado);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listaClientes = await _mediator.Send(new BuscarCliente());

            if (listaClientes == null) return BadRequest(listaClientes);

            return Ok(listaClientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Int64 id)
        {
            var cliente = await _mediator.Send(new BuscarClientePorId() { Id = id });

            if (cliente == null) return BadRequest(cliente);

            return Ok(cliente);
        }
    }
}
