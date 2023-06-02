using System;
namespace contact_list_api.Exceptions
{
	public class InternalServerException : Exception
    {
        public InternalServerException(string message) : base(message)
        { }
	}
}

