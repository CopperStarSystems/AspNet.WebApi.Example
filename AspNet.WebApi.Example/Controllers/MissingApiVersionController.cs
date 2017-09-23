//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.MissingApiVersionController.cs
// 2017/09/22
//  --------------------------------------------------------------------------------------

using System.Web.Http;

namespace AspNet.WebApi.Example.Controllers
{
    public class MissingApiVersionController : ApiController
    {
        public string Get()
        {
            // When clients hit GET /api/MissingApiVersionController/
            // they will get a response with status 400 bad request because
            // this controller is un-versioned.
            return "This value will not be returned because this controller lacks an ApiVersion attribute.";
        }
    }
}