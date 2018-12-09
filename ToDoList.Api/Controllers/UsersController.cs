using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.API.DTOs;
using ToDoList.Domain;
using ToDoList.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Linq;
using ToDoList.Repositories;

namespace ToDoList.API.Controllers
{   
    
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository repository;
        public UsersController(IUserRepository repository){
            this.repository = repository;
        }
        // GET api/todos
        [Authorize]
        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            var users = this.repository.GetAll();
            var usersDTO = new List<UserDTO>();

            users.ForEach(usuario => {
                usersDTO.Add(
                    new UserDTO{
                        id = usuario.id, 
                        name = usuario.name
                    }
                );
            });

            return usersDTO;

            // var users = this.repository.GetAll();
            // List<UserDTO> usersDTo = new List<UserDTO>();    
            // foreach (var item in users)
            // {
            //     var objDTO = new UserDTO
            //     {
            //          id = item.id,
            //          name = item.name
            //     };
            //     usersDTo.Add(objDTO);
            // }

            // return usersDTo;
        }

        // GET api/values/5
        [Authorize]
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return this.repository.GetById(id);
        }

        // POST api/Todos
        [HttpPost]
        public IActionResult Post([FromBody]User item)
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
        public IActionResult Put([FromBody]User item)
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

        [HttpPost("authenticate")]
        public IActionResult Authentication([FromBody] User user)
        {
            var usuario = this.repository.AuthUser(user);

            if(usuario == null)
                return BadRequest(new {
                    message = "Login e/ou senha incorreto(s)."
                });

            return Ok(new {
                token = BuildToken()
            });
        }

        public string BuildToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Aula15UlbraTorres"));
            
            var creed = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                audience: "Aula15",
                issuer: "Aula15",
                signingCredentials: creed
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}