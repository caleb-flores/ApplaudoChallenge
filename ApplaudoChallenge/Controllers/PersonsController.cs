using System.Collections.Generic;
using System.Threading.Tasks;
using ApplaudoChallenge.Models;
using ApplaudoChallenge.Repositories;
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
        public async Task<IEnumerable<Person>> Get()
        {
            return await _repo.AllAsync();
        }

        // GET: api/Persons/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(200,Type = typeof(Person))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            var person = await _repo.FindByIdAsync(id);
            return (person == null)? (IActionResult) NotFound(): Ok(person);
        }
        
        // POST: api/Persons
        [HttpPost]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody]Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _repo.AddAsync(person);
            return CreatedAtAction(nameof(Get),new
            {
                id = person.Id
            },person);
        }
        
        // PUT: api/Persons/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Put(int id, [FromBody]Person modify)
        {
            var person = await _repo.FindByIdAsync(id);
            if (person == null)
                return NotFound();
            person.FirstName = modify.FirstName;
            person.LastName = modify.LastName;
            person.Disabled = modify.Disabled;
            await _repo.UpdateAsync(person);
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _repo.FindByIdAsync(id);
            if (person == null)
                return NotFound();
            await _repo.DeleteAsync(person);
            return NoContent();
        }
    }
}
