using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StephenJoshFinalProject.Models;
using StephenJoshFinalProject.ViewModels;

namespace StephenJoshFinalProject.Controllers
{
    public class QueueItemsController : Controller
    {
        private readonly StephenJoshFinalProjectDbContext _context;

        public QueueItemsController(StephenJoshFinalProjectDbContext context)
        {
            _context = context;
        }

       

        // GET: QueueItems/Create
        public IActionResult Create()
        {
            var viewModel = new QueueViewModel();

            return View(viewModel);

        }

        // POST: QueueItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QueueViewModel viewModel)
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
                SpecialRequests = viewModel.SpecialRequests

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
                _context.OrderRequest.Add(orderRequest);
                _context.Order.Add(order);
                _context.DrinkSpecs.Add(drinkSpec);
                _context.DrinkName.Add(drinkName);
                
                await _context.SaveChangesAsync();                        //throwing error when trying to save to the database



                return RedirectToAction("Welcome", "Home");
            }
            return View(viewModel);
        }

      
    }
}
