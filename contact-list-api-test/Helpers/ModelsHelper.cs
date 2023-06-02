using System;
using contact_list_api.Models;

namespace contact_list_api_test.Helpers
{
	public static class ModelsHelper
	{
        /// <summary>
        ///     Instantiates a <see cref="Contact"/> object
        /// </summary>
        /// <returns>a <see cref="Contact"/> object</returns>

        public static Contact GetContactTestData()
        {
            return new Contact
            {
                ContactId = 1,
                FirstName = "FirstnameTest",
                LastName = "LastNameTest",
                PhoneNumber = "0789823123",
                OfficePhoneNumber = "0119823123",
                Email = "firstnameTest@test.com",
                DateOfBirth = new DateTime()
            };
        }

        public static List<Contact> GetContactListTestData()
        {
            return new List<Contact>
            {
                new Contact
                {
                    ContactId = 1,
                    FirstName = "FirstnameTest1",
                    LastName = "LastNameTest1",
                    PhoneNumber = "0789823123",
                    OfficePhoneNumber = "0119823123",
                    Email = "firstnameTest1@test.com",
                    DateOfBirth = new DateTime()
                },
                new Contact
                {
                    ContactId = 2,
                    FirstName = "FirstnameTest2",
                    LastName = "LastNameTest2",
                    PhoneNumber = "0789823123",
                    OfficePhoneNumber = "0119823123",
                    Email = "firstnameTest2@test.com",
                    DateOfBirth = new DateTime()
                }
            };
        }
    }
}

