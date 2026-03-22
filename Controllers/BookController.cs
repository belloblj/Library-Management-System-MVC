using LMS.Models;
using LMS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repo;

        public BookController(IBookRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            _repo.Add(book);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_repo.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            _repo.Update(book);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_repo.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}