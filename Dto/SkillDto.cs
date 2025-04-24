using System.ComponentModel.DataAnnotations;

namespace StaffSkill.Dto
{
    public class SkillDto
    {

        [Required(ErrorMessage = "Название навыка обязательно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Название навыка должно быть от 2 до 50 символов")]
        public string Name { get; set; }

        [Range(1,10,ErrorMessage ="Уровень навыка должен быть от 1 до 10")]
        public byte Level { get; set; }
    }
}
