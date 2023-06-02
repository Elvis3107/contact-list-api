using System;
using contact_list_api.Controllers;
using contact_list_api.Exceptions;
using contact_list_api.Models;
using contact_list_api.Repository;
using contact_list_api.Services.Interface;
using contact_list_api_test.Helpers;
using contact_list_api_test.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;


namespace contact_list_api_test.ContactControllerTest
{
    /// <summary>
    ///     Provide tests for the <see cref="ContactController"/>
    /// </summary>
    public class ContactControllerTest
	{
        /// <summary>
        ///     Local instance of  <see cref="ContactController"/> controller
        /// </summary>
        private readonly ContactController _contactController;

        /// <summary>
        ///     Local Mock instance for <see cref="IContactService"/>
        /// </summary>
        private readonly Mock<IContactService> _contactServiceMock;

        
        public ContactControllerTest()
        {
            _contactServiceMock = new Mock<IContactService>();
            _contactController = new ContactController(_contactServiceMock.Object);
        }

        /// <summary>
        ///     Test <see cref="ContactController.GetAllContacts"/> method.
        ///     Returns Ok. Returns list of <see cref="Contact"/>
        /// </summary>
        [Fact]
        public async Task GetContact_ReturnsListOfContactOk()
        {
            var contacts = ModelsHelper.GetContactListTestData();

            _contactServiceMock.Setup(s => s.GetContactAsync()).ReturnsAsync(contacts);

            var actionResult = await _contactController.GetAllContacts() as OkObjectResult;
            List<Contact>? result = actionResult?.Value as List<Contact>;

            Assert.IsType<OkObjectResult>(actionResult);
            Assert.IsType<List<Contact>>(result);
        }

        /// <summary>
        ///     Test <see cref="ContactController.GetAllContacts"/> method.
        ///     Returns Not Found if null/>
        /// </summary>
        [Fact]
        public async Task GetContact_ReturnsNotFoundIfNull()
        {
            _contactServiceMock.Setup(s => s.GetContactAsync()).ReturnsAsync(() => null);

            var actionResult = await _contactController.GetAllContacts();

            Assert.IsType<NotFoundResult>(actionResult);
        }

        /// <summary>
        ///     Test <see cref="ContactController.GetContactById"/> method.
        ///     Returns Ok. Returns a <see cref="Contact"/>
        /// </summary>
        [Fact]
        public async Task GetContact_ReturnsContactOk()
        {
            // Arrange
            int id = 1;
            var moqData = ModelsHelper.GetContactTestData();

            _contactServiceMock.Setup(s => s.GetContactAsync(id)).ReturnsAsync(moqData);

            // Act
            var actionResult = await _contactController.GetContactById(id) as OkObjectResult;
            var result = actionResult?.Value as Contact;

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.IsType<Contact>(result);
            Assert.Equal(moqData.ContactId, result.ContactId);
            Assert.Equal(moqData.FirstName, result.FirstName);
        }

        /// <summary>
        ///     Test <see cref="ContactController.GetContactById"/> method.
        ///     Returns Not Found on non-existing id.
        /// </summary>
        [Fact]
        public async Task GetContact_ReturnsNotFoundOnNonExistingId()
        {
            //Arrange
            _contactServiceMock.Setup(s => s.GetContactAsync(0)).ReturnsAsync(() => null);

            //Act
            var actionResult = await _contactController.GetContactById(0);

            //Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }

        /// <summary>
        ///     Test <see cref="ContactController.CreateNewContact"/> method.
        ///     Returns Ok. Inserts a new <see cref="Contact"/>.
        /// </summary>
        [Fact]
        public async Task PostContact_InsertsAndReturnsNewContactOk()
        {
            // Arrange
            var contact = ModelsHelper.GetContactTestData();


            // Act
            var actionResult = await _contactController.CreateNewContact(contact) as CreatedResult;
            var result = actionResult?.Value as Contact;

            // Assert
            Assert.IsType<CreatedResult>(actionResult);
            Assert.IsType<Contact>(result);
            Assert.Equal(result?.ContactId, contact.ContactId);
            Assert.Equal(result?.FirstName, contact.FirstName);
        }

        /// <summary>
        ///     Test <see cref="ContactController.UpdateContact"/> method.
        ///     Returns Ok. Updates a <see cref="Contact"/>.
        /// </summary>  
        [Fact]
        public async Task PutContact_UpdatesContactOk()
        {
            // Arrange
            int id = 1;
            var contact = ModelsHelper.GetContactTestData();
            var updatedContact = ModelsHelper.GetContactTestData();

            _contactServiceMock.Setup(s => s.GetContactAsync(id)).ReturnsAsync(updatedContact);

            // Act
            var actionResult = await _contactController.UpdateContact(id, contact) as OkObjectResult;
            var result = actionResult?.Value as Contact;

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.IsType<Contact>(result);
            Assert.Equal(result?.ContactId, contact.ContactId);
            Assert.Equal(result?.FirstName, contact.FirstName);
        }

        /// <summary>
        ///     Test <see cref="ContactController.UpdateContact"/> method.
        ///     Returns BadRequest if id is invalid.
        /// </summary>  
        [Fact]
        public async Task PutContact_ReturnsBadRequestOnInvalidId()
        {
            // Arrange
            int id = 0;
            var contact = ModelsHelper.GetContactTestData();

            _contactServiceMock.Setup(s => s.GetContactAsync(id)).ReturnsAsync(() => null);

            // Act
            var actionResult = await _contactController.UpdateContact(id, contact);

            // Assert
            Assert.IsType<BadRequestResult>(actionResult);
        }

        /// <summary>
        ///     Test <see cref="ContactController.UpdateContact"/> method.
        ///     Returns BadRequest on DbUpdateConcurrencyException.
        /// </summary>  
        [Fact]
        public async Task PutContact_ReturnsBadRequestOnException()
        {
            // Arrange
            int id = 0;
            var contact = ModelsHelper.GetContactTestData();

            _contactServiceMock.Setup(s => s.GetContactAsync(id)).Throws<DbUpdateConcurrencyException>();

            // Act
            var actionResult = await _contactController.UpdateContact(id, contact);

            // Assert
            Assert.IsType<BadRequestResult>(actionResult);
        }

        /// <summary>
        ///     Test <see cref="ContactController.DeleteContact"/> method.
        ///     Returns NotFound on invalid Id.
        /// </summary>  
        [Fact]
        public async Task DeleteContact_ReturnsNotFoundOnInvalidId()
        {
            // Arrange
            var id = 1;

            // Act
            var actionResult = await _contactController.DeleteContact(id);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }
    }
}

