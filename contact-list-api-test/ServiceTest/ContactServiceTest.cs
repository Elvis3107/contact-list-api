using System;
using contact_list_api.Models;
using contact_list_api.Services;
using contact_list_api_test.Helpers;
using contact_list_api.Repository;
using Moq;

namespace contact_list_api_test.ServiceTest
{
    /// <summary>
    ///     Provide tests for the <see cref="ContactService" />
    /// </summary>
    public class ContactServiceTest
	{
        /// <summary>
        ///     Local instance of  <see cref="ContactService"/> services
        /// </summary>
        private readonly ContactService _contactService;

        /// <summary>
        ///     Local Mock instance for <see cref="IContactRepository"/>
        /// </summary>
        private readonly Mock<IContactReposity<Contact>> _contactRepositoryMock;

        /// <summary>
        ///    Instantiates the class
        ///    Instantiates local _contactServiceMock, _contactService
        /// </summary>
        public ContactServiceTest()
        {
            _contactRepositoryMock = new Mock<IContactReposity<Contact>>();
            _contactService = new ContactService(_contactRepositoryMock.Object);
        }

        /// <summary>
        ///     Test <see cref="ContactsServices.GetContactAsync"/> method.
        ///     Returns list of <see cref="Contact"/>
        /// </summary>
        [Fact]
        public async Task GetContactAsync_ReturnsListOfContact()
        {
            // Arrange
            var contacts = ModelsHelper.GetContactListTestData();

            _contactRepositoryMock.Setup(s => s.GetAllContacts()).ReturnsAsync(contacts);

            // Act
            var result = await _contactService.GetContactAsync();

            // Assert
            Assert.IsType<List<Contact>>(result);
        }

        /// <summary>
        ///     Test <see cref="ContactsServices.GetContact"/> method.
        ///     Returns a <see cref="Contact"/>
        /// </summary>
        [Fact]
        public async Task GetContactAsync_ReturnsContact()
        {
            // Arrange
            int id = 1;
            var contact = ModelsHelper.GetContactTestData();
            _contactRepositoryMock.Setup(s => s.GetContact(id)).ReturnsAsync(contact);

            // Act
            var result = await _contactService.GetContactAsync(id);

            // Assert
            Assert.IsType<Contact>(result);
        }

        /// <summary>
        ///     Test <see cref="ContactsServices.GetContact"/> method.
        ///     Returns Null Found on non-existing id.
        /// </summary>
        [Fact]
        public async Task GetContactAsync_ReturnsNullOnNonExistingId()
        {
            //Arrange
            _contactRepositoryMock.Setup(s => s.GetContact(0)).ReturnsAsync(() => null);

            //Act
            var result = await _contactService.GetContactAsync(0);

            //Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Test <see cref="ContactsServices.CreateContactAsync"/> method.
        ///     Inserts a <see cref="Contact"/>
        /// </summary>
        [Fact]
        public async Task PostContactAsync_InsertsContact()
        {
            // Arrange
            int id = 1000;
            var testData = ModelsHelper.GetContactTestData();
            testData.ContactId = id;
            testData.FirstName = "First";
            testData.LastName = "Last";
            testData.Email = "first@test.com";
            testData.PhoneNumber = "0892345444";

            _contactRepositoryMock.Setup(s => s.GetContact(id)).ReturnsAsync(testData);

            // Act
            await _contactService.CreateContactAsync(testData);
            var result = await _contactService.GetContactAsync(id);

            // Assert
            Assert.IsType<Contact>(result);
            Assert.Equal(result?.ContactId, testData.ContactId);
            Assert.Equal(result?.FirstName, testData.FirstName);
        }

        /// <summary>
        ///     Test <see cref="ContactsServices.UpdateContactAsync"/> method.
        ///     Updates an existing <see cref="Contact"/>
        /// </summary>
        [Fact]
        public async Task PutContactAsync_UpdatesContact()
        {
            // Arrange
            int id = 1000;
            var testData = ModelsHelper.GetContactTestData();
            testData.ContactId = id;
            testData.FirstName = "First";
            testData.LastName = "Last";
            testData.Email = "first@test.com";
            testData.PhoneNumber = "0892345444";

            _contactRepositoryMock.Setup(s => s.GetContact(id)).ReturnsAsync(testData);

            // Act
            await _contactService.UpdateContactAsync(id, testData);
            var result = await _contactService.GetContactAsync(id);

            // Assert
            Assert.IsType<Contact>(result);
            Assert.Equal(result?.ContactId, testData.ContactId);
            Assert.Equal(result?.FirstName, testData.FirstName);
        }

        /// <summary>
        ///     Test <see cref="ContactsServices.ContactExists"/> method.
        ///     Returns true if Contact exists
        /// </summary>
        [Fact]
        public async Task ContactExists_ReturnsTrueIfExists()
        {
            // Arrange
            var testData = ModelsHelper.GetContactTestData();
            await _contactService.UpdateContactAsync(testData.ContactId, testData);

            _contactRepositoryMock.Setup(s => s.ContactExists(testData.ContactId)).Returns(() => true);

            // Act
            var result = _contactService.ContactExists(testData.ContactId);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Test <see cref="ContactsServices.ContactExists"/> method.
        ///     Returns false if Contact does not exists
        /// </summary>
        [Fact]
        public void ContactExists_ReturnsFalseIfNotExists()
        {
            // Arrange
            _contactRepositoryMock.Setup(s => s.ContactExists(999999)).Returns(() => false);

            // Act
            var result = _contactService.ContactExists(999999);

            // Assert
            Assert.False(result);
        }

    }
}

