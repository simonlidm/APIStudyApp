using APIStudyApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APIStudyApp.Security
{
    public class APIKeyHandler:DelegatingHandler
    {
        private APIStudyAppDatabaseEntities db = new APIStudyAppDatabaseEntities();

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken cancellationToken)
        {
            bool isValidAPIKey = false;
            IEnumerable<string> lsHeaders;
            Hashing hash = new Hashing();
            var checkAPIKeyExists = request.Headers.TryGetValues("apikey", out lsHeaders);
            
            /*Generate a hash
             * 
             * string generatedHash = hash.HashPassword("");
            Debug.WriteLine(generatedHash);
            */

            if(checkAPIKeyExists)
            {
                
                string APIClient = lsHeaders.FirstOrDefault();
                try
                {
                    var hashkey = db.Keys.Where(x => x.APIKeyId == 1 && x.Status == true).FirstOrDefault();
                    isValidAPIKey = hash.ValidatePassword(APIClient, hashkey.APIKeyHash);

                }
                catch
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "API Nyckel problem");

                }

            }
            if (!isValidAPIKey)
            {     
                return request.CreateResponse(HttpStatusCode.Forbidden, "Fel API Nyckel");
            }
                var response =await base.SendAsync(request, cancellationToken);
                return response;
        }
    }
}