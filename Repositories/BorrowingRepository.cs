using LMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Repositories
{
    public class BorrowingRepository : IBorrowingRepository
    {
        private static List<Borrowing> _borrowings = new List<Borrowing>();

        public List<Borrowing> GetAll()
        {
            return _borrowings;
        }

        public Borrowing GetById(int id)
        {
            return _borrowings.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Borrowing borrowing)
        {
            _borrowings.Add(borrowing);
        }

        public void Update(Borrowing borrowing)
        {
            var existing = GetById(borrowing.Id);
            if (existing != null)
            {
                existing.BookId = borrowing.BookId;
                existing.ReaderId = borrowing.ReaderId;
                existing.BorrowDate = borrowing.BorrowDate;
                existing.DueDate = borrowing.DueDate;
                existing.ReturnDate = borrowing.ReturnDate;
                existing.OverdueCharge = borrowing.OverdueCharge;
            }
        }

        public void Delete(int id)
        {
            var borrowing = GetById(id);
            if (borrowing != null)
            {
                _borrowings.Remove(borrowing);
            }
        }
    }
}