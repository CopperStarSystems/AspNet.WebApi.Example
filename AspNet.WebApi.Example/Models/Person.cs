//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.Person.cs
// 2017/09/23
//  --------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace AspNet.WebApi.Example.Models
{
    public class Person
    {
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        public int Id { get; set; }

        public string LastName { get; set; }
    }
}