using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StephenJoshFinalProject.Models;
using StephenJoshFinalProject.ViewModels;
using StephenJoshFinalProject.TagHelpers;
using System.Linq.Dynamic.Core;

namespace StephenJoshFinalProject.Controllers
{
    public class UserSubmittedOrders1Controller : Controller
    {
        private readonly StephenJoshFinalProject3Context _context;

        public UserSubmittedOrders1Controller(StephenJoshFinalProject3Context context)
        {
            _context = context;
        }



        //public IActionResult RecentOrders()
        //{


        //    var viewModel = new QueueViewModel();
        //    return View(viewModel);


        //}


        public IActionResult Barista()              //display the barista name
        {
            //get random number and select barista name from array
            string[] baristaNames = new string[] { "Josh", "Michaela", "Stephen", "Luke" }; //array to hold barista names
            Random randNum = new Random();
            int num = randNum.Next(0, 3);
            
            var viewModel = new BaristaViewModel();

            viewModel.BaristaName = baristaNames[num];

            return View(viewModel);
        }


        //used to display all the orders for the store
        public async Task<IActionResult> RecentOrders(QueryOptions queryOptions)
        {


            if (queryOptions == null || string.IsNullOrWhiteSpace(queryOptions.SortField))
            {

                queryOptions = new QueryOptions
                {
                    SortField = "LastName",
                    SortOrder = SortOrder.ASC
                };


            }

            ViewBag.QueryOptions = queryOptions;



            var orders = await _context.UserSubmittedOrder
                .Include(x => x.DrinkName)
                .Include(x => x.DrinkSpecs)
                .Include(x => x.Order)

                .ToListAsync();

            var viewModel = new List<QueueViewModel>();


            foreach (var order in orders)
            {
                viewModel.Add(new QueueViewModel
                {

                    SpecialRequests = order.DrinkSpecs.SpecialRequests,
                    OrderTotal = order.Order.OrderTotal,
                    Americano = order.DrinkName.Americano,
                    Carmelo = order.DrinkName.Carmelo,
                    LondonFog = order.DrinkName.LondonFog,
                    HotChocolate = order.DrinkName.HotChocolate,
                    Nova = order.DrinkName.Nova,
                    Tea = order.DrinkName.Tea,
                    Tall = order.DrinkSpecs.Tall,
                    Grande = order.DrinkSpecs.Grande,
                    Iced = order.DrinkSpecs.Iced,
                    Hot = order.DrinkSpecs.Hot,
                    Frozen = order.DrinkSpecs.Frozen,
                    Quantity = order.DrinkSpecs.Quantity,
                    PickUpTime = order.Order.PickUpTime

                });
            }



            return View(viewModel.AsQueryable().OrderBy(queryOptions.Sort).ToList());       //added the AsQueryable()





        }






        //used to display all the orders for the store
        // GET: UserSubmittedOrders1
        public async Task<IActionResult> Index(QueryOptions queryOptions)
        {


            if (queryOptions == null || string.IsNullOrWhiteSpace(queryOptions.SortField))
            {

                queryOptions = new QueryOptions
                {
                    SortField = "LastName",
                    SortOrder = SortOrder.ASC
                };


            }

            ViewBag.QueryOptions = queryOptions;



            var orders = await _context.UserSubmittedOrder
                .Include(x => x.DrinkName)
                .Include(x => x.DrinkSpecs)
                .Include(x => x.Order)
                
                .ToListAsync();

            var viewModel = new List<QueueViewModel>();


            foreach (var order in orders)
            {
                viewModel.Add(new QueueViewModel
                {
                
                    SpecialRequests = order.DrinkSpecs.SpecialRequests,
                    OrderTotal = order.Order.OrderTotal,
                    Americano = order.DrinkName.Americano,
                    Carmelo = order.DrinkName.Carmelo,
                    LondonFog = order.DrinkName.LondonFog,
                    HotChocolate = order.DrinkName.HotChocolate,
                    Nova = order.DrinkName.Nova,
                    Tea = order.DrinkName.Tea,
                    Tall = order.DrinkSpecs.Tall,
                    Grande = order.DrinkSpecs.Grande,
                    Iced = order.DrinkSpecs.Iced,
                    Hot = order.DrinkSpecs.Hot,
                    Frozen = order.DrinkSpecs.Frozen,
                    Quantity = order.DrinkSpecs.Quantity,
                    PickUpTime = order.Order.PickUpTime

                });
            }



            return View(viewModel.AsQueryable().OrderBy(queryOptions.Sort).ToList());       //added the AsQueryable()





        }

        // GET: UserSubmittedOrders1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubmittedOrder = await _context.UserSubmittedOrder
                .FirstOrDefaultAsync(m => m.UserSubmittedOrderId == id);
            if (userSubmittedOrder == null)
            {
                return NotFound();
            }

            return View(userSubmittedOrder);
        }








        // GET: UserSubmittedOrders/Create
        public IActionResult Create()
        {
            var viewModel = new QueueViewModel();
            return View(viewModel);
        }

        // POST: UserSubmittedOrders/Create
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
                SpecialRequests = viewModel.SpecialRequests     //Special requests is going to be used for the Name for the order and not special requests!!!!!!!!!!!!!!!!!!!!!!!!!!

            };

            Order order = new Order
            {
                PickUpTime = viewModel.PickUpTime,
                OrderTotal = viewModel.OrderTotal
            };

            


            //model class that contains all properties of types of all models
            UserSubmittedOrder orderRequest = new UserSubmittedOrder
            {
                DrinkName = drinkName,
                DrinkSpecs = drinkSpec,
                Order = order
               
                
            };



            if (ModelState.IsValid)
            {
                _context.UserSubmittedOrder.Add(orderRequest);
                _context.Order.Add(order);
                _context.DrinkSpecs.Add(drinkSpec);
                _context.DrinkName.Add(drinkName);

                ViewData["User"] = viewModel.SpecialRequests.ToString();       //save the user name

                await _context.SaveChangesAsync();                        //throwing error when trying to save to the database



                return RedirectToAction("Barista", "UserSubmittedOrders1");
            }
            return View(viewModel);


        }













        // GET: UserSubmittedOrders1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubmittedOrder = await _context.UserSubmittedOrder.FindAsync(id);
            if (userSubmittedOrder == null)
            {
                return NotFound();
            }
            return View(userSubmittedOrder);
        }

        // POST: UserSubmittedOrders1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserSubmittedOrderId")] UserSubmittedOrder userSubmittedOrder)
        {
            if (id != userSubmittedOrder.UserSubmittedOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSubmittedOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSubmittedOrderExists(userSubmittedOrder.UserSubmittedOrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userSubmittedOrder);
        }

        // GET: UserSubmittedOrders1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubmittedOrder = await _context.UserSubmittedOrder
                .FirstOrDefaultAsync(m => m.UserSubmittedOrderId == id);
            if (userSubmittedOrder == null)
            {
                return NotFound();
            }

            return View(userSubmittedOrder);
        }

        // POST: UserSubmittedOrders1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userSubmittedOrder = await _context.UserSubmittedOrder.FindAsync(id);
            _context.UserSubmittedOrder.Remove(userSubmittedOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserSubmittedOrderExists(int id)
        {
            return _context.UserSubmittedOrder.Any(e => e.UserSubmittedOrderId == id);
        }
    }
}
