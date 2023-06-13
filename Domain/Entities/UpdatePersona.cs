using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UpdatePersona
    {
      
        public int Id { get; set; }
      
   
        public string Name { get; set; }
 
        public string Lastname { get; set; }
   
        public string CURP { get; set; }
    
        public string RFC { get; set; }

        public string email { get; set; }

        public int numero_empleado { get; set; }

        public DateTime FechaNacimiento { get; set; }

   
    }
}
