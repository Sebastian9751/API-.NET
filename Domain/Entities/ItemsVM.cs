using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ItemsVM
    {

        public int id_persona { get; set; }
        
        public int NumEmpleado { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }

    }
}
