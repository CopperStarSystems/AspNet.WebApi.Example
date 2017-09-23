//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.WindsorDependencyResolver.cs
// 2017/09/23
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.Windsor;

namespace AspNet.WebApi.Example.WindsorIntegration
{
    public class WindsorDependencyResolver : IDependencyResolver
    {
        readonly IWindsorContainer container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(container);
        }

        public void Dispose()
        {
            container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return container.Kernel.HasComponent(serviceType) ? container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (!container.Kernel.HasComponent(serviceType))
                return new object[0];

            return container.ResolveAll(serviceType).Cast<object>();
        }
    }
}