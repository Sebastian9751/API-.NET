using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    [Table("Asignaciones")]
    public class Asignaciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [ForeignKey("Persona")]
        public int id_persona { get; set; }
        [Required]
        [ForeignKey("Items")]
        public int id_item { get; set; }
        public DateTime dia_asignacion { get; set; }
        public DateTime dia_entrega { get; set; }
        public DateTime dia_liberacion { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual Items Items { get; set; }
    }

}
