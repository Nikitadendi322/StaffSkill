using System.ComponentModel.DataAnnotations;

namespace StaffSkill.Core.Model
{
    public class Skill
    {
        /// <summary>
        /// Название навыка
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор навыка
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Уровень владения навыком (от 1 до 10)
        /// </summary>
        public byte Level { get; set; } // 1-10

        /// <summary>
        /// Внешний ключ для связи с сотрудником
        /// </summary>
        public long PersonId { get; set; }
        
    }
}
