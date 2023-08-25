using Azure;
using Azure.Core;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.Extensions;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Things;
using Wolt.Entities.Entities.UserEntities;
using WOLT.DAL.Repository.Abstract;

namespace Wolt.BLL.Configurations
{
    public class ApiCustomLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiCustomLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

       public async Task Invoke(HttpContext context)
            {
                try
                {
                    IUserAuthRepository repository = context.RequestServices.GetService<IUserAuthRepository>();

                var userId = GetIdFromHeaders(context.Request.Headers);

                string requestBody = ""; //  await GetRequestBodyAsStringAsync(context);
                string responseBody = ""; // await GetResponseBodyAsStringAsync(context);

                await _next(context);

                if (userId == 0)
                {
                   var logMessage = $"Request Content:\n{requestBody}\n\n" +
                                    $"Response Content:\n{responseBody}\n";

                    Log.Information(logMessage);
                }
                else
                {
                    User user = await repository.GetAsync(userId);

                    var apiPath = context.Request.Path;
                    var requestDate = DateTimeOffset.Now;

                    var logMessage = $"userId: {user.Id}\n" +
                                     $"userEmail: {user.Email}\n" +
                                     $"ApiUrl: {apiPath}\n" +
                                     $"Request Status: {context.Response.StatusCode}\n" +
                                     $"Request Date: {requestDate}\n";

                    if (context.Response.StatusCode / 100 == 4)
                    {

                        logMessage += $"Request Content:\n{requestBody}\n\n" +
                                      $"Response Content:\n{responseBody}\n";

                        Log.Error(logMessage);
                    }
                    else
                    {

                        logMessage += $"Request Content:\n{requestBody}\n\n" +
                                      $"Response Content:\n{responseBody}\n";

                          Log.Information(logMessage);
                    }
                }
                   
                }
                catch (Exception ex)
                {
                    Log.Error($"An error occurred: {ex}");
                }
                finally
               {
               
              }
                
        }

        private async Task<string> GetRequestBodyAsStringAsync(HttpContext context)
        {
            context.Request.EnableBuffering();

            var originalRequestBody = context.Request.Body;
            var clonedRequestBody = new MemoryStream();

            await context.Request.Body.CopyToAsync(clonedRequestBody);
            clonedRequestBody.Seek(0, SeekOrigin.Begin);

            using (StreamReader reader = new StreamReader(clonedRequestBody, Encoding.UTF8))
            {
                string requestBody = await reader.ReadToEndAsync();
                clonedRequestBody.Seek(0, SeekOrigin.Begin);
                context.Request.Body = clonedRequestBody; // Restore the request body stream position

                _next(context);
                return requestBody;
            }
        }



        #region

       
        private async Task<string> GetResponseBodyAsStringAsync(HttpContext context)
        {
            Stream originalBody = context.Response.Body;

            try
            {
                using (var memStream = new MemoryStream())
                {
                    context.Response.Body = memStream;

                    memStream.Position = 0;
                    string responseBody = new StreamReader(memStream).ReadToEnd();

                    memStream.Position = 0;
                    await memStream.CopyToAsync(originalBody);

                    return responseBody;
                }

            }
            finally
            {
                context.Response.Body = originalBody;
            }

        }

        

        #endregion


        #region 

        /*
        public async Task<string> GetResponseBodyAsStringAsync(HttpContext context)
        {
            var originalResponseBody = context.Response.Body;

            try
            {
                using var responseBodyStream = new MemoryStream();
                context.Response.Body = responseBodyStream;

              //  await _next(context);

                responseBodyStream.Seek(0, SeekOrigin.Begin);

                using var reader = new StreamReader(responseBodyStream, Encoding.UTF8);
                return await reader.ReadToEndAsync();
            }
            finally
            {
                context.Response.Body = originalResponseBody; // Restore the original response body
            }
        }

        */

        #endregion


        private int GetIdFromHeaders(IHeaderDictionary headers)
        {
          string token = headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");

             if(token == null)
                return 0;

          return JwtService.GetIdFromToken(token);
        }
        
    }
}
