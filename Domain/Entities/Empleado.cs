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
        
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual Items Item { get; set; }
        

    }
}
