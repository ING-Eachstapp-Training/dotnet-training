namespace chapter_4.Exceptions
{
	public class NotConnectedException : Exception
    {
        public NotConnectedException() : base()
        {
        }

        public NotConnectedException(string message) : base(message)
        {
        }

        public NotConnectedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

