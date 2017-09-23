//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.WindsorDependencyScope.cs
// 2017/09/23
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace AspNet.WebApi.Example.WindsorIntegration
{
    public class WindsorDependencyScope : IDependencyScope
    {
        readonly IWindsorContainer container;
        readonly IDisposable scope;

        public WindsorDependencyScope(IWindsorContainer container)
        {
            this.container = container;
            scope = container.BeginScope();
        }

        public void Dispose()
        {
            scope.Dispose();
        }

        public object GetService(Type serviceType)
        {
            if (container.Kernel.HasComponent(serviceType))
                return container.Resolve(serviceType);
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.ResolveAll(serviceType).Cast<object>();
        }
    }
}