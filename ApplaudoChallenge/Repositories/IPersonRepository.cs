using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplaudoChallenge.Models;

namespace ApplaudoChallenge.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> AllAsync();
        Task<Person> FindByIdAsync(int id);
        Task AddAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Person person);
    }
}
