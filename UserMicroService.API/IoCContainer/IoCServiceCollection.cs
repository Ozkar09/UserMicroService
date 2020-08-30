using Autofac;
using Microsoft.Extensions.Configuration;
using UserMicroService.API.Facades;
using UserMicroService.IoCContainer;

namespace UserMicroService.API.IoCContainer
{
    public static class IoCServiceCollection
    {
        public static ContainerBuilder BuildContext(this ContainerBuilder builder, IConfiguration settings)
        {
            builder.BuildServicesContext(settings);
            builder.RegisterType<UsersMicroserviceFacade>();
            return builder;
        }
    }
}