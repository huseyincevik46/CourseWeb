using CourseWeb.Context;
using CourseWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using BCrypt.Net;
using System.Text.RegularExpressions;


namespace CourseWeb.Controllers
{
    public class ProfilController : Controller
    {
        //private static List<UserModel> _usersList = new List<UserModel>();

        //public static IEnumerable<UserModel> Users => _usersList ?? new List<UserModel>();

        private readonly CourseDbContext _context;


        public ProfilController(CourseDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()  
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignUp() 
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserModel model) 
        {
            // 1. Eğer email zaten varsa hata döndür
            if (_context.Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("Email", "This email is already registered");
                return View(model);
            }

            // 2. Email formatı yanlışsa hata döndür
            if (!Regex.IsMatch(model.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ModelState.AddModelError("Email", "Invalid email format");
                return View(model);
            }

            // 3. Şifreyi hashle
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            // 4. Yeni kullanıcı nesnesi oluştur ve hashlenmiş şifreyi ekle
            var newUser = new UserModel
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = hashedPassword, // Hashlenmiş şifre kaydediliyor
                Gender = model.Gender
            };

            // 5. Kullanıcıyı veritabanına kaydet
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            // 6. Kullanıcı giriş sayfasına yönlendir
            return RedirectToAction("Login", "Profil");
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel model)
        {
            // 1. Email veya Şifre boşsa hata döndür
            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("Email", "Email cannot be empty");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "Password cannot be empty");
            }

           
            // 3. Kullanıcıyı veritabanında bul
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);

            // kullanıcı yoksa
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email not found");
                return View(model);
            }

            // 4. Şifre kontrolü
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);

            if (isPasswordValid)
            {
                Console.WriteLine("Login successful");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Password", "Incorrect password.");
                return View(model);
            }
        }



    }
}





