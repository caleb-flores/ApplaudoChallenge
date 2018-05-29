using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplaudoChallenge.Data;
using ApplaudoChallenge.Models;

namespace ApplaudoChallenge.Repositories
{
    public class PersonRepository :IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> All()
        {
            return _context.Persons;
        }

        public Person FindById(int id)
        {
            return _context.Persons.FirstOrDefault(x => x.Id == id);
        }

        public Person Add(Person person)
        {
             _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }

        public Person Update(Person person)
        {
            _context.Persons.Update(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(int id)
        {
            var person = _context.Persons.FirstOrDefault(x => x.Id == id);
            _context.Persons.Remove(person);
        }
    }
}
