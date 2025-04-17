using Microsoft.EntityFrameworkCore;
using StaffSkill.Core.Model;

namespace StaffSkill.Repository
{
    public class PersonRepository: IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetAllAsync() =>
            await _context.Persons.Include(p => p.Skills).ToListAsync();

        public async Task<Person?> GetByIdAsync(long id) =>
            await _context.Persons.Include(p => p.Skills).FirstOrDefaultAsync(p => p.Id == id);

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

        public async Task DeleteAsync(long id)
        {
            var person = await GetByIdAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}

