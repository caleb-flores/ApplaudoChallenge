using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplaudoChallenge.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
           var index= _persons.FindIndex(p => p.Id == person.Id);
            if (index != -1)
                _persons[index] = person;
            else
            {
                //TODO: Make a custom error
                throw new Exception("Item does not exists");
            }
            return person;
        }

        public void Delete(int id)
        {
            var index = _persons.FindIndex(p => p.Id == id);
            if (index == -1)
            {
                throw new Exception("Item does not exists");
            }
            _persons.RemoveAt(index);
        }
    }
}
