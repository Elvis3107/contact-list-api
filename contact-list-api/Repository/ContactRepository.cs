using System;
using contact_list_api.Models;
using Microsoft.EntityFrameworkCore;

namespace contact_list_api.Repository
{
    /// <summary>
    ///     Provides a repository for manipulating the <see cref="Dbset{Contact}"/> Contact Entity
    /// </summary>
	public class ContactRepository : IContactReposity<Contact>
    {
        readonly ContactContext _contactContext;

        /// <summary>
        ///     Instatiates the ContactRepository
        /// </summary>
        /// <param name="context">see <see cref="ContactContext"/></param>
        public ContactRepository(ContactContext context)
        {
            _contactContext = context;
        }

        /// <summary>
        ///     Get all contacts from the db
        /// </summary>
        public async Task<List<Contact>> GetAllContacts()
        {
            return await _contactContext.Contacts.ToListAsync();
        }

        /// <summary>
        ///     Get a contact record
        /// </summary>
        public async Task<Contact?> GetContact(long id)
        {
            return await _contactContext.Contacts.FindAsync(id);
        }

        /// <summary>
        ///     Create new contact record
        /// </summary>
        public async Task AddContact(Contact contact)
        {
            _contactContext.Contacts.Add(contact);
            await _contactContext.SaveChangesAsync();
        }

        /// <summary>
        ///     Update contact record
        /// </summary>
        public async Task UpdateContact(long contactId, Contact contact)
        {
            _contactContext.Entry(contact).State = EntityState.Modified;

            try
            {
                await _contactContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ContactExists(contactId))
                {
                    throw;
                }
            }
        }

        /// <summary>
        ///     Delete contact record
        /// </summary>
        public async Task DeleteContact(Contact contact)
        {
            _contactContext.Contacts.Remove(contact);
            await _contactContext.SaveChangesAsync();
        }

        /// <summary>
        ///     Check if contact exist
        /// </summary>
        public bool ContactExists(long contactId)
        {
            return (_contactContext.Contacts?.Any(e => e.ContactId == contactId)).GetValueOrDefault();
        }

    }
}

