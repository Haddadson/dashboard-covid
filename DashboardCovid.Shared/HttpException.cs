﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace DashboardCovid.Shared
{
    [Serializable]
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public HttpException() { }

        public HttpException(string message, Exception innerException) : base(message, innerException) { }

        protected HttpException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HttpException(HttpStatusCode statusCode, string mensagem) : base(mensagem)
        {
            StatusCode = statusCode;
        }
    }
}
