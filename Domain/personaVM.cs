using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PersonaVM : Persona
    {
        public int NumEmpleado { get; set; }
        public string nombreEmpleado { get; set;}
        public int idArea { get; set;}

    }
}