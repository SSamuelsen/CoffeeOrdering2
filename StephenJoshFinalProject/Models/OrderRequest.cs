using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephenJoshFinalProject.Models
{
    public class OrderRequest
    {

        public int OrderRequestId { get; set; }

        public DrinkName DrinkName { get; set; }

        public DrinkSpecs DrinkSpecs { get; set; }

        public Order Order { get; set; }



    }
}
