using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain;
using ToDoList.Repositories;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public readonly Repositories.Interfaces.IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = _userRepository;
        }


        // GET api/todos
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return this._userRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return this._userRepository.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]User item)
        {
            this._userRepository.Create(item);
            return Ok(item);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]User item)
        {
            this._userRepository.Update(item);
            return Ok(item);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._userRepository.Delete(id);
            return Ok(new {
                message = "Deletado com sucesso.",
                id = id
            });
        }


    }
}