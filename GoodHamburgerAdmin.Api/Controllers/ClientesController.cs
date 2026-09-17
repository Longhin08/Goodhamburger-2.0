// ClientesController.cs
using GoodHamburgerAdmin.Domain;
using GoodHamburgerAdmin.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburgerAdmin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
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
    public async Task<IActionResult> Cre8ate([FromBody] Cliente cliente)
    {
        var criado = await _clienteService.CriarClienteAsync(cliente);
        return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Update(int id, [FromBody] Cliente cliente)
    {
        var atualizado = await _clienteService.AtualizarClienteAsync(id, cliente);

        if (!atualizado)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
 
    public async Task<IActionResult> Delete(int id)
    {
        var deletado = await _clienteService.DeletarClienteAsync(id);

        if (!deletado)
            return NotFound();

        return NoContent();
    }
}