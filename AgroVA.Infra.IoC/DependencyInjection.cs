using AgroVA.Application.Interfaces;
using AgroVA.Application.Mappings;
using AgroVA.Application.Services;
using AgroVA.Domain.Account;
using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;
using AgroVA.Infra.Data.Identity;
using AgroVA.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgroVA.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DATABASE_CONNECTION"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                ));

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/Login";
        });

        services.AddScoped<IAnnotationRepository, AnnotationRepository>();
        services.AddScoped<IFarmerRepository, FarmerRepository>();
        services.AddScoped<IHarvestRepository, HarvestRepository>();
        services.AddScoped<IHuskPriceRepository, HuskPriceRepository>();
        services.AddScoped<ILoadRepository, LoadRepository>();
        services.AddScoped<IPromissoryRepository, PromissoryRepository>();
        services.AddScoped<IReceiptRepository, ReceiptRepository>();
        services.AddScoped<IRentRepository, RentRepository>();

        services.AddScoped<IAnnotationService, AnnotationService>();
        services.AddScoped<IFarmerService, FarmerService>();
        services.AddScoped<IHarvestService, HarvestService>();
        services.AddScoped<IHuskPriceService, HuskPriceService>();
        services.AddScoped<ILoadService, LoadService>();
        services.AddScoped<IPromissoryService, PromissoryService>();
        services.AddScoped<IReceiptService, ReceiptService>();
        services.AddScoped<IRentService, RentService>();

        services.AddScoped<IAuthenticate, AuthenticateService>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;

    }

    public static void MigrateDatabase(this DbContext context)
    {
        if ((context?.Database?.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)?.Exists() == true)
        {
            context?.Database?.Migrate();
        }
    }

}
