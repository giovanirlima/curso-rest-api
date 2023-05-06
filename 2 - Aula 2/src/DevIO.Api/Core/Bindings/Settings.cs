using DevIO.Configuration;

namespace DevIO.Api.Core.Bindings
{
    public static class Settings
    {
        private static IConfiguration? _configuration;

        public static void InjectAppSettingsBindings(this IConfiguration configuration)
        {
            _configuration = configuration;
            BindDataSettings();
        }

        private static void BindDataSettings() =>
            _configuration?.GetSection("DataSettings").Bind(AppSettings.Settings.DataSettings);
    }
}