using System;
using System.Runtime.Serialization;

namespace LearnChess.Abstractions.Domain.Exceptions
{
    public class DomainConstraintViolationException : Exception
    {
        public DomainConstraintViolationException()
        {
        }

        protected DomainConstraintViolationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DomainConstraintViolationException(string message) : base(message)
        {
        }

        public DomainConstraintViolationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}