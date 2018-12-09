using System;
using System.Collections.Generic;
namespace ToDoList.Domain
{
    public class Dependent
    {
        public int id { get; set; }
        [Required(ErrorMessage="Defina um associado.",AllowEmptyStrings=false)]
        public int associatedid { get; set; }
        [Required(ErrorMessage="Defina um parentesco com o associado.",AllowEmptyStrings=false)]
        public int kinshipid { get; set; }
        public string name { get; set; }      
        public string birthDate { get; set; }
        public KinShip kinShip {get; set;}
        public Associated associated { get; set;}
    }
}