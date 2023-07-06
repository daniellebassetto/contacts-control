using ContactsControl.Data;
using ContactsControl.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace ContactsControl.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public ContactRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public ContactModel Create(ContactModel contact)
        {
            _dataBaseContext.Contact.Add(contact);
            _dataBaseContext.SaveChanges();
            return contact;
        }

        public List<ContactModel> GetAll()
        {
            return _dataBaseContext.Contact.ToList();
        }

        

        
    }
}