using System.Collections.Generic;
using System.Threading.Tasks;
using ApplaudoChallenge.Data;
using ApplaudoChallenge.Models;
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

        public async Task<IEnumerable<Person>> AllAsync()
        {
            return await _context.Persons.ToListAsync();
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
