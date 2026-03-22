using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using LMS.Repositories;

namespace LMS.Controllers
{
    public class ReaderController : Controller
    {
        private readonly IReaderRepository _repo;

        public ReaderController(IReaderRepository repo)
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
        public IActionResult Create(Reader reader)
        {
            if (!ModelState.IsValid)
                return View(reader);

            _repo.Add(reader);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_repo.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Reader reader)
        {
            if (!ModelState.IsValid)
                return View(reader);

            _repo.Update(reader);
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