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
    public class UserSubmittedOrdersController : Controller
    {
        private readonly StephenJoshFinalProject2Context _context;

        public UserSubmittedOrdersController(StephenJoshFinalProject2Context context)
        {
            _context = context;
        }

        // GET: UserSubmittedOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserSubmittedOrder.ToListAsync());
        }

        // GET: UserSubmittedOrders/Details/5
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
                _context.Specs.Add(drinkSpec);
                _context.Drinks.Add(drinkName);



                await _context.SaveChangesAsync();                        //throwing error when trying to save to the database



                return RedirectToAction("Welcome", "Home");
            }
            return View(viewModel);

            
        }

        // GET: UserSubmittedOrders/Edit/5
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

        // POST: UserSubmittedOrders/Edit/5
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

        // GET: UserSubmittedOrders/Delete/5
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

        // POST: UserSubmittedOrders/Delete/5
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
