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
    public class CoffeeShopLoginsController : Controller
    {
        private readonly StephenJoshFinalProject2Context _context;

        public CoffeeShopLoginsController(StephenJoshFinalProject2Context context)
        {
            _context = context;
        }


        public IActionResult ShopPortal()
        {
         

            return View();

        }


        public IActionResult Login()
        {
            var viewModel = new CoffeeShopLoginViewModel();

            return View(viewModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(CoffeeShopLoginViewModel viewModel)
        {

            //var claims = new List<Claim>
            //{
                //new Claim(ClaimTypes.Role, "user")
            //};

            var shops = await _context.CoffeeShopLogin
                .ToListAsync();
                
            foreach (var x in shops)
            {
                if ((x.StoreCode == viewModel.StoreCode)&&(x.Password == viewModel.Password))
                {
                    //User.IsInRole("user");
                    return View("ShopPortal");
                }

                else
                {
                    ModelState.AddModelError("StoreCode", "No Store Found");
                }



                
            }



            return View(viewModel);

        }




        // GET: CoffeeShopLogins
        public async Task<IActionResult> Index()
        {
            return View(await _context.CoffeeShopLogin.ToListAsync());
        }

        // GET: CoffeeShopLogins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeeShopLogin = await _context.CoffeeShopLogin
                .FirstOrDefaultAsync(m => m.CoffeeShopLoginId == id);
            if (coffeeShopLogin == null)
            {
                return NotFound();
            }

            return View(coffeeShopLogin);
        }

        // GET: CoffeeShopLogins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoffeeShopLogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoffeeShopLoginId,StoreCode,Password")] CoffeeShopLogin coffeeShopLogin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffeeShopLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coffeeShopLogin);
        }

        // GET: CoffeeShopLogins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeeShopLogin = await _context.CoffeeShopLogin.FindAsync(id);
            if (coffeeShopLogin == null)
            {
                return NotFound();
            }
            return View(coffeeShopLogin);
        }

        // POST: CoffeeShopLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CoffeeShopLoginId,StoreCode,Password")] CoffeeShopLogin coffeeShopLogin)
        {
            if (id != coffeeShopLogin.CoffeeShopLoginId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffeeShopLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeeShopLoginExists(coffeeShopLogin.CoffeeShopLoginId))
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
            return View(coffeeShopLogin);
        }

        // GET: CoffeeShopLogins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeeShopLogin = await _context.CoffeeShopLogin
                .FirstOrDefaultAsync(m => m.CoffeeShopLoginId == id);
            if (coffeeShopLogin == null)
            {
                return NotFound();
            }

            return View(coffeeShopLogin);
        }

        // POST: CoffeeShopLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var coffeeShopLogin = await _context.CoffeeShopLogin.FindAsync(id);
            _context.CoffeeShopLogin.Remove(coffeeShopLogin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeeShopLoginExists(string id)
        {
            return _context.CoffeeShopLogin.Any(e => e.CoffeeShopLoginId == id);
        }
    }
}
