using System.Reflection;
using CourseWeb.Context;
using CourseWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CourseWeb.Controllers
{
    public class CourseController : Controller
    {
        //private static readonly List<Candidate> _candidatesList = new List<Candidate>();


        //public static IReadOnlyCollection<Candidate> Candidates => _candidatesList;

        private readonly CourseDbContext _context;


        public CourseController(CourseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        // silmek istediğinden amin misin sayfası.
        public async Task<IActionResult> Delete(int? Id)  


        {
            if(Id== null)
            {
                NotFound();
            }

            // databasedeki user ile eşleşiyorsa sayfaya user döndürür
            var user = await _context.Users.FindAsync(Id);
            if( user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //[HttpPost]  
        //public async Task<IActionResult> Delete([FromForm]int? Id) //delete post metodu
        //{
        //    var course = await _context.Candidates.FindAsync(Id);

        //    if( course== null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Candidates.Remove(course);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //} 



        // kursları düzenleme sayfasına Id değerini dönderdik
        public async Task<IActionResult> Edit(int? Id)         // Kurs düzenleme Sayfası
        {
            //Id null ise bulunamadı
            if (Id == null)
            {
                return NotFound();
            }
            // databasede Id arandı ve course değerine atandı
            var course = _context.Candidates.FirstOrDefault(u => u.Id == Id);

            //course değerini boş olma durumunu kontrol ettim ama zaten null olamaz uyarısı veriyor 
            //bu sayfayı kullanmıcam kursları seçmeli yapmıştım sadece edit sayfasının yapısı için var.


            return View(course);
        }


        [HttpPost] // Referans Id ile kurs modelimizi dönderecek 
        public async Task<IActionResult> Edit(int? Id, Candidate candidate)  // Edit Post metodu 
        {
            // değiştirmek istediğimiz Id ile modeldeki Id aynı değilse boş
            if (Id == candidate.Id)
            {
                return NotFound();
            }

            // Her şey uygunsa devam et 
            if (ModelState.IsValid)
            {
                try
                {
                    // modeli Update et ve kaydet
                    _context.Update(candidate);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException) // database update özel exeption
                {
                    // user modelinde kurs ıd ile aynı olan var mı 
                    if (!_context.Users.Any(u => u.UserId == candidate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                RedirectToAction("Index");
            }
            return View(candidate);

        }

        public async Task<IActionResult> Index() //kurs gösterme ekranı get metodu
        {
            var candidates =
                await _context
                .Candidates
                
                .ToListAsync();
            return View(candidates);
        }


        public IActionResult Apply() // kurs ekleme get metodu
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply(Candidate candidate) // form üzerinden verilerle aracılıgıyla model doldurma model binding
        {

            // kullanıcın var olup olmadıgını kontrol et 
            //if (candidate.UserModel != null)
            //{
            //    candidate.UserId = candidate.UserModel.UserId; // foreign Key olarak UserId atandı
            //}


            if (!_context.Candidates.Any(u => u.Id == candidate.Id))
            {
               
                _context.Candidates.Add(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Course");

            }
            else
            {
                
                ModelState.AddModelError("Email", "This email is already registered");
                return View(await _context.Candidates.Include(u=>u.UserModel).ToListAsync());
            }

        }

    }




}
