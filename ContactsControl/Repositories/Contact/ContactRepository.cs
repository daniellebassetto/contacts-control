using ContactsControl.Data;
using ContactsControl.Models;

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

        public bool Delete(long id)
        {
            ContactModel deleteContact = Get(id);

            if (deleteContact == null)
                throw new Exception("Contato inválido ou inexistente");

            _dataBaseContext.Remove(deleteContact);
            _dataBaseContext.SaveChanges();

            return true;
        }

        public ContactModel Get(long id)
        {
            return _dataBaseContext.Contact.FirstOrDefault(x => x.Id == id);
        }

        public List<ContactModel> GetAll()
        {
            return _dataBaseContext.Contact.ToList();
        }

        public ContactModel Update(ContactModel contact)
        {
            ContactModel updateContact = Get(contact.Id);

            if (updateContact == null)
                throw new Exception("Contato inválido ou inexistente");

            updateContact.Name = contact.Name; 
            updateContact.Email = contact.Email;
            updateContact.Phone = contact.Phone;

            _dataBaseContext.Update(updateContact);
            _dataBaseContext.SaveChanges();
            return updateContact;
        }
    }
}