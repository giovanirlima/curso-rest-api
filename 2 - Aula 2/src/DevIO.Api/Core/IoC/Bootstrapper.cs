namespace DevIO.Api.Core.IoC
{
    public static class Bootstrapper
    {
        private static IServiceCollection _services;

        public static void InjectDependencies(this IServiceCollection services)
        {
            _services = services;
        }
    }
}