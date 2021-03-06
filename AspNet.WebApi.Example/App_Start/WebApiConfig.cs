﻿//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.WebApiConfig.cs
// 2017/09/22
//  --------------------------------------------------------------------------------------

using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using AspNet.WebApi.Example.WindsorIntegration;
using Castle.Windsor;
using Microsoft.Web.Http.Routing;

namespace AspNet.WebApi.Example
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config, IWindsorContainer container)
        {
            MapRoutes(config);
            RegisterControllerActivator(container);
            ConfigureApiVersioning(config);
            ConfigureDefaultRoute(config);
        }

        static void ConfigureApiVersioning(HttpConfiguration config)
        {
            config.AddApiVersioning();
        }

        static void ConfigureDefaultRoute(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});
        }

        static void MapRoutes(HttpConfiguration config)
        {
            // Configure Web API routes
            // The ConstraintResolver lets us specify certain things about the route.
            //
            // The specific constraint here is that all routes must have an ApiVersionAttribute
            // and that value is required.  If it is not supplied (i.e. GET /api/[controller]/[action] 
            // instead of GET /api/v[version]/[controller]/[action]), the request will fail with a message
            // indicating that the version is required.
            //
            // See https://github.com/Microsoft/aspnet-api-versioning/blob/master/src/Microsoft.AspNetCore.Mvc.Versioning/Routing/ApiVersionRouteConstraint.cs
            // for details on how ApiVersionRouteConstraint functions.
            var constraintResolver =
                new DefaultInlineConstraintResolver
                {
                    ConstraintMap =
                    {
                        ["apiVersion"] =
                        typeof(ApiVersionRouteConstraint)
                    }
                };
            config.MapHttpAttributeRoutes(constraintResolver);
        }

        static void RegisterControllerActivator(IWindsorContainer container)
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
                                                               new WindsorControllerActivator(container));
        }
    }
}