using Microsoft.AspNetCore.Mvc;
using StaffSkill.Core.Model;
using StaffSkill.Dto;
using StaffSkill.Repository;

namespace StaffSkill.Service
{
    public class PersonService: IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Person>> GetAll()
        {
            var persons = await _repository.GetAllAsync();
            return persons;
        }

        public async Task<Person?>GetById(long id)
        {
            var person = await _repository.GetByIdAsync(id);
            return person;
        }

        public async Task<Person>Create(PersonDto personDto)
        {
            
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
            return person;
        }

        public async Task<Person?>Update(long id, PersonDto personDto)
        {
            var person = await _repository.GetByIdAsync(id);
            if (person == null)
            {
                return person;
            }
            {
                person.Name = personDto.Name;
                person.DisplayName = personDto.DisplayName;

                // Обновление Skills
                person.Skills = personDto.Skills.Select(s => new Skill
                {
                    Name = s.Name,
                    Level = s.Level,
                    PersonId = id
                }).ToList();
            };

            await _repository.UpdateAsync(person);

            return person;
        }

        public async Task<bool> Delete(long id)
        {
            {
                var person = await _repository.GetByIdAsync(id);
                if (person == null) return false;

                await _repository.DeleteAsync(id);
                return true;
            }
        }
        
    }
}

