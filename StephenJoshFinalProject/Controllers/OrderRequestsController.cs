using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StephenJoshFinalProject.Models;
using StephenJoshFinalProject.ViewModels;

namespace StephenJoshFinalProject.Controllers
{
    public class OrderRequestsController : Controller
    {
        private readonly StephenJoshFinalProjectDbContext _context;

        public OrderRequestsController(StephenJoshFinalProjectDbContext context)
        {
            _context = context;
        }

       

        //[Authorize(Roles = "users")]
        // GET: OrderRequests/Create
        public IActionResult SubmitOrder()
        {
            
            return View();
        }

        // POST: OrderRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitOrder(OrderPageViewModel viewModel)
        {

            //fetch the data from the database
            DrinkName drinkName = new DrinkName
            {
                Americano = viewModel.Americano,
                Carmelo = viewModel.Carmelo,
                Nova = viewModel.Nova,
                HotChocolate = viewModel.HotChocolate,
                Tea = viewModel.Tea,
                LondonFog = viewModel.LondonFog
            };

            DrinkSpecs drinkSpec = new DrinkSpecs
            {
                Tall = viewModel.Tall,
                Grande = viewModel.Grande,
                Iced = viewModel.Iced,
                Hot = viewModel.Hot,
                Frozen = viewModel.Frozen,
                Quantity = viewModel.Quantity,
                SpecialRequests = viewModel.SpecialRequest

            };

            Order order = new Order
            {
                PickUpTime = viewModel.PickUpTime,
                OrderTotal = viewModel.OrderTotal
            };


            //model class that contains all properties of types of all models
            OrderRequest orderRequest = new OrderRequest
            {
                DrinkName = drinkName,
                DrinkSpecs = drinkSpec,
                Order = order
                
            };



            if (ModelState.IsValid)
            {
                _context.Add(orderRequest);
                _context.Add(order);
                _context.Add(drinkSpec);
                _context.Add(drinkName);

                await _context.SaveChangesAsync();



                return RedirectToAction("Welcome", "Home");
            }
            return View(viewModel);
        }

        
    }
}
