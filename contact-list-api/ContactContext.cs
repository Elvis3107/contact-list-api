using System;
using contact_list_api.Models;
using Microsoft.EntityFrameworkCore;

namespace contact_list_api
{
	public class ContactContext : DbContext
    {
		public ContactContext(DbContextOptions options) : base(options)
        {
		}

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                ContactId = 1,
                FirstName = "Elvis",
                LastName = "Thelemuka",
                Email = "elvis@eblocks.co.za",
                DateOfBirth = new DateTime(1991, 07, 31),
                PhoneNumber = "073-607-0756",
                OfficePhoneNumber = "011-607-0756"
            });
        }
    }
}

