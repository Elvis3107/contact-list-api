using System;
using contact_list_api.Models;
using contact_list_api.Repository;
using contact_list_api.Services.Interface;

namespace contact_list_api.Services
{
    /// <summary>
    ///     Provides a service for manipulating the <see cref="Dbset{Contact}"/> Contact Entity
    /// </summary>
    public class ContactService: IContactService
    {
        /// <summary>
        ///     The <see cref="ContactContext"/> Contact context
        /// </summary>
        private readonly IContactReposity<Contact> _contactReposity;

        /// <summary>
        ///     Instatiates the ContactService
        /// </summary>
        /// <param name="contactRepository">see <see cref="IContactReposity"/></param>
        public ContactService(IContactReposity<Contact> contactRepository)
        {
            _contactReposity = contactRepository;
        }

        /// <inheritdoc cref="GetContactAsync" />
        public async Task<List<Contact>> GetContactAsync()
        {
            return await _contactReposity.GetAllContacts();
        }

        /// <inheritdoc cref="GetContactAsync" />
        public async Task<Contact?> GetContactAsync(long contactId)
        {
            return await _contactReposity.GetContact(contactId);
        }

        /// <inheritdoc cref="CreateContactAsync" />
        public async Task CreateContactAsync(Contact contact)
        {
            await _contactReposity.AddContact(contact);
        }

        /// <inheritdoc cref="UpdateContactAsync" />
        public async Task UpdateContactAsync(long contactId, Contact contact)
        {
            await _contactReposity.UpdateContact(contactId, contact);
        }

        /// <inheritdoc cref="DeleteContactAsync" />
        public async Task DeleteContactAsync(Contact contact)
        {
            await _contactReposity.DeleteContact(contact);
        }

        /// <inheritdoc cref="IsContactNull" />
        public bool IsContactNull(Contact contact)
        {
            return contact == null ? true : false;
        }

        /// <inheritdoc cref="ContactExists" />
        public bool ContactExists(long contactId)
        {
            return _contactReposity.ContactExists(contactId);
        }
    }
}

