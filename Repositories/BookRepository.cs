using System.Collections.Generic;
using System.Linq;
using LMS.Models;

namespace LMS.Repositories
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Cooking Fundamentals", Author = "John Doe", Category = "Cooking", TotalCopies = 10, AvailableCopies = 7 },
            new Book { Id = 2, Title = "Fuji Music Guide", Author = "Jane Smith", Category = "Music", TotalCopies = 5, AvailableCopies = 3 }
        };

        public List<Book> GetAll() => _books;

        public Book GetById(int id) =>
            _books.FirstOrDefault(b => b.Id == id);

        public void Add(Book book)
        {
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
        }

        public void Update(Book book)
        {
            var existing = GetById(book.Id);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.Category = book.Category;
                existing.TotalCopies = book.TotalCopies;
                existing.AvailableCopies = book.AvailableCopies;
            }
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null)
                _books.Remove(book);
        }
    }
}