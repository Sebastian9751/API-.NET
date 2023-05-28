using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PostPersona
    {

        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        [Required]
        public string Lastname { get; set; }
        [StringLength(15)]
        public string CURP { get; set; }
        [StringLength(13)]
        public string RFC { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public int idArea { get; set; }

        public int NumEmpleado { get; set; }

        public int ItemId { get; set; }
    }
}
