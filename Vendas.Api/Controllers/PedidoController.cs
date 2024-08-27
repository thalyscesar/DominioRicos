using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Commands;
using Vendas.Application.Queries;

namespace Vendas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarPedido adicionarPedido)
        {
            var pedidoAdicionado = await _mediator.Send(adicionarPedido);

            if(pedidoAdicionado) return Ok(adicionarPedido);

            return BadRequest(pedidoAdicionado);
        }

        [HttpGet("{id}/getbyid")]
        public async Task<IActionResult> GetById(Int64 id)
        {
            var pedidoPorId = await _mediator.Send(new MostrarPedidoPorId() { Id = id });

            if (pedidoPorId.Id > 0) return Ok(pedidoPorId);

            return BadRequest(pedidoPorId);
        }

        [HttpGet("{idcliente}/getbycliente")]
        public async Task<IActionResult> GetByCliente (Int64 idcliente)
        {
            var pedidoPorCliente = await _mediator.Send(new MostrarPedidoPorCliente() { IdCliente = idcliente });

            return Ok(pedidoPorCliente);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchStatus([FromBody]AtualizarStatusPedido atualizarStatusPedido)
        {
            var pedidoAtualizado = await _mediator.Send(atualizarStatusPedido);

            if ((bool)pedidoAtualizado) return Ok(pedidoAtualizado);

            return BadRequest(pedidoAtualizado);
        }
    }
}
