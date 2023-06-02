using System;
using contact_list_api.Models;

namespace contact_list_api.Services.Interface
{
    /// <summary>
    ///     A service for manipulating the <see cref="DbSet{Contact}"/> Contact entity
    /// </summary>
    public interface IContactService
	{
        /// <summary>
        ///     Retrieves all <see cref="Contact"/> objects
        /// </summary>
        /// <returns>A <see cref="List{Contact}"/> List</returns>
        Task<List<Contact>> GetContactAsync();

        /// <summary>
        ///    Retrieves a <see cref="Contact"/> object by Id 
        /// </summary>
        /// <param name="contactId">Primary Id</param>
        /// <returns>A <see cref="Contact"/> object</returns>
        Task<Contact?> GetContactAsync(long contactId);

        /// <summary>
        ///     Inserts a new <see cref="Contact"/> object
        /// </summary>
        /// <param name="contact"><see cref="Contact"/> object</param>
        /// <returns>Http Request Response</returns>
        Task CreateContactAsync(Contact contact);

        /// <summary>
        ///     Updates a <see cref="Contact"/> object       
        /// </summary>
        /// <param name="contactId">Primary Id</param>
        /// <param name="contact"><see cref="Contact"/> object</param>
        /// <returns>Http Request Response</returns>
        Task UpdateContactAsync(long contactId, Contact contact);

        /// <summary>
        ///     Deletes a <see cref="Contact"/> object
        /// </summary>
        /// <param name="contact"><see cref="Contact"/> object</param>
        /// <returns>Http Request Response</returns>
        Task DeleteContactAsync(Contact contact);

        /// <summary>
        ///     Check to see if <see cref="Contact"/> object is null
        /// </summary>
        /// <param name="contact"><see cref="Contact"/> object</param>
        /// <returns>True if object was null</returns>
        bool IsContactNull(Contact contact);

        /// <summary>
        ///     Check if a <see cref="Contact"/> object exists
        /// </summary>
        /// <param name="contactId">Primary Id</param>
        /// <returns>True if object was found</returns>
        bool ContactExists(long contactId);
    }
}

