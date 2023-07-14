using ContactsControl.Models;

namespace ContactsControl.Repositories
{
    public interface IContactRepository
    {
        ContactModel Create(ContactModel contact);
        bool Delete(long id);
        ContactModel Get(long id);
        List<ContactModel> GetAll(long? userId);
        ContactModel Update(ContactModel contact);
    }
}