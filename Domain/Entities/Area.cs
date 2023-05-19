using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table  ("Aareas")]
    public class Area
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }

    }
}
