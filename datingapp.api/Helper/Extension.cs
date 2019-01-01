using Microsoft.AspNetCore.Http;

namespace datingapp.api.Helper
{
    public static class Extension
    {
        public static void AddApplicaitonError( this HttpResponse response ,string message )
        {
            response.Headers.Add("Application-Error",message);
             response.Headers.Add("Access-Control-Expose-Headers","Application-Error");
              response.Headers.Add("Access-Control-Allow-Origin","*");
        }
    }
}