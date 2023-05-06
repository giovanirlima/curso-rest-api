using DevIO.Api.Core.Profiles;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Service;
using DevIO.Configuration;
using DevIO.Data.ContextDB;
using DevIO.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Api.Core.IoC
{
    public static class Bootstrapper
    {
        private static IServiceCollection _services;

        public static void InjectDependencies(this IServiceCollection services)
        {
            _services = services;

            InjectDbContextDependencies();
            InjectAutoMapperDependencies();
            InjectRepositoryDependencies();
            InjectServiceDependencies();
        }

        private static void InjectDbContextDependencies()
        {
            _services.AddDbContext<Context>(opt => opt.UseSqlServer(AppSettings.Settings.DataSettings.ConnectionString));
            _services.AddScoped<Context>();
        }

        private static void InjectAutoMapperDependencies() =>
            _services.AddAutoMapper(typeof(FornecedorProfile).Assembly);

        private static void InjectRepositoryDependencies()
        {
            _services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            _services.AddScoped<IProdutoRepository, ProdutoRepository>();
            _services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        }

        private static void InjectServiceDependencies()
        {
            _services.AddScoped<IFornecedorService, FornecedorService>();
        }
    }
}