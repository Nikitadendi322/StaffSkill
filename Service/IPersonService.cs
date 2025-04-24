using StaffSkill.Core.Model;
using StaffSkill.Dto;

namespace StaffSkill.Service
{
    public interface IPersonService
    {
        Task<List<Person>> GetAll();
        
        /// <summary>
        /// Возвращает объект типа Person.
        /// </summary>
        Task<Person?> GetById(long id);
        
        /// <summary>
        /// Создаёт нового сотрудника в системе с указанными навыками.
        /// </summary>
        Task<Person> Create(PersonDto personDto);

        /// <summary>
        /// Обновляет данные сотрудника согласно значениям, указанным в объекте Person в теле.
        /// Обновляет навыки сотрудника согласно указанному набору.
        /// </summary>
        Task<Person?> Update(long id, PersonDto personDto);
        
        /// <summary>
        /// Удаляет с указанным id сотрудника из системы.
        /// </summary>
        Task<bool> Delete(long id);
    }
}
