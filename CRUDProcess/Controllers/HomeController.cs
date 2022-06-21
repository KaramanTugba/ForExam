using CRUDProcess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDProcess.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;


        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult>Create(Student student)
        {
            await _context.AddAsync(student);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Student(int? Id)
        {
            Student student;
            if (Id.HasValue)
            {
                student = _context.Student.Find(Id);
            }
            else
            {
                student = new Student();
            }
            
            return View(student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}