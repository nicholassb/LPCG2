using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository repository;
        public StatusController(IStatusRepository repository){
            this.repository = repository;
        }
        // GET api/todos
        [HttpGet]
        public IEnumerable<MaritalStatus> Get()
        {
            var ms = this.repository.GetAll();
            var msList = new List<MaritalStatus>();

            ms.ForEach(item => {
                msList.Add(
                    new MaritalStatus{
                        id = item.id, 
                        status = item.status
                    }
                );
            });

            return msList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public MaritalStatus Get(int id)
        {
            return this.repository.GetById(id);
        }

        // POST api/Todos
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody]MaritalStatus item)
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
        public IActionResult Put([FromBody]MaritalStatus item)
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