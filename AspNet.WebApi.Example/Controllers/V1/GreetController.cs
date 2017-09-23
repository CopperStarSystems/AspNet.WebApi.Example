//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.GreetController.cs
// 2017/09/22
//  --------------------------------------------------------------------------------------

using System.Web.Http;
using AspNet.WebApi.Example.Controllers.V1.Models;
using Microsoft.Web.Http;

namespace AspNet.WebApi.Example.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/greet")]
    public class GreetController : ApiController
    {
        public GreetDto Get()
        {
            var data = new GreetDto {Version = 1, Greeting = "Hello Web API!"};
            return data;
        }
    }
}