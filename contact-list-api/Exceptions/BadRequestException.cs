using System;
namespace contact_list_api.Exceptions
{
	public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        { }
    }
}

