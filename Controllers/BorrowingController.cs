using LMS.Models;
using LMS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.Controllers
{
    public class BorrowingController : Controller
    {
        private readonly IBorrowingRepository _borrowingRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IReaderRepository _readerRepo;

        // Inject all three repositories
        public BorrowingController(
            IBorrowingRepository borrowingRepo,
            IBookRepository bookRepo,
            IReaderRepository readerRepo)
        {
            _borrowingRepo = borrowingRepo;
            _bookRepo = bookRepo;
            _readerRepo = readerRepo;
        }

        // LIST ALL BORROWINGS
        public IActionResult Index()
        {
            var borrowings = _borrowingRepo.GetAll();
            return View(borrowings);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            // Populate dropdowns
            ViewBag.Books = new SelectList(_bookRepo.GetAll(), "Id", "Title");
            ViewBag.Readers = new SelectList(_readerRepo.GetAll(), "Id", "FirstName");

            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public IActionResult Create(Borrowing borrowing)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Books = new SelectList(_bookRepo.GetAll(), "Id", "Title");
                ViewBag.Readers = new SelectList(_readerRepo.GetAll(), "Id", "FirstName");
                return View(borrowing);
            }

            _borrowingRepo.Add(borrowing);
            return RedirectToAction("Index");
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var borrowing = _borrowingRepo.GetById(id);

            ViewBag.Books = new SelectList(_bookRepo.GetAll(), "Id", "Title", borrowing.BookId);
            ViewBag.Readers = new SelectList(_readerRepo.GetAll(), "Id", "FirstName", borrowing.ReaderId);

            return View(borrowing);
        }

        // EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Borrowing borrowing)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Books = new SelectList(_bookRepo.GetAll(), "Id", "Title", borrowing.BookId);
                ViewBag.Readers = new SelectList(_readerRepo.GetAll(), "Id", "FirstName", borrowing.ReaderId);
                return View(borrowing);
            }

            _borrowingRepo.Update(borrowing);
            return RedirectToAction("Index");
        }

        // DELETE (GET)
        public IActionResult Delete(int id)
        {
            var borrowing = _borrowingRepo.GetById(id);
            return View(borrowing);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _borrowingRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}