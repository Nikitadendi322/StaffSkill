using Microsoft.AspNetCore.Mvc;
using StaffSkill.Core.Model;
using StaffSkill.Dto;
using StaffSkill.Repository;

namespace StaffSkill.Controllers
{
    [ApiController]
    [Route("api/v1/persons")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonsController(IPersonRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Возвращение массив обектов типа Person
        /// </summary>

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAll()
        {
            var persons = await _repository.GetAllAsync();
            return Ok(persons);
        }

        /// <summary>
        /// Возвращает объект типа Person.
        /// </summary>

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(long id)
        {
            var person = await _repository.GetByIdAsync(id);
            return person != null ? Ok(person) : NotFound();
        }

        /// <summary>
        /// Создаёт нового сотрудника в системе с указанными навыками.
        /// </summary>

        [HttpPost]
        public async Task<ActionResult<PersonDto>> Create(PersonDto personDto)
        {
            if (!ModelState.IsValid) // Проверка валидации DTO
            {
                return BadRequest(ModelState);
            }

            var person = new Person
            {
                Name = personDto.Name,
                DisplayName = personDto.DisplayName,
                Skills = personDto.Skills.Select(s => new Skill
                {
                    Name = s.Name,
                    Level = s.Level
                }).ToList()
            };

            await _repository.AddAsync(person);

            // Возвращаем созданную сущность Person
            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

        /// <summary>
        /// Обновляет данные сотрудника согласно значениям, указанным в объекте Person в теле.
        /// Обновляет навыки сотрудника согласно указанному набору.
        /// </summary>

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, PersonDto personDto)
        {
            if (!ModelState.IsValid) // Проверка валидации DTO
            {
                return BadRequest(ModelState);
            }

            var existingPerson = await _repository.GetByIdAsync(id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            //Обновление только разрешенного поля

            existingPerson.Name = personDto.Name;
            existingPerson.DisplayName = personDto.DisplayName;

            // Обновление Skills

            existingPerson.Skills = personDto.Skills.Select(s => new Skill
            {
                Name = s.Name,
                Level = s.Level,
                PersonId = id
            }).ToList();

            await _repository.UpdateAsync(existingPerson);

            return Ok(existingPerson);
        }

        /// <summary>
        /// Удаляет с указанным id сотрудника из системы.
        /// </summary>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            {
                // Проверяем существование человека
                var person = await _repository.GetByIdAsync(id);
                if (person == null)
                {
                    return NotFound($"Человек с ID {id} не найден");
                }

                // Если человек найден - удаляем
                await _repository.DeleteAsync(id);
                return NoContent();
            }
        }
    }

}
