using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using SDammann.WebApi.Versioning;
using System.Web.Http.Description;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Autofac.Integration.WebApi;

namespace Exercise.App_Start
{
    public class AutofacConfig
    {
        public static void Initialise()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var config = GlobalConfiguration.Configuration;
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterType<VersionedApiExplorer>().As<IApiExplorer>().WithParameter("configuration", config).InstancePerLifetimeScope();
            builder.RegisterType<RouteVersionedControllerSelector>().As<IHttpControllerSelector>().WithParameter("configuration", config).InstancePerLifetimeScope();
            //builder.RegisterType<AcceptHeaderVersionedControllerSelector>().As<IHttpControllerSelector>().WithParameter("configuration", GlobalConfiguration.Configuration);


            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}