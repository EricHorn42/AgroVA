using AgroVA.Application.Interfaces;
using AgroVA.Application.Mappings;
using AgroVA.Application.Services;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;
using AgroVA.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("SQLSERVERWINDOWS"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                    ));

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

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;

        }
    }
}
