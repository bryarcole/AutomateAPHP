using System;
using System.Runtime.Serialization;

namespace TFSCommon.Exceptions
{
    [Serializable]
    internal class MissingPersonalAccessTokenException : Exception
    {
        public MissingPersonalAccessTokenException()
        {
        }

        public MissingPersonalAccessTokenException(string message) : base(message)
        {
        }

        public MissingPersonalAccessTokenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingPersonalAccessTokenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}