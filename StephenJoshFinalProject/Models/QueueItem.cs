using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephenJoshFinalProject.Models
{
    public class QueueItem
    {
        public int QueueItemId { get; set; }

        public DrinkName DrinkName { get; set; }

        public DrinkSpecs DrinkSpecs { get; set; }

        public Order Order { get; set; }

        public User User { get; set; }



    }
}
