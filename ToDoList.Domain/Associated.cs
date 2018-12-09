using System;
using System.Collections.Generic;

namespace ToDoList.Domain
{
    public class Associated
    {
        public int id { get; set; }

        [Required(ErrorMessage="Defina um estado civil.",AllowEmptyStrings=false)]
        public int maritalstatusid { get; set; }
        public string name { get; set; }      
        public string cpf { get; set; } 
        public string dateJoin { get; set; } 
        public string adress { get; set; }
        public string city { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
        public string email { get; set; }
        public string birthDate { get; set; }

        public MaritalStatus maritalStatus { get; set;}

        public List<Dependent> depentents {get; set;}
    }

    internal class RequiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
        public bool AllowEmptyStrings { get; set; }
    }
}