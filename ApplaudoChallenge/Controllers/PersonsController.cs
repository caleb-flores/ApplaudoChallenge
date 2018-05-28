using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ApplaudoChallenge.Models;
using ApplaudoChallenge.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplaudoChallenge.Controllers
{
    [Produces("application/json")]
    [Route("api/Persons")]
    public class PersonsController : Controller
    {
        private readonly IPersonRepository _repo;
        public PersonsController(IPersonRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Persons
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Person>))]
        public IEnumerable<Person> Get()
        {
            return _repo.All();
        }

        // GET: api/Persons/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(200,Type = typeof(Person))]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            var person = _repo.FindById(id);
            return (person == null)? (IActionResult) NotFound(): Ok(person);
        }
        
        // POST: api/Persons
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            person = _repo.Add(person);
            return CreatedAtAction(nameof(Get),new
            {
                id = person.Id
            },person);
        }
        
        // PUT: api/Persons/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
