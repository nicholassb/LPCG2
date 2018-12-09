using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    public class KinShipController : ControllerBase
    {
        private readonly IKinShipRepository repository;
        public KinShipController(IKinShipRepository repository){
            this.repository = repository;
        }
        // GET api/todos
        [HttpGet]
        public IEnumerable<KinShip> Get()
        {
            var ks = this.repository.GetAll();
            var ksList = new List<KinShip>();

            ks.ForEach(item => {
                ksList.Add(
                    new KinShip{
                        id = item.id, 
                        status = item.status
                    }
                );
            });

            return ksList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public KinShip Get(int id)
        {
            return this.repository.GetById(id);
        }

        // POST api/Todos
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody]KinShip item)
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
        public IActionResult Put([FromBody]KinShip item)
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