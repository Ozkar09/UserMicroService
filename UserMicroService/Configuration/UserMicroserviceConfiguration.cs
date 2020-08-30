using Microsoft.Extensions.Configuration;

namespace UserMicroService.Configuration
{
    public class UserMicroserviceConfiguration: IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new MicroServiceEnvironmentConfigurationProvider();
        }
    }
    
    public static class UserMicroserviceConfigurationSourceExtensions
    {
        public static IConfigurationBuilder AddUserMicroserviceConfiguration(this IConfigurationBuilder builder)
        {
            return builder.Add(new UserMicroserviceConfiguration());
        }
    }
}