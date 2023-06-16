using Domain.Entities;
using Repository.DAO;
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

        public List<ItemEmpleadoDetail> ItemEmpleadoDetail { get; set; }
    }
}
