using System;
using contact_list_api.Models;

namespace contact_list_api.Repository
{
    /// <summary>
    ///     A Data Access Layer (DAL) interface for <see cref="Contact"/> Contact objects
    /// </summary>
	public interface IContactReposity<Contact>
	{
        /// <summary>
        ///     Retrieves all <see cref="Contact"/> contact
        /// </summary>
        /// <returns>A <see cref="IEnumerable{Contact}"/> List of Contact</returns>
        Task<List<Contact>> GetAllContacts();

        /// <summary>
        ///    Retrieves a <see cref="Contact"/> Contact object by Id 
        /// </summary>
        /// <param name="contactId">Primary Id</param>
        /// <returns>A <see cref="Contact"/> Contact object</returns>
        Task<Contact?> GetContact(long contactId);

        /// <summary>
        ///     Inserts a new <see cref="Contact"/> Contact object
        /// </summary>
        /// <param name="contact"><see cref="Contact"/> Contact object</param>
        /// <returns>Http Request Response</returns>
        Task AddContact(Contact contact);

        /// <summary>
        ///     Updates a <see cref="Contact"/> Contact object       
        /// </summary>
        /// <param name="contactId">Primary Id</param>
        /// <param name="contact"><see cref="Contact"/>Contact object</param>
        /// <returns>Http Request Response</returns>
        Task UpdateContact(long contactId, Contact contact);

        /// <summary>
        ///     Deletes a <see cref="Contact"/> record
        /// </summary>
        /// <param name="contact"><see cref="Contact"/> Contact object</param>
        /// <returns>Http Request Response</returns>
        Task DeleteContact(Contact contact);

        /// <summary>
        ///     Check if a <see cref="Contact"/> object exists
        /// </summary>
        /// <param name="contactId">Primary Id</param>
        /// <returns>True if object was found</returns>
        bool ContactExists(long contactId);

    }
}

