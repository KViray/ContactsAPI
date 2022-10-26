using ContactsAPI.Features.Contact.Services;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Features.Contact
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ContactsController: ControllerBase
    {
        private readonly IContactsService _contactsService;
        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetContactsAsync()
        {
            var getContacts = await _contactsService.GetContactsAsync();
            return Ok(getContacts);
        }

        [HttpPost]
        public async Task<ActionResult> AddContactsAsync(ContactsModel contacts)
        {
            if (contacts == null)
            {
                return BadRequest();
            }   
            var newContacts = await _contactsService.AddContactsAsync(contacts);
            return Ok(newContacts);
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateContactsAsync(int id, ContactsModel contacts)
        {
            if(contacts == null)
            {
                return BadRequest();
            }
            var updateContacts = await _contactsService.UpdateContactsAsync(id, contacts);
            return Ok(updateContacts);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteContacts(int id)
        {
            var deleteContact = await _contactsService.DeleteContactsAsync(id);
            return Ok(deleteContact);
        }

    }
}
