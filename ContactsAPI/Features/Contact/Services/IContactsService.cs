using ContactsAPI.Models;

namespace ContactsAPI.Features.Contact.Services
{
    public interface IContactsService
    {
        Task<List<Contacts>> GetContactsAsync();
        Task<Contacts> AddContactsAsync(ContactsModel contact);
        Task<Contacts> UpdateContactsAsync(int id, ContactsModel contact);
        Task<Contacts> DeleteContactsAsync(int id);
    }
}
