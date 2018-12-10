using System.Collections.Generic;
using ToDoList.Domain;

namespace ToDoList.Api.DTOs
{
    public class AssociatedDTO
    {
        public int id { get; set; }
        public string name { get; set; }      
        public string cpf { get; set; }        
        public string email { get; set; }
        public List<Dependent> dependents {get; set;}

    }
}