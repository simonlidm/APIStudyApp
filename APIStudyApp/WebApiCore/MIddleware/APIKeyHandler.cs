using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebApiCore.Models;

namespace WebApiCore.Middleware
{
    public class APIKeyHandler
    {
        private APIStudyAppDatabaseContext db = new APIStudyAppDatabaseContext();
        private RequestDelegate next;
        public APIKeyHandler (RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            bool isValidAPIKey = false;
            Hashing hash = new Hashing();
            StringValues lsHeaders;

            var checkAPIKeyExists = context.Request.Headers.TryGetValue("apikey",out lsHeaders);

            /*Generate a hash
             * 
             * string generatedHash = hash.HashPassword("");
            Debug.WriteLine(generatedHash);
            */

            if (checkAPIKeyExists)
            {

                string APIClient = lsHeaders.FirstOrDefault();

                var hashkey = db.Keys.Where(x => x.ApikeyId == 1 && x.Status == true).FirstOrDefault();
                    isValidAPIKey = hash.ValidatePassword(APIClient, hashkey.ApikeyHash);

            }
            if (!isValidAPIKey)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("Fel API Nyckel!"); 
            }
            else
            {
                await next.Invoke(context);
            }
        }
       
    }
    public static class MyHandlerExtensions
    {
        public static IApplicationBuilder UseAPIKeyHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<APIKeyHandler>();
        }
    }
}