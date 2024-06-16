using DapperDemo.Models;
using DapperDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
namespace DapperDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IStudent _studentservice;

        public StudentController(IConfiguration configuration,IStudent studentservice)
        {
            _configuration = configuration;
            _studentservice= studentservice;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            StudentVM studentVM = new StudentVM();
            studentVM.StudentsList = _studentservice.GetStudentsList().ToList();
            return View(studentVM);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
          
                if (ModelState.IsValid)
                {
                    var result = _studentservice.InsertStudent(student);
                    if (result == "Insert successful")
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            return View(student);

        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
