using System;
namespace contact_list_api.Exceptions
{
	public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        { }
    }
}

