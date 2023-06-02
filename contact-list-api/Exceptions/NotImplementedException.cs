using System;
namespace contact_list_api.Exceptions
{
	public class NotImplementedException : Exception
    {
        public NotImplementedException(string message) : base(message)
        { }
    }
}

