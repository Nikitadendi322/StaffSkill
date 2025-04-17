using StaffSkill.Core.Model;

namespace StaffSkill.Repository
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllAsync();
        Task<Person?> GetByIdAsync(long id);
        Task AddAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(long id);
    }
}
