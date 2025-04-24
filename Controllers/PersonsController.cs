using Microsoft.AspNetCore.Mvc;
using StaffSkill.Core.Model;
using StaffSkill.Dto;
using StaffSkill.Service;

namespace StaffSkill.Controllers
{
    [ApiController]
    [Route("api/v1/persons")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonsController(IPersonService service)
        {
            _service = service;
        }

        /// <summary>
        /// Возвращение массив обектов типа Person
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAll()
        {
            var persons = await _service.GetAll();
            return Ok(persons);
        }

        /// <summary>
        /// Возвращает объект типа Person.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(long id)
        {
            var person = await _service.GetById(id);
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

            var person = await _service.Create(personDto);

            // Возвращаем созданную сущность Person
            return CreatedAtAction(nameof(Create), new { id = person.Id }, person);
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

            var person = await _service.Update(id, personDto);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        /// <summary>
        /// Удаляет с указанным id сотрудника из системы.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            {
                var isDeleted = await _service.Delete(id);

                if (isDeleted)
                {
                    return NoContent();
                }

                return NotFound();
            }
        }
    }

}
