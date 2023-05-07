using DevIO.Api.Core.Profiles;
using DevIO.Business.Intefaces;
using DevIO.Business.Notificacoes;
using DevIO.Business.Services;
using DevIO.Configuration;
using DevIO.Data.ContextDb;
using DevIO.Data.Repository;
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
            InjectNotificationDependencies();
        }

        private static void InjectDbContextDependencies()
        {
            _services.AddDbContext<Context>(opt => opt.UseSqlServer(AppSettings.Settings.DataSettings.ConnectionString));
            _services.AddScoped<Context>();
        }

        private static void InjectAutoMapperDependencies() =>
            _services.AddAutoMapper(typeof(ClassProfile).Assembly);

        private static void InjectRepositoryDependencies()
        {
            _services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            _services.AddScoped<IProdutoRepository, ProdutoRepository>();
            _services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        }

        private static void InjectServiceDependencies()
        {
            _services.AddScoped<IFornecedorService, FornecedorService>();
            _services.AddScoped<IProdutoService, ProdutoService>();
        }

        private static void InjectNotificationDependencies() =>
            _services.AddScoped<INotificador, Notificador>();
    }
}