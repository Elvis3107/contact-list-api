using System;
using contact_list_api;
using contact_list_api_test.Helpers;
using Microsoft.EntityFrameworkCore;
using contact_list_api.Exceptions;
using contact_list_api.Models;
using contact_list_api.Repository;
using Org.BouncyCastle.Ocsp;

namespace contact_list_api_test.RepositoryTest
{
    /// <summary>
    ///     Provide tests for the ContacttRepository
    /// </summary>
    public class ContacttRepositoryTest
	{
        /// <summary>
        ///     Local <see cref="DbContextOptions"/> variable
        /// </summary>
        private readonly DbContextOptions<ContactContext> _contextOptions;

        /// <summary>
        ///    Instantiates the ContacttRepositoryTest
        /// </summary>
        public ContacttRepositoryTest()
        {
            _contextOptions = new DbContextOptionsBuilder<ContactContext>().UseInMemoryDatabase("ContactRepositoryTestDb")
                .Options;

            using var context = new ContactContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        /// <summary>
        ///     Test <see cref="ContactRepository.GetAllContacts"/> method.
        ///     Returns list of <see cref="Contact"/>
        /// </summary>
        [Fact]
        public async Task GetContactAsync_ReturnsListOfContact()
        {
            // Arrange
            using var context = new ContactContext(_contextOptions);
            ContactRepository _repository = new ContactRepository(context);

            // Act
            var result = await _repository.GetAllContacts();

            // Assert
            Assert.IsType<List<Contact>>(result);
        }

        /// <summary>
        ///     Test <see cref="ContactRepository.GetContact"/> method.
        ///     Returns a <see cref="Contact"/>
        /// </summary>
        [Fact]
        public async Task GetContactAsync_ReturnContact()
        {
            // Arrange
            using var context = new ContactContext(_contextOptions);
            ContactRepository _repository = new ContactRepository(context);
            int Id = 1;

            // Act
            var result = await _repository.GetContact(Id);

            // Assert
            Assert.IsType<Contact>(result);
        }

        /// <summary>
        ///     Test <see cref="ContactRepository.GetContact"/> method.
        ///     Returns null <see cref="Contact"/> if invalid Id
        /// </summary>
        [Fact]
        public async Task GetContactAsync_ReturnsNullIfInvalidId()
        {
            // Arrange
            using var context = new ContactContext(_contextOptions);
            ContactRepository _repository = new ContactRepository(context);
            int Id = 1000;

            // Act
            var result = await _repository.GetContact(Id);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Test <see cref="ContactRepository.UpdateContact"/> method.
        ///     Updates an existing <see cref="Contact"/>
        /// </summary>
        [Fact]
        public async Task PutContactAsync_UpdatesContact()
        {
            // Arrange
            using var context = new ContactContext(_contextOptions);
            ContactRepository _repository = new ContactRepository(context);
            int id = 1000;
            var contact = ModelsHelper.GetContactTestData();
            contact.ContactId = id;
            contact.FirstName = "First";
            contact.LastName = "Last";
            contact.Email = "first@test.com";
            contact.PhoneNumber = "0892345444";

            // Act
            await _repository.UpdateContact(id, contact);
            var result = await _repository.GetContact(id);

            // Assert
            Assert.IsType<Contact>(result);
            Assert.Equal(result?.ContactId, contact.ContactId);
            Assert.Equal(result?.FirstName, contact.FirstName);
        }

        /// <summary>
        ///     Test <see cref="ContactRepository.AddContact"/> method.
        ///     Inserts a <see cref="Contact"/>
        /// </summary>
        [Fact]
        public async Task PostContactAsync_InsertsContact()
        {
            // Arrange
            using var context = new ContactContext(_contextOptions);
            ContactRepository _repository = new ContactRepository(context);

            int id = 1000;
            var contact = ModelsHelper.GetContactTestData();
            contact.ContactId = id;
            contact.FirstName = "First";
            contact.LastName = "Last";
            contact.Email = "first@test.com";
            contact.PhoneNumber = "0892345444";

            // Act
            await _repository.AddContact(contact);
            var result = await _repository.GetContact(id);

            // Assert
            Assert.IsType<Contact>(result);
            Assert.Equal(result?.ContactId, contact.ContactId);
            Assert.Equal(result?.FirstName, contact.FirstName);
        }

        /// <summary>
        ///     Test <see cref="ContactRepository.DeleteContact"/> method.
        ///     Deletes a <see cref="Contact"/>
        /// </summary>
        [Fact]
        public async Task DeleteContact_DeletesContact()
        {
            // Arrange
            using var context = new ContactContext(_contextOptions);
            ContactRepository _contactRepository = new ContactRepository(context);
            int id = 1000;
            var contact = ModelsHelper.GetContactTestData();
            contact.ContactId = id;

            // Act
            await _contactRepository.AddContact(contact);
            var result1 = await _contactRepository.GetContact(id);
            await _contactRepository.DeleteContact(contact);
            var result2 = await _contactRepository.GetContact(id);

            // Assert
            Assert.NotNull(result1);
            Assert.Null(result2);
        }

        /// <summary>
        ///     Test <see cref="ContactRepository.ContactExists"/> method.
        ///     Returns true if <see cref="ContactRepository"/> with Id exists
        /// </summary>
        [Fact]
        public void ContactExists_ReturnsTrueIfContactExists()
        {
            // Arrange
            using var context = new ContactContext(_contextOptions);
            ContactRepository _contactRepository = new ContactRepository(context);
            int id = 1;

            // Act
            var result = _contactRepository.ContactExists(id);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Test <see cref="ContactRepository.ContactExists"/> method.
        ///     Returns false if <see cref="Contact"/> with Id does not exists
        /// </summary>
        [Fact]
        public void ContactExists_ReturnsFalseIfContactNotExists()
        {
            // Arrange
            using var context = new ContactContext(_contextOptions);
            ContactRepository _contactRepository = new ContactRepository(context);
            int id = 9999999;

            // Act
            var result = _contactRepository.ContactExists(id);

            // Assert
            Assert.False(result);
        }
    }
}

