//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.GreetController.cs
// 2017/09/22
//  --------------------------------------------------------------------------------------

using System.Web.Http;
using AspNet.WebApi.Example.Models;

namespace AspNet.WebApi.Example.Controllers.V1
{
    public class GreetController : ApiController
    {
        public GreetDto Get()
        {
            var data = new GreetDto {Version = 1, Greeting = "Hello Web API!"};
            return data;
        }
    }
}