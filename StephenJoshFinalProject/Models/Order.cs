using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephenJoshFinalProject.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public double OrderTotal { get; set; }

        public DateTime PickUpTime { get; set; }

    }
}
