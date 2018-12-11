using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StephenJoshFinalProject.ViewModels
{
    public class CoffeeShopLoginViewModel
    {

        public string StoreCode { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }



    }
}
