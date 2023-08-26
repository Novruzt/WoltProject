using Azure;
using Azure.Core;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.Exceptions;
using Wolt.BLL.Extensions;
using Wolt.BLL.Services.Abstract;
using Wolt.BLL.Things;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;
using WOLT.DAL.DATA;
using WOLT.DAL.Repository.Abstract;
using WOLT.DAL.UnitOfWork.Abstract;

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
           

                // Capture the request information
                int userId = GetIdFromHeaders(context.Request.Headers); // Claim type "Id"

                IUserAuthRepository repository = context.RequestServices.GetService<IUserAuthRepository>();
                IWoltRepository woltRepository = context.RequestServices.GetService<IWoltRepository>();
                IUnitOfWork unitOfWork = context.RequestServices.GetService<IUnitOfWork>();

                string userEmail = string.Empty;
                if (userId == 0 || userId==null)
            {
                userId =0;
                userEmail = "Anonim";
            }
            else
            {
                User user = await repository.GetAsync(userId);

                    if (user == null)
                        userEmail = "Anonim";

                    else
                    userEmail = user.Email; // Claim type "email"
            }

            WoltLog woltLog = new WoltLog()
            {
                userId= userId,
                userEmail= userEmail,
               
            };


            string apiUrl = context.Request.Path.Value;
            woltLog.ApiUrl = apiUrl;
            DateTime requestDate = DateTime.Now;

      
            try
            {

                //  string apiUrl = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}";

                await _next(context);

                int statusCode = context.Response.StatusCode;

           //    Stream originalBody = context.Response.Body;
                string requestBody = await ReadRequestBody(context.Request);

                /*
                
                var originalResponseBody = context.Response.Body;

            //     Stream originalBody = context.Response.Body;

                    using (var memStream = new MemoryStream())
                    {
                        context.Response.Body = memStream;
                        
                        memStream.Position = 0;
                        string responseBody = new StreamReader(memStream).ReadToEnd();

                        memStream.Position = 0;
                        await memStream.CopyToAsync(originalResponseBody);
                    }

                */

                
                if (statusCode / 100 == 4)
                {
                    Log.Information(
                            "UserId: {UserId}, \nUserEmail: {UserEmail},\nApiURL: {apiUrl} \nRequestDate: {RequestDate}, \nRequestContent: {RequestContent}, \nStatusCode: {StatusCode}, \nResponseContent: {ResponseContent}",
                            userId, userEmail, apiUrl, requestDate, requestBody, statusCode, "Not Succeed\n-----------------------------------\n");
                    woltLog.StatusCode = statusCode;
                }

                else
                {
                    Log.Information(
                            "UserId: {UserId}, \nUserEmail: {UserEmail}, \n ApiURL: {apiUrl}\nRequestDate: {RequestDate}, \nRequestContent: {RequestContent}, \nStatusCode: {StatusCode}, \nResponseContent: \n{ResponseContent}",
                            userId, userEmail, apiUrl, requestDate, requestBody, statusCode, "Succeed\n-----------------------------------\n");
                    woltLog.StatusCode = statusCode;
                }

                

            }
            catch (Exception ex)
            {
                // Log the exception before re-throwing it
                Log.Information(
                            "UserId: {UserId}, \nUserEmail: {UserEmail},\nApiURL: {apiUrl} \nRequestDate: {RequestDate},  \nStatusCode: {StatusCode}, \nResponseContent: {ResponseContent}",
                            userId, userEmail, apiUrl, requestDate, context.Response.StatusCode , "Not Succeed\n-----------------------------------\n");

                woltLog.StatusCode = context.Response.StatusCode;
                throw new BadRequestException(ex);

               
            }
            finally
            {
                
                await woltRepository.AddLogAsync(woltLog);
                await unitOfWork.CommitAsync();

            }
        }



        #region

        /*

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


        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableBuffering();

            using var reader = new StreamReader(request.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true);
            string body = await reader.ReadToEndAsync();
            request.Body.Seek(0, SeekOrigin.Begin);

            return body;
        }

        private async Task<string> ReadResponseBody(Stream responseBodyStream)
        {
            responseBodyStream.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(responseBodyStream, Encoding.UTF8);
            string body = await reader.ReadToEndAsync();
            responseBodyStream.Seek(0, SeekOrigin.Begin);

            return body;
        }

        private int GetIdFromHeaders(IHeaderDictionary headers)
        {
          string token = headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");

             if(token == null)
                return 0;

          return JwtService.GetIdFromToken(token);
        }

        private bool IsTokenGiven(IHeaderDictionary headers)
        {
            string token = headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");

            if (token != null)
                return true;

            return false;
        }
        
    }
}
