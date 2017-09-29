//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.GreetV3Controller.cs
// 2017/09/22
//  --------------------------------------------------------------------------------------

using System;
using System.Web.Http;
using AspNet.WebApi.Example.Models;
using AspNet.WebApi.Example.Repository;
using Microsoft.Web.Http;

namespace AspNet.WebApi.Example.Controllers
{
    // I put this class outside the V1/V2 folders to illustrate
    // that the folder hierarchy is unimportant, it's more important
    // that we specify the RouteAttribute correctly.
    [ApiVersion("3")]
    [RoutePrefix("api/v{version:apiVersion}/greet")]
    public class GreetV3Controller : ApiController
    {
        // Breaking change:  Different return type, additional optional parameters, RESTful Route
        [Route("{userName}/{birthDate?}")]
        public GreetV3Dto Get(string userName, DateTime? birthDate = default(DateTime?))
        {
            var result = new GreetV3Dto
                         {
                             Greeting = $"Hello {userName}",
                             BirthDate = birthDate ?? DateTime.MinValue,
                             Version = 3
                         };

            return result;
        }
    }
}