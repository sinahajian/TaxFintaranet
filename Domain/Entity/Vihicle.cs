using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Vihicle
    {
        public string Model { get; set; }
        public bool TaxtFree { get; set; } = false;
        public int TaxtAmount { get; set; } = 1;
    }
}
