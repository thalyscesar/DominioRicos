using Catalogo.Application.Commands;
using Catalogo.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CatalogoProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var buscarProdutos = await _mediator.Send(new BuscarProduto());

            if(buscarProdutos.Count() == 0) return NotFound(buscarProdutos);

            return Ok(buscarProdutos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Int64 id)
        {
            var buscarProdutoId = await _mediator.Send(new BuscarProdutoId() { Id = id });

            if(buscarProdutoId.Id == 0) return NotFound(buscarProdutoId);
            
            return Ok(buscarProdutoId);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AdicionarProduto adicionarProduto)
        {
            var produtoEnviado = await _mediator.Send(adicionarProduto);

            if (produtoEnviado) return Ok(produtoEnviado);

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Int64 id)
        {
            return Ok(await _mediator.Send(new DeletarProduto() { Id = id}));
        }

        [HttpPatch("{id}/descricao")]
        public async Task<IActionResult> PatchDescricao(Int64 id, string descricao)
        {
            var produtoAtualizado = await _mediator.Send( new AtualizarDescricaoProduto() { Id = id, Descricao = descricao});

            if(produtoAtualizado) return Ok(produtoAtualizado);
            
            return BadRequest(produtoAtualizado);
        }

        [HttpPatch("{id}/ativo")]
        public async Task<IActionResult> PatchAtivo(Int64 id, bool ativo)
        {
            var produtoAtualizado = await _mediator.Send(new AtualizarAtivoProduto() { Id = id, Ativo = ativo});

            if (produtoAtualizado) return Ok(produtoAtualizado);

            return BadRequest(produtoAtualizado);
        }

        [HttpPatch("{id}/valor")]
        public async Task<IActionResult> PatchValor(Int64 id, decimal valor)
        {
            var produtoAtualizado = await _mediator.Send(new AtualizarValorProduto() { Id = id, Valor = valor });

            if(produtoAtualizado) return Ok(produtoAtualizado);

            return BadRequest(produtoAtualizado);
        }

        [HttpPatch("{id}/quantidadeemestoque")]
        public async Task<IActionResult> PatchQuantidadeEmEstoque(Int64 id, int quantidade)
        {
            var produtoAtualizado = await _mediator.Send(new AtualizarQuantidadeEmEstoqueProduto() { Id = id, QuantidadeEmEstoque = quantidade});

            if(produtoAtualizado) return Ok(produtoAtualizado);

            return BadRequest(produtoAtualizado);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Int64 id, string descricao, bool ativo, decimal valor, int quantidadeEmEstoque)
        {
            var produtoAtualizado = await _mediator.Send(new AtualizarProduto()
            {
                Id = id,
                Descricao = descricao,
                Ativo = ativo,
                Valor = valor,
                QuantidadeEmEstoque = quantidadeEmEstoque
            });

            if(produtoAtualizado) return Ok(produtoAtualizado);

            return BadRequest(produtoAtualizado);
        }
    }
}
