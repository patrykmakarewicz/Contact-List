using ContactList.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactList.Data;

namespace ContactList.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactDbContext _context;
        public ContactController(ContactDbContext context) => _context = context;


        [HttpGet]
        public async Task<IEnumerable<Contact>> GetContacts()
            => await _context.Contact.ToListAsync();

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetContact(int id)
        {
            var contact = await _context.Contact.FindAsync(id);
            return contact == null ? NotFound() : Ok(contact);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            await _context.Contact.AddAsync(contact);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateContact(Contact contact, int id)
        {
            var dbContact = await _context.Contact
                .FirstOrDefaultAsync(o => o.Id == id);
            if (dbContact == null) return NotFound();

            dbContact.FirstName = contact.FirstName;
            dbContact.LastName = contact.LastName;
            dbContact.Email = contact.Email;
            dbContact.PhoneNumber = contact.PhoneNumber;


            await _context.SaveChangesAsync();
            return NoContent();

            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveContact(int id)
        {
            var dbContact = await _context.Contact
                .FirstOrDefaultAsync(o => o.Id == id);
            Console.WriteLine("elo");
            if (dbContact == null) return NotFound();
            
            _context.Contact.Remove(dbContact);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}