using AgroVA.Domain.Entities;
namespace AgroVA.Domain.Account;

public interface IAuthenticate
{
    Task<ApplicationUser?> Authenticate(string email, string password);
    Task<bool> Register(string email, string name, string password);
    Task Logout();
    Task<ApplicationUser?> GetUser(string email);
    Task<(bool isValid, string? email)> ValidateTokenAsync(string token);
    Task<IList<string>> GetUserRoles(ApplicationUser user);
    Task<string> GenerateToken(ApplicationUser user);
    string GenerateRefreshToken(ApplicationUser user);
}
