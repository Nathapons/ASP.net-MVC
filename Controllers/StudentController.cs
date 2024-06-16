using BasicASPTutorial.Data;
using BasicASPTutorial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicASPTutorial.Controllers
{
    public class StudentController : Controller
    {

        private readonly ApplicationDBContext _db;

        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet]   
        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> students = await _db.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(student);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _db.Students.FindAsync(id);
            return View();
        }
    }
}
