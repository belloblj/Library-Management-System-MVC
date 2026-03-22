using System.Collections.Generic;
using System.Linq;
using LMS.Models;

namespace LMS.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private static List<Reader> _readers = new List<Reader>
        {
            new Reader { Id = 1, FirstName = "Alice", LastName = "Johnson", Email = "alice@mail.com" },
            new Reader { Id = 2, FirstName = "Bob", LastName = "Williams", Email = "bob@mail.com" }
        };

        public IEnumerable<Reader> GetAll()
        {
            return _readers;
        }

        public Reader GetById(int id)
        {
            return _readers.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Reader reader)
        {
            reader.Id = _readers.Any() ? _readers.Max(r => r.Id) + 1 : 1;
            _readers.Add(reader);
        }

        public void Update(Reader reader)
        {
            var existing = GetById(reader.Id);
            if (existing != null)
            {
                existing.FirstName = reader.FirstName;
                existing.LastName = reader.LastName;
                existing.Email = reader.Email;
                existing.PhoneNumber = reader.PhoneNumber;
                existing.RegisteredDate = reader.RegisteredDate;
                existing.Address = reader.Address;
            }
        }

        public void Delete(int id)
        {
            var reader = GetById(id);
            if (reader != null)
            {
                _readers.Remove(reader);
            }
        }
    }
}