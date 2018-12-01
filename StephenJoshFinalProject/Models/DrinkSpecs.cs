using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephenJoshFinalProject.Models
{
    public class DrinkSpecs
    {
        public int DrinkSpecsId { get; set; }
        public bool Tall { get; set; }
        public bool Grande { get; set; }
        public bool Iced { get; set; }
        public bool Hot { get; set; }
        public bool Frozen { get; set; }
        public int Quantity { get; set; }
        public string SpecialRequests { get; set; }
    }
}
