//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.Global.asax.cs
// 2017/09/22
//  --------------------------------------------------------------------------------------

using System.Web;
using System.Web.Http;
using AspNet.WebApi.Example.WindsorIntegration;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace AspNet.WebApi.Example
{
    public class WebApiApplication : HttpApplication
    {
        WindsorContainer container;

        protected void Application_End()
        {
            container.Dispose();
        }

        protected void Application_Start()
        {
            ConfigureWindsor(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(p => WebApiConfig.Register(p, container));
        }

        void ConfigureWindsor(HttpConfiguration configuration)
        {
            container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();
            container.Install(FromAssembly.This());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(container);
            configuration.DependencyResolver = dependencyResolver;
        }
    }
}