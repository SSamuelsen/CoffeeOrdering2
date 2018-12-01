using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephenJoshFinalProject.ViewModels
{
    public class OrderPageViewModel
    {
        public bool Americano { get; set; }
        public bool Carmelo { get; set; }
        public bool Nova { get; set; }
        public bool HotChocolate { get; set; }
        public bool Tea { get; set; }
        public bool LondonFog { get; set; }
        public bool Tall { get; set; }
        public bool Grande { get; set; }
        public bool Iced { get; set; }
        public bool Hot { get; set; }
        public bool Frozen { get; set; }
        public double OrderTotal { get; set; }
        public int Quantity { get; set; }

        public DateTime PickUpTime { get; set; }

        public string SpecialRequest { get; set; }

    }
}
