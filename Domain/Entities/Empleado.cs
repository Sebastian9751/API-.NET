using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empleado :Persona
    {
        [Required]
        public int NumEmpleado { get; set; }
        
        public string nombreEmpleado { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual Items Item { get; set; }
        

    }
}
