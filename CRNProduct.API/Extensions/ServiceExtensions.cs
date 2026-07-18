using CRNProduct.Application.Interfaces;
using CRNProduct.Application.Mapping;
using CRNProduct.Application.Services;
using CRNProduct.Application.Validators;
using CRNProduct.Infrastructure.Data;
using CRNProduct.Infrastructure.Data.Repositories;
using CRNProduct.Infrastructure.Identity;
using CRNProduct.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CRNProduct.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IItemService, ItemService>();

            // JWT Service
            services.AddScoped<JwtService>();

            // AutoMapper
            services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

            // Fluent Validation
            services.AddValidatorsFromAssemblyContaining<ProductValidator>();

            return services;
        }
    }
}