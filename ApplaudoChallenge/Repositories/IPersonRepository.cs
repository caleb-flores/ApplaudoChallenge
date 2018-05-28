using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplaudoChallenge.Models;

namespace ApplaudoChallenge.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> All();
        Person FindById(int id);
        Person Add(Person person);
        Person Update(Person person);
        void Delete(int id);
    }
}
