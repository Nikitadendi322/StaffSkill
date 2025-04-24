using System.ComponentModel.DataAnnotations;

namespace StaffSkill.Core.Model
{
    public class Person
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        
        public long Id { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        
        public required string Name { get; set; }

        /// <summary>
        /// Отображаемое имя
        /// </summary>
        
        public string DisplayName { get; set; }

        /// <summary>
        /// Список навыков сотрудника
        /// </summary>
        public List<Skill>? Skills { get; set; } = new();
    }
}
