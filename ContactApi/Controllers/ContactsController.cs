using Domain;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetContacts()
        {
            var contacts = contactService.GetAll();
            return Ok(contacts);
        }

        [HttpGet("{Id}")]
        public  ActionResult<Contact> GetContact(int id)
        {
            var contact = contactService.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public ActionResult<Contact> Add(Contact contact)
        {
            var createdContact = contactService.Add(contact);
            return CreatedAtAction(nameof(GetContact), new { id = createdContact.Id }, createdContact);
        }

        [HttpPut("{Id}")]
        public IActionResult PutContact(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }
            contactService.Update(contact);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteContact(int id)
        {
            contactService.Delete(id);
            return NoContent();
        }
    }
}
