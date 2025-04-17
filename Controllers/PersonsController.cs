using Microsoft.AspNetCore.Mvc;
using StaffSkill.Core.Model;
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
        /// <param name="id">Уникальный индетификатор сотрудника</param>
        /// <returns></returns>
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
        public async Task<ActionResult<Person>> Create(Person person)
        {
            await _repository.AddAsync(person);
            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }
        /// <summary>
        /// Обновляет данные сотрудника согласно значениям, указанным в объекте Person в теле.
        /// Обновляет навыки сотрудника согласно указанному набору.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Person person)
        {
            if (id != person.Id)
                return BadRequest();

            await _repository.UpdateAsync(person);
            return NoContent();
        }
        /// <summary>
        /// Удаляет с указанным id сотрудника из системы.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
