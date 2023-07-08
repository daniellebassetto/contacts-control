using ContactsControl.Models;

namespace ContactsControl.Repositories
{
    public interface IContactRepository
    {
        List<ContactModel> GetAll();
        ContactModel Get(long id);
        ContactModel Create(ContactModel contact);
        ContactModel Update(ContactModel contact);
        bool Delete(long id);
    }
}