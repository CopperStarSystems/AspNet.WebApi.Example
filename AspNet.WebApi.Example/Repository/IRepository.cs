//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.IRepository.cs
// 2017/09/23
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using AspNet.WebApi.Example.Models;

namespace AspNet.WebApi.Example.Repository
{
    public interface IRepository
    {
        IList<Person> People { get; }
    }
}