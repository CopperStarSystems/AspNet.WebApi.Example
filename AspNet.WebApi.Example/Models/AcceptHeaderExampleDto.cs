//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.AcceptHeaderExampleDto.cs
// 2017/09/22
//  --------------------------------------------------------------------------------------

using System;

namespace AspNet.WebApi.Example.Models
{
    [Serializable]
    public class AcceptHeaderExampleDto
    {
        public string Address { get; set; }

        public string Name { get; set; }
    }
}