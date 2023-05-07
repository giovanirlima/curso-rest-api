using DevIO.Configuration.AppModels;

namespace DevIO.Configuration
{
    public class AppSettings
    {
        public AppSettings()
        {
            DataSettings = new DataSettings();
        }

        public static AppSettings Settings = new AppSettings();
        public DataSettings DataSettings { get; set; }
    }
}