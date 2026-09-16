using Microsoft.AspNetCore.Mvc;
using GoodHamburgerAdmin.Domain;
using GoodHamburgerAdmin.Infrastructure.Services;

namespace GoodHamburgerAdmin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IPedidoService _pedidoService;

    public PedidosController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pedidos = await _pedidoService.ObterTodosAsync();
        return Ok(pedidos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pedido = await _pedidoService.ObterPorIdAsync(id);

        if (pedido is null)
            return NotFound();

        return Ok(pedido);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Pedido pedido)
    {
        var criado = await _pedidoService.CriarPedidoAsync(pedido);
        return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
    }
}