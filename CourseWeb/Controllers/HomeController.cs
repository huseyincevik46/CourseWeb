using System.Diagnostics;
using CourseWeb.Context;
using CourseWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly CourseDbContext _context;

        public HomeController(CourseDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var users = await _context
                .Users
                .Include(u=>u.Candidates)
                .ToListAsync();
                
            return View(users);
        }



    }
}
