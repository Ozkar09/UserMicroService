using Autofac;
using Microsoft.Extensions.Configuration;
using UserMicroService.Business;
using UserMicroService.Business.User;
using UserMicroService.Configuration;
using UserMicroService.Infraestructure.EntityFramework;
using UserMicroService.RemoteServices;
using UserMicroService.RemoteServices.User;
using UserMicroService.Repositories;
using UserMicroService.Repositories.Sql;
using UserMicroService.Repositories.Sql.EF;

namespace UserMicroService.IoCContainer
{
    public static class IoCServiceCollection
    {
        public static ContainerBuilder BuildServicesContext(this ContainerBuilder builder, IConfiguration settings)
        {
            builder.Register(context => new MicroServiceContextProvider(settings[EnvironmentSettings.MicroServiceConnectionString]))
                .As<IEFContextProvider>();
            
            builder.Register(context => new MicroservicesContext(settings[EnvironmentSettings.MicroServiceConnectionString]));
            
            builder.RegisterType<SqlUserRepository>().As<IUserMicroserviceRepository>();
            
            builder.Register(context =>
                    new UsersBusiness(
                        context.Resolve<IUserMicroserviceRepository>()))
                .As<IUsersBusiness>();
            
            builder.RegisterType<UserService>().As<IUsersServices>();
            
            return builder;
        }
    }
}