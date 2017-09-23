//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.WindsorControllerActivator.cs
// 2017/09/23
//  --------------------------------------------------------------------------------------

using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace AspNet.WebApi.Example.WindsorIntegration
{
    public class WindsorControllerActivator : IHttpControllerActivator
    {
        readonly IWindsorContainer container;

        public WindsorControllerActivator(IWindsorContainer container)
        {
            this.container = container;
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller = (IHttpController) container.Resolve(controllerType);

            request.RegisterForDispose(new Release(() => container.Release(controller)));

            return controller;
        }

        sealed class Release : IDisposable
        {
            readonly Action _release;

            public Release(Action release)
            {
                _release = release;
            }

            public void Dispose()
            {
                _release();
            }
        }
    }
}