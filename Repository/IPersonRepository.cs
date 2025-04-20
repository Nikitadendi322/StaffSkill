using StaffSkill.Core.Model;

namespace StaffSkill.Repository
{
    public interface IPersonRepository
    {
        /// <summary>
        /// Получает список всех сотрудников с их навыками
        /// </summary>
        Task<List<Person>> GetAllAsync();

        /// <summary>
        /// Находит сотрудника по идентификатору
        /// </summary>
        Task<Person?> GetByIdAsync(long id);

        /// <summary>
        /// Добавляет нового сотрудника в систему
        /// </summary>
        Task AddAsync(Person person);

        /// <summary>
        /// Обновляет данные существующего сотрудника
        /// </summary>
        Task UpdateAsync(Person person);

        /// <summary>
        /// Удаляет сотрудника по идентификатору
        /// </summary>
        Task DeleteAsync(long id);
    }
}
