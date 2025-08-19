using AgroVA.Infra.Data.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Infra.IoC;

public static class DependencyInjectionJWT
{
    public static IServiceCollection AddInfrastructureJWT(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //opt.DefaultMapInboundClaims = false
        })
       .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = TokenHelper.GetTokenValidationParameters(configuration);
                //options.Events = new JwtBearerEvents
                //{
                //    OnAuthenticationFailed = context =>
                //    {
                //        Console.WriteLine("🔥 Autenticação falhou:");
                //        Console.WriteLine(context.Exception.ToString());
                //        return Task.CompletedTask;
                //    },
                //    OnTokenValidated = context =>
                //    {
                //        Console.WriteLine("✅ Token JWT válido para: " + context.Principal?.Identity?.Name);
                //        return Task.CompletedTask;
                //    },
                //    OnChallenge = context =>
                //    {
                //        Console.WriteLine("⚠️ JWT Challenge disparado: " + context.ErrorDescription);
                //        return Task.CompletedTask;
                //    }
                //};

            });

        return services;
    }
}
