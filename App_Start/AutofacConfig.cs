using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using NorthwindAPI.Data;
using NorthwindAPI.Data.Entities;
using System.Reflection;
using System.Web.Http;

namespace NorthwindAPI.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var bldr = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            bldr.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterServices(bldr);
            bldr.RegisterWebApiFilterProvider(config);
            bldr.RegisterWebApiModelBinderProvider();
            var container = bldr.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder bldr)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new NorthwindMappingProfile());
            });
            bldr.RegisterInstance(config.CreateMapper())
                .As<IMapper>()
                .SingleInstance();

            bldr.RegisterType<NorthwindContext>()
              .InstancePerRequest();

            bldr.RegisterType<NorthwindRepository>()
              .As<INorthwindRepository>()
              .InstancePerRequest();
        }
    }
}
