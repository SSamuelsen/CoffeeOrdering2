using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StephenJoshFinalProject.ViewModels
{
    public class QueueViewModel
    {
        
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

       
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Order Total")]
        public double OrderTotal { get; set; }

        [Display(Name ="Pick Up Time")]
        public DateTime PickUpTime { get; set; }

        public bool Tall { get; set; }
        public bool Grande { get; set; }
        public bool Iced { get; set; }
        public bool Hot { get; set; }
        public bool Frozen { get; set; }
        public int Quantity { get; set; }


        [Required]
        [Display(Name="Name for Order")]
        public string SpecialRequests { get; set; }

        public bool Americano { get; set; }

        public bool Carmelo { get; set; }

        public bool Nova { get; set; }

        public bool HotChocolate { get; set; }

        public bool Tea { get; set; }

        [Display(Name = "London Fog")]
        public bool LondonFog { get; set; }





    }
}
