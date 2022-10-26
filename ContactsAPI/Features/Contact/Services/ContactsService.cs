using ContactsAPI.ApplicationContext;
using ContactsAPI.Models;

namespace ContactsAPI.Features.Contact.Services
{
    public class ContactsService : IContactsService
    {
        private readonly ApplicationDbContext _appDbContext;

        public ContactsService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Contacts> AddContactsAsync(ContactsModel contact)
        {
            var newContact = new Contacts{
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                CompanyName = contact.CompanyName,
                Email = contact.Email,
                MobileNumber = contact.MobileNumber,
            };
            _appDbContext.Add(newContact);
            _appDbContext.SaveChanges();
            return await Task.FromResult(newContact);
        }

        public async Task<Contacts> DeleteContactsAsync(int id)
        {
            var contact = _appDbContext.Contacts.Where(contact => contact.Id == id).First();
            _appDbContext.Remove(contact);
            _appDbContext.SaveChanges();
            return await Task.FromResult(contact);
        }

        public async Task<List<Contacts>> GetContactsAsync()
        {
            var contacts = _appDbContext.Contacts.ToList();
            return await Task.FromResult(contacts);
        }

        public async Task<Contacts> UpdateContactsAsync(int id, ContactsModel contact)
        {
            var cont = _appDbContext.Contacts.Where(c => c.Id == id).First();
            cont.FirstName = contact.FirstName;
            cont.LastName = contact.LastName;
            cont.CompanyName = contact.CompanyName;
            cont.Email = contact.Email;
            cont.MobileNumber = contact.MobileNumber;
            _appDbContext.SaveChanges();
            return await Task.FromResult(cont);
        }
    }
}
