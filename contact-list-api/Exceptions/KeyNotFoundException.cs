using System;
namespace contact_list_api.Exceptions
{
	public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException(string message) : base(message)
        { }
    }
}

