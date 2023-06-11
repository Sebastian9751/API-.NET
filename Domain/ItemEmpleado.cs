using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ItemEmpleado
    {
        public Persona Persona { get; set; }
        public List<Items> Items { get; set; }
    }
}
