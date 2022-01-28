using System;

using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(options => options
            //    .UseSqlServer(configuration.GetConnectionString("SQLServer"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddDbContext<ApplicationDbContext>(options => options
                .UseNpgsql(configuration.GetConnectionString("PostgreSQL"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .UseLowerCaseNamingConvention());

            services.AddScoped<ICategoryRepository, CategoryRepository>(); //recomendação para projetos web
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPaisRepository,PaisRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPaisService, PaisService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddAutoMapper(typeof(DTOToCommandMappingProfile));

            var handlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
            services.AddMediatR(handlers);

            return services;
        }
    }
}
