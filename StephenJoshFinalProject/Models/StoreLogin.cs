using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StephenJoshFinalProject.Models
{
    public class StoreLogin
    {

        public int StoreLoginId { get; set; }

        [Required]
        public string StoreCode { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }





    }
}
