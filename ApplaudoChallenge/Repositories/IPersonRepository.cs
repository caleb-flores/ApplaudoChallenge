using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplaudoChallenge.Models;
using ApplaudoChallenge.QueryResource;

namespace ApplaudoChallenge.Repositories
{
    public interface IPersonRepository
    {
        Task<QueryResult<Person>> AllAsync(QueryPerson filter);
        Task<Person> FindByIdAsync(int id);
        Task AddAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Person person);
    }
}
