//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.GreetDto.cs
// 2017/09/22
//  --------------------------------------------------------------------------------------

namespace AspNet.WebApi.Example.Controllers.V1.Models
{
    // This represents the V1 DTO implementation.
    // The same DTO is used by V2, then changed for V3.
    public class GreetDto
    {
        public string Greeting { get; set; }

        public int Version { get; set; }
    }
}