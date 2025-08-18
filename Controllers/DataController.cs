using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCwithEFCore.Data;
using MVCwithEFCore.Migrations;
using MVCwithEFCore.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace MVCwithEFCore.Controllers
{
    public class DataController : Controller
    {
        public SQLDbContext db;
        public DataController(SQLDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            if (HttpContext.Session.GetString("MyKey") != null)
            {
                ViewBag.Data = HttpContext.Session.GetString("MyKey");
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddTeacher()
        {
            var user = "Admin";
            var pass = "Password";
            if (user == "Admin" & pass == "Passwrod")
            {
                HttpContext.Session.SetString("MyKey", "admin@company.com");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if(HttpContext.Session.GetString("MyKey") == null)
            {
                TempData["AlertMessage"] = "Please Login First...";
                return RedirectToAction(nameof(AddStudent));
            }
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

        public IActionResult ViewTeachers(Teacher teacher)
        {
            //db for database, Students the name of table and Add to Insert data
            var teachers = db.Teachers.ToList();
            return View(teachers);
        }

        public IActionResult ViewStudents(Student student)
        {
            var students = db.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult AddBooks()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBooks(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction(nameof(Books));
        }

        public IActionResult Books(Book book)
        {
            var books = db.Books.ToList();
            return View(books);
        }

        public IActionResult BookDetail(int Id)
        {
            var books = db.Books.Find(Id);
            return View(books);
        }

        [HttpGet]
        public IActionResult EditBook(int Id)
        {
            var books = db.Books.Find(Id);
            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(Book book)
        {
            var books = await db.Books.FindAsync(book.BookId);
            if (books is not null)
            {
                books.BookName = book.BookName;
                books.Author = book.Author;
                books.Publisher = book.Publisher;
                books.YearPublished=book.YearPublished;
                books.ISBN = book.ISBN;
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Books", "Data"); 
        }

        [HttpGet]
        public IActionResult DeleteBook(int Id)
        {
            var books = db.Books.Find(Id);
            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(Book book)
        {
            var books = await db.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.BookId == book.BookId);
            if (books is not null)
            {
                db.Books.Remove(book);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Books", "Data");
        }
        public void Logout()
        {
            HttpContext.Session.Remove("MyKey");
        }
    }
}
