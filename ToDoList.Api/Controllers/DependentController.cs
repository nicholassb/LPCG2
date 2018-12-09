using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.API.DTOs;
using ToDoList.Domain;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.API.Controllers
{   
     [Route("api/[controller]")]
    public class DependentController : ControllerBase
    {
        private readonly IDependentRepository repository;
        public DependentController(IDependentRepository repository){
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<DependentDTO> Get()
        {
            var dep = this.repository.GetAll();
            var depList = new List<DependentDTO>();

            dep.ForEach(item => {
                depList.Add(
                    new DependentDTO{
                        id = item.id, 
                        name = item.name,
                        kinship = item.kinshipid.ToString(),
                        birthDate = item.birthDate,
                        associatedid = item.associatedid
                    }
                );
            });

            return depList;
        }

        [HttpGet("{id}")]
        public async Task<Dependent> Get(int id)
        {
            return await this.repository.GetByIdAsync(id);
        }

        // POST api/Todos
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody]Dependent item)
        {
            //caso nao grave
            if (ModelState.IsValid)
            {       
                    this.repository.Create(item);
                    return Ok(item);
            }
            else
            {
                //ARRAY STRINGS ERROS
                var errors = new List<string>();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                return BadRequest(new {
                    code = 401,
                    message = errors
                });
            }
        }

        // PUT api/Todos/
        [Authorize]
        [HttpPut]
        public IActionResult Put([FromBody]Dependent item)
        {
            this.repository.Update(item);
            return Ok(item);
        }

        // DELETE api/Todos/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.repository.Delete(id);
            return Ok(new {
                message = "Deletado com sucesso.",
                id = id
            });
        }
    }
}