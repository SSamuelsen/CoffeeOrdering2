using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StephenJoshFinalProject.Models;

namespace StephenJoshFinalProject.Controllers
{
    public class StoreLoginController : Controller
    {
        private readonly StephenJoshFinalProjectDbContext _context;

        public StoreLoginController(StephenJoshFinalProjectDbContext context)
        {
            _context = context;
        }
        

        public IActionResult StorePortal()
        {
            return View();
        }



        // GET: StoreLogin
        public async Task<IActionResult> Index()
        {
            return View(await _context.StoreLogin.ToListAsync());
        }

        // GET: StoreLogin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeLogin = await _context.StoreLogin
                .FirstOrDefaultAsync(m => m.StoreLoginId == id);
            if (storeLogin == null)
            {
                return NotFound();
            }

            return View(storeLogin);
        }

        // GET: StoreLogin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StoreLogin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreLoginId,StoreCode,Password")] StoreLogin storeLogin)
        {
            if (ModelState.IsValid)
            {

                _context.StoreLogin.Add(storeLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction("StorePortal","StoreLogin");
            }
            return View(storeLogin);
        }

        // GET: StoreLogin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeLogin = await _context.StoreLogin.FindAsync(id);
            if (storeLogin == null)
            {
                return NotFound();
            }
            return View(storeLogin);
        }

        // POST: StoreLogin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreLoginId,StoreCode,Password")] StoreLogin storeLogin)
        {
            if (id != storeLogin.StoreLoginId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreLoginExists(storeLogin.StoreLoginId))
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
            return View(storeLogin);
        }

        // GET: StoreLogin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeLogin = await _context.StoreLogin
                .FirstOrDefaultAsync(m => m.StoreLoginId == id);
            if (storeLogin == null)
            {
                return NotFound();
            }

            return View(storeLogin);
        }

        // POST: StoreLogin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storeLogin = await _context.StoreLogin.FindAsync(id);
            _context.StoreLogin.Remove(storeLogin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreLoginExists(int id)
        {
            return _context.StoreLogin.Any(e => e.StoreLoginId == id);
        }



        



    }
}
