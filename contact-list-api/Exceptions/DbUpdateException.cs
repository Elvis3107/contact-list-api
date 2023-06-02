using System;
namespace contact_list_api.Exceptions
{
	public class DbUpdateException : Exception
    {
        public DbUpdateException(string message) : base(message)
        { }
	}
}

