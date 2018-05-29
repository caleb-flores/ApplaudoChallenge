using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplaudoChallenge.Data;
using ApplaudoChallenge.Extensions;
using ApplaudoChallenge.Models;
using ApplaudoChallenge.QueryResource;
using Microsoft.EntityFrameworkCore;

namespace ApplaudoChallenge.Repositories
{
    public class PersonRepository :IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<QueryResult<Person>> AllAsync(QueryPerson filter)
        {
            var query = _context.Persons.AsQueryable();

            if (!string.IsNullOrEmpty(filter.First))
            {
                query = query.Where(p => p.FirstName.ToUpper().StartsWith(filter.First.ToUpper()));
            }
            if (!string.IsNullOrEmpty(filter.Last))
            {
                query = query.Where(p => p.LastName.ToUpper().StartsWith(filter.Last.ToUpper()));
            }

            var filterMap = new Dictionary<string, Expression<Func<Person, object>>>()
            {
                ["first"] = p => p.FirstName,
                ["last"] = p => p.LastName,
                ["id"] = p => p.Id
            };


            return new QueryResult<Person>()
            {
                TotalItems = await query.CountAsync(),
                Items = await query
                    .OrderBy(filter, filterMap)
                    .Paginate(filter)
                    .ToListAsync()
            };
        }

        public async Task<Person> FindByIdAsync(int id)
        {
            return await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Person person)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
