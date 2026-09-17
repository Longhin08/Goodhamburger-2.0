namespace GoodHamburgerAdmin.Infrastructure.Services;

public interface IPasswordService
{
    string HashSenha(string senha);
    bool VerificarSenha(string senha, string hash);
}

public class PasswordService : IPasswordService
{
    public string HashSenha(string senha) =>
        BCrypt.Net.BCrypt.HashPassword(senha);

    public bool VerificarSenha(string senha, string hash) =>
        BCrypt.Net.BCrypt.Verify(senha, hash);
}