//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.AcceptHeaderExampleController.cs
// 2017/09/22
//  --------------------------------------------------------------------------------------

using System.Web.Http;
using AspNet.WebApi.Example.Models;

namespace AspNet.WebApi.Example.Controllers
{
    public class AcceptHeaderExampleController : ApiController
    {
        // GET /api/AcceptHeaderExample
        public AcceptHeaderExampleDto Get()
        {
            // This method will return the DTO in JSON format by default.
            // If the Accept header is set to "text/xml", it will return the DTO 
            // in XML format.
            var model = new AcceptHeaderExampleDto {Name = "Some Name", Address = "Some Address"};
            return model;
        }
    }
}