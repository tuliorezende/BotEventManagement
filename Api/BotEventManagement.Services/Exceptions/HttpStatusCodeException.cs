using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace BotEventManagement.Services.Exceptions
{
    public class HttpStatusCodeException : Exception
    {
        public HttpStatusCodeException(HttpStatusCode statusCode)
        {
            SaveStatusCode(statusCode);
        }

        public HttpStatusCodeException(HttpStatusCode statusCode, string message) : base(message)
        {
            SaveStatusCode(statusCode);
        }

        public HttpStatusCodeException(HttpStatusCode statusCode, string message, Exception innerException) : base(message, innerException)
        {
            SaveStatusCode(statusCode);
        }

        protected HttpStatusCodeException(HttpStatusCode statusCode, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            SaveStatusCode(statusCode);
        }

        private void SaveStatusCode(HttpStatusCode statusCode)
        {
            StatusCode = (int)statusCode;
        }

        public int StatusCode { get; set; }
    }
}
