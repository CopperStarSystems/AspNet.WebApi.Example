//  --------------------------------------------------------------------------------------
// AspNet.WebApi.Example.PersonController.cs
// 2017/09/29
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AspNet.WebApi.Example.Filters;
using AspNet.WebApi.Example.Repository;
using Microsoft.Web.Http;

namespace AspNet.WebApi.Example.Controllers.Person
{
    [ApiVersion("1")]
    [RoutePrefix("api/v{version:apiVersion}/person")]
    public class PersonController : ApiController
    {
        readonly IRepository repository;

        public PersonController(IRepository repository)
        {
            this.repository = repository;
        }

        // DELETE: api/Person/5
        [Route("{id}")]
        public void Delete(int id)
        {
            var itemToDelete = repository.People.FirstOrDefault(p => p.Id == id);
            if (itemToDelete == null)
            {
                var message = $"No record matching id = {id} found.";
                SendErrorResponse(HttpStatusCode.NotFound, message);
                return;
            }
            repository.People.Remove(itemToDelete);
            ActionContext.Response = ActionContext.Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // GET: api/Person
        public IEnumerable<Models.Person> Get()
        {
            return repository.People;
        }

        // GET: api/Person/5
        public IHttpActionResult Get(int id)
        {
            var result = repository.People.FirstOrDefault(p => p.Id == id);
            if (result == null)
                return NotFound();
            return Json(result);
        }

        // POST: api/Person
        [ValidateModel] // Custom filter for validating model
        public void Post([FromBody] Models.Person person)
        {
            var existingPerson = repository.People.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                var message = $"A record with id {person.Id} already exists.";
                SendErrorResponse(HttpStatusCode.Conflict, message);
                return;
            }

            if (person.Id == 0)
            {
                if (repository.People.Count == 0)
                    person.Id = 1;
                else
                    person.Id = repository.People.Max(p => p.Id) + 1;
            }
                

            repository.People.Add(person);
            //ActionContext.Response = ActionContext.Request.CreateResponse(HttpStatusCode.Created);
            SendSuccessResponse(HttpStatusCode.Created);
            var locationUri = $"{ActionContext.Request.RequestUri}/{person.Id}";
            ActionContext.Response.Headers.Location = new Uri(locationUri);
        }

        // PUT: api/Person/5
        [ValidateModel, Route("{id}")]
        public void Put(int id, [FromBody] Models.Person person)
        {
            var existingPerson = repository.People.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson == null)
            {
                var message = $"No records found for id {person.Id}.";
                SendErrorResponse(HttpStatusCode.NotFound, message);
                return;
            }
            repository.People.Remove(existingPerson);
            SendSuccessResponse(HttpStatusCode.NoContent);
        }

        void SendErrorResponse(HttpStatusCode statusCode, string message)
        {
            ActionContext.Response = ActionContext.Request.CreateErrorResponse(statusCode, message);
        }

        void SendSuccessResponse(HttpStatusCode statusCode)
        {
            ActionContext.Response = ActionContext.Request.CreateResponse(statusCode);
        }
    }
}