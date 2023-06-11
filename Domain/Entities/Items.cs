using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Items")]
    public class Items
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string NombreItem { get; set; }

        public string Description { get; set; }
        public bool status { get; set; }
    }
}
