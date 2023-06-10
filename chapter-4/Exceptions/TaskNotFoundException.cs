using System;
namespace chapter_4.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException() : base()
        {
        }

        public TaskNotFoundException(string message) : base(message)
        {
        }

        public TaskNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

