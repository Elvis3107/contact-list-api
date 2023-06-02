using System;
namespace contact_list_api.Exceptions
{
	public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException(string message) : base(message)
        { }
    }
}

