using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StephenJoshFinalProject.Models;
using StephenJoshFinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace StephenJoshFinalProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly StephenJoshFinalProjectDbContext _context;




        public HomeController(StephenJoshFinalProjectDbContext context)
        {
            _context = context;
        }



        




        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Menu()
        {
            ViewData["Message"] = "Your menu page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, "user")
            };

            List<User> usersName = await _context.User
                .ToListAsync();
                
            foreach (var x in usersName)
            {
                if ((x.UserName == viewModel.UserName)&&(x.Password == viewModel.Password))
                {
                    User.IsInRole("user");
                    return View("Welcome");
                }
                
            }



            return View("Index");

        }



        [Authorize(Roles = "user")]
        public IActionResult Welcome()
        {
            return View();
        }




    }
}
