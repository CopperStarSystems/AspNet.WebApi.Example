//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.GreetController.cs
// 2017/09/22
//  --------------------------------------------------------------------------------------

using System.Web.Http;
using AspNet.WebApi.Example.Controllers.V1.Models;
using AspNet.WebApi.Example.Models;
using Microsoft.Web.Http;

namespace AspNet.WebApi.Example.Controllers.V2
{
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/greet")]
    public class GreetController : ApiController
    {
        // By providing a default value, we make this parameter optional.
        //
        // If instead the signature were Get(string userName), the userName parameter would
        // be required.
        public GreetDto Get(string userName="Unspecified User")
        {
            var result = new GreetDto {Version = 2, Greeting = $"Hello {userName}."};
            return result;
        }
    }
}