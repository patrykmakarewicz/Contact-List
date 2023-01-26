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
        public async Task<IEnumerable<Contact>> GetAllContacts()
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            await _context.Contact.AddAsync(contact);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateContact(int id, Contact contact)
        {
            if (id != contact.Id) return NotFound();
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveContact(int id)
        {
            var contact = await _context.Contact.FindAsync(id);
            if (contact == null) return NotFound();
            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}