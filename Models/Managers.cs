using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepartmentEFMvc.Models
{
    public class Managers
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public int Salary { get; set; }
        public int AmountOfEmployees { get; set; }
        public string Department { get; set; }
    }
}
