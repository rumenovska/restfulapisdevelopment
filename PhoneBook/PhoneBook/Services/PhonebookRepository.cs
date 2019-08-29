using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class PhonebookRepository
    {
        private readonly PhonebookDbContext db;

        public PhonebookRepository(PhonebookDbContext context)
        {
            db = context;
        }

        public List<T> GetAll<T>() where T : class , BaseModel
        {
            return db.Set<T>().ToList();
        }

    }
}
