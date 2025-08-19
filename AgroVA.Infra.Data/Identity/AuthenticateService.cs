using AgroVA.Domain.Account;
using AgroVA.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



namespace AgroVA.Infra.Data.Identity;

public class AuthenticateService : IAuthenticate
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<ApplicationUser?> Authenticate(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

        if (!result.Succeeded) return null;

        var user = await GetUser(email);

        return user;
    }

    public string GenerateRefreshToken(ApplicationUser user)
    {
        if (user.Email == null) throw new Exception("Email não pode ser nulo.");

        IConfigurationSection jwtSettings = _configuration.GetSection("Jwt");

        var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        new Claim(JwtRegisteredClaimNames.Name, user.UserName ?? user.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Iat,
        new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString(),
            ClaimValueTypes.Integer64)
    };

        var secretKey = jwtSettings.GetSection("SecretKey").Value;

        if (string.IsNullOrWhiteSpace(secretKey)) throw new Exception("Chave secreta não configurada.");

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.Now.AddMinutes(int.Parse(jwtSettings["RefreshTokenExpiration"] ?? "30"));

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            notBefore: DateTime.Now,
            expires: expiration,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<string> GenerateToken(ApplicationUser user)
    {
        if (user.Email == null) throw new Exception("Email não pode ser nulo.");

        IConfigurationSection jwtSettings = _configuration.GetSection("Jwt");

        var claims = new List<Claim>{
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName ?? user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat,
            new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString(),ClaimValueTypes.Integer64)
        };

        var realUser = await _userManager.FindByEmailAsync(user.Email);
        var roles = await GetUserRoles(realUser!);

        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));        

        var secretKey = jwtSettings.GetSection("SecretKey").Value;

        if (string.IsNullOrWhiteSpace(secretKey)) throw new Exception("Chave secreta não configurada.");

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.Now.AddMinutes(int.Parse(jwtSettings["Expiration"] ?? "5"));

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            notBefore: DateTime.Now,
            expires: expiration,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<ApplicationUser?> GetUser(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<IList<string>> GetUserRoles(ApplicationUser user)
    {
        return await _userManager.GetRolesAsync(user);
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<bool> Register(string email, string name, string password)
    {
        var user = new ApplicationUser
        {
            UserName = name,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
            await _signInManager.SignInAsync(user, false);


        return result.Succeeded;
    }

    public async Task<(bool isValid, string? email)> ValidateTokenAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token)) return (false, null);

        var validTokenResult = await new JwtSecurityTokenHandler().ValidateTokenAsync(token, TokenHelper.GetTokenValidationParameters(_configuration));

        if (!validTokenResult.IsValid) return (false, null);


        var userName = validTokenResult.Claims.FirstOrDefault(c => c.Key == ClaimTypes.NameIdentifier).Value as string;
        return (true, userName);
    }
}
