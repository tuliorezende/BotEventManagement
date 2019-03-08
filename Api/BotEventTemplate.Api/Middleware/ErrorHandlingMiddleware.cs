using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BotEventManagement.Api.Middleware
{
    /// <summary>
    /// Middleware to handle APi errors and return correct status codes
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// Constructor of Error Handling Middleware
        /// </summary>
        /// <param name="next"></param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Default invoke method
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception is WebException webException)
                context.Response.StatusCode = (int)((HttpWebResponse)webException.Response).StatusCode;
            else
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(exception.Message);
        }
    }
}
