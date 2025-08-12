using Microsoft.AspNetCore.Mvc;
using MVCwithEFCore.Data;
using MVCwithEFCore.Models;

namespace MVCwithEFCore.Controllers
{
    public class DataController : Controller
    {
        public SQLDbContext db;
        public DataController(SQLDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Student student)
        {
            //db for database, Students the name of table and Add to Insert data
            db.Students.Add(student);
            db.SaveChanges();
            TempData["AlertMessage"] = "Data Saved Successfully...";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddTeacher(Teacher teacher)
        {
            //db for database, Students the name of table and Add to Insert data
            db.Teachers.Add(teacher);
            db.SaveChanges();
            TempData["AlertMessage"] = "Data Saved Successfully...";

            return RedirectToAction(nameof(AddTeacher));
        }

    }
}
