//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.GreetV3Dto.cs
// 2017/09/22
//  --------------------------------------------------------------------------------------

using System;
using AspNet.WebApi.Example.Controllers.V1.Models;

namespace AspNet.WebApi.Example.Models
{
    public class GreetV3Dto : GreetDto
    {
        public DateTime BirthDate { get; set; }
    }
}