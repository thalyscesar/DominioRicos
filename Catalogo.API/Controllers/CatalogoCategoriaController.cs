using Catalogo.Application.Commands;
using Catalogo.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoCategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogoCategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pegarCategorias = await _mediator.Send(new BuscarCategoria());

            return Ok(pegarCategorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            var pegarCategoria = await _mediator.Send(new BuscarCategoriaId() { Id = id});

            if(pegarCategoria.Id>0) return Ok(pegarCategoria);

            return BadRequest(pegarCategoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Int64 id, string nome)
        {
            var atualizarCategoria = await _mediator.Send(new AtualizarCategoria() { Id = id, Nome = nome });

            if(atualizarCategoria) return Ok(atualizarCategoria);

            return BadRequest(atualizarCategoria);
        }
    }
}
