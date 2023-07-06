using ContactsControl.Models;

namespace ContactsControl.Repositories
{
    public interface IContactRepository
    {
        List<ContactModel> GetAll();
        ContactModel Create(ContactModel contact);
    }
}