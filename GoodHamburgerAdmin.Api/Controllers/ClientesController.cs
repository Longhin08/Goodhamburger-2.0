// ClientesController.cs
using Microsoft.AspNetCore.Mvc;
using GoodHamburgerAdmin.Domain;
using GoodHamburgerAdmin.Infrastructure.Services;

namespace GoodHamburgerAdmin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clientes = await _clienteService.ObterTodosAsync();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cliente = await _clienteService.ObterPorIdAsync(id);

        if (cliente is null)
            return NotFound();

        return Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Cliente cliente)
    {
        var criado = await _clienteService.CriarClienteAsync(cliente);
        return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
    }
}