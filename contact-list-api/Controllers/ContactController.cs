using System;
using contact_list_api.Exceptions;
using contact_list_api.Models;
using contact_list_api.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace contact_list_api.Controllers
{
    /// <summary>
    ///     Provides a controller for Contact requests.
    /// </summary>
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        /// <summary>
        ///     A local <see cref="IContactService"/> IContactService service variable
        /// </summary>
        private readonly IContactService _contactService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactController" />.
        /// </summary>
        /// <param name="contactService">A <see cref="IContactService"/> service </param>
        public ContactController(IContactService contactService)
        {
            this._contactService = contactService;
        }

        /// <method>GET</method>
        /// <path>api/Contact</path>
        /// <summary>
        ///     Get a list of all the Contact
        /// </summary>
        /// <returns>A <see cref="IEnumerable{Contact}"/> List of Contact</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            List<Contact> contacts = await _contactService.GetContactAsync();

            if (contacts == null) return NotFound();

            return Ok(contacts);
        }

        /// <method>GET</method>
        /// <path>api/Contact/{id}</path>
        /// <summary>
        ///     Get a Contact by id
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns><see cref="Contact"/>Contact object</returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetContactById(long id)
        {
            var contact = await _contactService.GetContactAsync(id);

            if (contact == null) return NotFound();

            return Ok(contact);            
        }

        /// <method>POST</method>
        /// <path>api/Contact</path>
        /// <summary>
        ///     Inserts a Contact object
        /// </summary>
        /// <param name="contact"><see cref="Contact"/>Contact object</param>
        /// <returns>Http Request Response</returns>
        [HttpPost]
        public async Task<IActionResult> CreateNewContact([FromBody] Contact contact)
        {
            await _contactService.CreateContactAsync(contact);

            return Created("Post", contact);
        }

        /// <method>PUT</method>
        /// <path>api/Contact/{id}</path>
        /// <summary>
        ///     Updates a Contact object
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <param name="contact"><see cref="Contact"/>Contact object</param>
        /// <returns>Http Request Response</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(long id, [FromBody] Contact contact)
        {
            if (id != contact.ContactId) return BadRequest();
 
            try
            {
                await _contactService.UpdateContactAsync(id, contact);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_contactService.ContactExists(id)) return NotFound();
                else return BadRequest();
            }

            return Ok(contact);
        }

        /// <method>DELETE</method>
        /// <path>api/Contact/{id}</path>
        /// <summary>
        ///     Deletes a Contact object
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns>Http Request Response</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(long id)
        {
            var contact = await _contactService.GetContactAsync(id);

            if (contact == null) return NotFound();

            await _contactService.DeleteContactAsync(contact);

            return NoContent();
        }
    }
}

