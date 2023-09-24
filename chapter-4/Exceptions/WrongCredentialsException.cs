using System;
namespace chapter_4.Exceptions
{
    public class WrongCredentialsException : Exception
    {
        public WrongCredentialsException() : base()
        {
        }

        public WrongCredentialsException(string message) : base(message)
        {
        }

        public WrongCredentialsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

