using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Repository
{
    public class UserRepository
    {
        private readonly PhonebookDbContext _db;
        public ContactRepository(PhonebookDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _db.Contacts.ToList();
        }

        public void Add(Contact entity)
        {
            _db.Contacts.Add(entity);

            _db.SaveChanges();
        }


        public void Update(Contact entity)
        {
            var contact = _db.Contacts
                .SingleOrDefault(c => c.Id == entity.Id && c.UserId == entity.UserId);

            contact.FirstName = entity.FirstName;
            contact.LastName = entity.LastName;
            contact.Email = entity.Email;
            contact.Address = entity.Address;
            contact.PhoneNumber = entity.PhoneNumber;
            contact.UserId = entity.UserId;

            _db.SaveChanges();
        }

        public void Delete(Contact entity)
        {
            _db.Contacts.Remove(entity);

            _db.SaveChanges();
        }
    }
}
