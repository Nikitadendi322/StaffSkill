using System.ComponentModel.DataAnnotations;

namespace StaffSkill.Dto
{
    public class PersonDto
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 100 символов")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Отображаемое имя не должно превышать 100 символов")]
        public string DisplayName { get; set; }

        public List<SkillDto> Skills { get; set; } = new();
    }
}
