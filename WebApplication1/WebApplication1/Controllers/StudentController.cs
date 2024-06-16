using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using Dapper;
namespace WebApplication1.Controllers
{
    
    public class StudentController : Controller
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }

     
        public IActionResult Details(int id)
        {
            var student = _context.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = _context.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }


        public IActionResult Delete(int id)
        {
            var student = _context.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
