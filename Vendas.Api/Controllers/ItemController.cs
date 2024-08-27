using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Commands;
using Vendas.Application.Queries;

namespace Vendas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarItem adicionarItem)
        {
            var adicionado = await _mediator.Send(adicionarItem);

            if (adicionado) return Ok(adicionado);

            return BadRequest(adicionado);
        }

        [HttpPost("postitemaopedido")]
        public async Task<IActionResult> PostItemAoPedido([FromBody]AdicionarItemAoPedido adicionarItemAoPedido)
        {
            var adicionado = await _mediator.Send(adicionarItemAoPedido);

            if (adicionado) return Ok(adicionado);

            return BadRequest(adicionado);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchQuantidade([FromBody] AtualizarQuantidadeItem atualizarQuantidadeItem)
        {
            var atualizado = await _mediator.Send(atualizarQuantidadeItem);

            if(atualizado) return Ok(atualizado);

            return BadRequest(atualizado);
        }

        [HttpGet("{id}/getbyid")]
        public async Task<IActionResult> GetById(Int64 id)
        {
            var itemBuscado = await _mediator.Send(new MostrarItemPorId() { Id = id });

            if(itemBuscado.Id > 0) return Ok(itemBuscado);

            return NotFound(itemBuscado);
        }

        [HttpGet("{idpedido}/getbypedido")]
        public async Task<IActionResult> GetByPedido(Int64 idpedido)
        {
            var itemBuscado = await _mediator.Send(new MostrarItemPorPedido() { IdPedido = idpedido });

            if (itemBuscado[0].Id > 0) return Ok(itemBuscado);

            return NotFound(itemBuscado);
        }

        [HttpGet("getbypedidoeproduto")]
        public async Task<IActionResult> GetByPedidoEProduto(Int64 idPedido, Int64 idProduto)
        {
            var itemBuscado = await _mediator.Send( new MostrarItemPorPedidoEProduto() { IdPedido = idPedido, IdProduto = idProduto});

            if (itemBuscado.Id > 0) return Ok(itemBuscado);

            return NotFound(itemBuscado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Int64 id)
        {
            var itemDeletado = await _mediator.Send(new DeletarItem() { Id = id });
            
            if(itemDeletado) return Ok(itemDeletado);

            return BadRequest(itemDeletado);
        }
    }
}
