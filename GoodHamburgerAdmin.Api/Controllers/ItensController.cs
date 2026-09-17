using GoodHamburgerAdmin.Domain;
using GoodHamburgerAdmin.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburgerAdmin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ItensController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItensController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var itens = await _itemService.ObterTodosAsync();
        return Ok(itens);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _itemService.ObterPorIdAsync(id);

        if (item is null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Item item)
    {
        var criado = await _itemService.CriarItemAsync(item);
        return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
    }
}