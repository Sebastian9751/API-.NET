using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmpleadosVM
    {
        public string  Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public int NumEmpleado { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }

    }
}
