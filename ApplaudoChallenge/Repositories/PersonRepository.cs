using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplaudoChallenge.Models;

namespace ApplaudoChallenge.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> _persons;

        public PersonRepository()
        {
            _persons = new List<Person>()
            {
                new Person()
                {
                    Id = 1,
                    FirstName = "first name 1",
                    LastName = "last name 1",
                    Disabled = false
                },
                new Person()
                {
                    Id = 2,
                    FirstName = "first name 1",
                    LastName = "last name 1",
                    Disabled = false
                },
                new Person()
                {
                    Id = 3,
                    FirstName = "first name 1",
                    LastName = "last name 1",
                    Disabled = false
                }
            };
        }

        public IEnumerable<Person> All()
        {
            return _persons;
        }

        public Person FindById(int id)
        {
            return _persons.FirstOrDefault(p => p.Id == id);
        }

        public Person Add(Person person)
        {
            person.Id = _persons.Max(p => p.Id) + 1;
            _persons.Add(person);
            return person;
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
