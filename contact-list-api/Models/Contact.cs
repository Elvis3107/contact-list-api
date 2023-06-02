using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace contact_list_api.Models
{
    /// <summary>
    ///     Represents an Contact
    /// </summary>
    public class Contact
	{
        /// <summary>
        ///     Get or set the <see cref="long"/> primary Id property
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ContactId { get; set; }

        /// <summary>
        ///     Get or set the <see cref="string"/> firstName property
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Get or set the <see cref="string"/> lastName property
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Get or set the <see cref="DateTime"/> date of birth property
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        ///     Get or set the <see cref="string"/> phone number property
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     Get or set the <see cref="string"/> office phone number property
        /// </summary>
        public string OfficePhoneNumber { get; set; }

        /// <summary>
        ///     Get or set the <see cref="string"/> email property
        /// </summary>
        public string Email { get; set; }
    }
}

