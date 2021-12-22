using System;
using CEP.Domain.IRepository;
using CEP.Domain.IService;
using CEP.Infra.Data;
using CEP.Infra.Repositories;
using CEP.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CEP.CLI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbConnection(this IServiceCollection services, string connString){
            var contextOptions = new DbContextOptionsBuilder<Context>()
                .UseNpgsql(Environment.GetEnvironmentVariable(connString) ?? string.Empty)
                .Options;

            services.AddTransient(_ => new Context(contextOptions));
        }
        
        public static void AddRepositories(this IServiceCollection services){
            services.AddTransient<ICepRepository, CepRepository>();
            services.AddTransient<ICepApiRepository, CepApiRepository>();
        }
        
        public static void AddServices(this IServiceCollection services){
            services.AddTransient<ICepService, CepService>();
        }
        
    }
}