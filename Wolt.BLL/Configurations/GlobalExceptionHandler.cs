using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Wolt.BLL.Exceptions;

using NotImplementedException = Wolt.BLL.Exceptions.NotImplementedException;
using UnauthorizedAccessException = Wolt.BLL.Exceptions.UnauthorizedAccessException;

namespace Wolt.BLL.Configurations;

    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;

          
            string message = "";

            var exceptionType = ex.GetType();

            if (exceptionType == typeof(BadRequestException))
            {
                message = ex.Message;
                statusCode = HttpStatusCode.BadRequest;
                
            }

            else if (exceptionType == typeof(NotImplementedException))
            {
                message = ex.Message;
                statusCode = HttpStatusCode.NotImplemented;
               
            }

            else if (exceptionType == typeof(NotFoundException))
            {
                message = ex.Message;
                statusCode = HttpStatusCode.NotFound;
                
            }

            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = ex.Message;
                statusCode= HttpStatusCode.Unauthorized;
                
            }

            else if (exceptionType == typeof(NullException))
            {
                message = ex.Message;
                statusCode = HttpStatusCode.BadRequest;
                
            }

            else if (exceptionType == typeof(AlreadyDoneException))
            {
               message= ex.Message;
               statusCode = HttpStatusCode.Conflict;
            }

            else
            {
                message = ex.Message;
                statusCode = HttpStatusCode.InternalServerError;
               
            }

            var exceptionResult = JsonSerializer.Serialize(new { Result = "failed",  Error = message  });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(exceptionResult);
        }

    }

