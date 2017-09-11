using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using Autofac;
using Autofac.Integration.WebApi;
using SDammann.WebApi.Versioning;

namespace Exercise
{
    public class AutofacConfig
    {
        public static void Initialise()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var config = GlobalConfiguration.Configuration;
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterType<VersionedApiExplorer>().As<IApiExplorer>().WithParameter("configuration", config).InstancePerLifetimeScope();
            builder.RegisterType<VersionHeaderVersionedControllerSelector>().As<IHttpControllerSelector>()
                .WithParameter("configuration", config)
                .WithParameter("defaultVersion", "2").
                InstancePerLifetimeScope();


            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}