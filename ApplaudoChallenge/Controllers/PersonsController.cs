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
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
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
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult Put(int id, [FromBody]Person modify)
        {
            var person = _repo.FindById(id);
            if (person == null)
                return NotFound();
            person.FirstName = modify.FirstName;
            person.LastName = modify.LastName;
            person.Disabled = modify.Disabled;
            _repo.Update(person);
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public IActionResult Delete(int id)
        {
            var person = _repo.FindById(id);
            if (person == null)
                return NotFound();
            _repo.Delete(person.Id);
            return NoContent();
        }
    }
}
