using Microsoft.AspNetCore.Mvc;
using GoodHamburgerAdmin.Domain;
using GoodHamburgerAdmin.Infrastructure;
using GoodHamburgerAdmin.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburgerAdmin.Api.Controllers;

public record RegistroRequest(string Nome, string Email, string Senha);
public record LoginRequest(string Email, string Senha);

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IPasswordService _passwordService;
    private readonly ITokenService _tokenService;

    public AuthController(AppDbContext context, IPasswordService passwordService, ITokenService tokenService)
    {
        _context = context;
        _passwordService = passwordService;
        _tokenService = tokenService;
    }

    [HttpPost("registro")]
    public async Task<IActionResult> Registro([FromBody] RegistroRequest request)
    {
        var existeUsuario = await _context.Usuarios.AnyAsync(u => u.Email == request.Email);
        if (existeUsuario)
            return BadRequest("Já existe um usuário com esse email.");

        var usuario = new Usuario
        {
            Nome = request.Nome,
            Email = request.Email,
            SenhaHash = _passwordService.HashSenha(request.Senha)
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return Ok(new { usuario.Id, usuario.Nome, usuario.Email });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (usuario is null || !_passwordService.VerificarSenha(request.Senha, usuario.SenhaHash))
            return Unauthorized("Email ou senha inválidos.");

        var token = _tokenService.GerarToken(usuario);

        return Ok(new { token });
    }
}