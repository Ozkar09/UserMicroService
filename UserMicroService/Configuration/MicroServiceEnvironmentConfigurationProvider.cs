using Microsoft.Extensions.Configuration;

namespace UserMicroService.Configuration
{
    public class MicroServiceEnvironmentConfigurationProvider: ConfigurationProvider
    {
        public MicroServiceEnvironmentConfigurationProvider(){}
        public override void Load()
        {
            foreach (var (key,value) in EnvironmentSettings.GetFileProcessorEnvironmentValues())
            {
                Data.Add(key,value);
            }
            base.Load();
        }
    }
}