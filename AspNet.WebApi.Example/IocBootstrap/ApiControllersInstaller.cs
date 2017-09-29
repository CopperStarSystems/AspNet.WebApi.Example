//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.ApiControllersInstaller.cs
// 2017/09/23
//  --------------------------------------------------------------------------------------

using System.Web.Http;
using AspNet.WebApi.Example.Repository;
using Castle.MicroKernel.Registration;

namespace AspNet.WebApi.Example.IocBootstrap
{
    public class ApiControllersInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container,
                            Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                      .BasedOn<ApiController>()
                                      .LifestylePerWebRequest());
            container.Register(Component.For<IRepository>().ImplementedBy<InMemoryRepository>().LifestylePerWebRequest());
        }
    }
}