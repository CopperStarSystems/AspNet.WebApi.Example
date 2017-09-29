//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.InMemoryRepository.cs
// 2017/09/23
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using AspNet.WebApi.Example.Models;

namespace AspNet.WebApi.Example.Repository
{
    public class InMemoryRepository : IRepository
    {
        public InMemoryRepository()
        {
            People = new List<Person>();
        }
        public IList<Person> People { get; }
    }
}