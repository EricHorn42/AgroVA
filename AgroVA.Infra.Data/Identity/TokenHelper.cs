using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AgroVA.Infra.Data.Identity;

public static class TokenHelper
{
    public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
    {
        var secretKey = configuration["Jwt:SecretKey"];

        if (secretKey == null) throw new Exception("SecretKey cannot be null.");

        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ClockSkew = TimeSpan.Zero
        };
    }
}
