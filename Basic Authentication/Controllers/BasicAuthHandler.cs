using System.Text;

namespace Basic_Authentication.Controllers
{
    public class BasicAuthHandler
    {
        // The next middleware component in the pipeline and the realm for authentication
        private readonly RequestDelegate _requestDelegate;
        private readonly string realm;

        // Constructor to initialize the handler with the next middleware and realm
        public BasicAuthHandler(RequestDelegate _requestDelegate, string realm)
        {
            this._requestDelegate = _requestDelegate;
            this.realm = realm;
        }

        // Middleware method to handle basic authentication
        public async Task InvokeAsync(HttpContext context)
        {
            // Check if the request contains the 'Authorization' header
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                // If not, respond with 401 Unauthorized status
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            // Extract the encoded credentials from the 'Authorization' header
           // var header = context.Response.Headers["Authorization"].ToString();
           // var encodedCreds = header.Substring(6);


            // Extract the encoded credentials from the 'Authorization' header
            var header = context.Request.Headers["Authorization"].ToString();

            // Check if the 'Authorization' header is not null and has a length greater than or equal to 6
            if (string.IsNullOrEmpty(header) || header.Length < 6)
            {
                // If not, respond with 401 Unauthorized status
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            var encodedCreds = header.Substring(6);


            // Decode the credentials from Base64
            var creds = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCreds));
            string[] uidpwd = creds.Split(':');
            var uid = uidpwd[0];
            var pwd = uidpwd[1];

            // Check if the decoded username and password match the expected values
            if (uid != "kopi" || pwd != "password")
            {
                // If not, respond with 401 Unauthorized status
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            // Call the next middleware in the pipeline
            await _requestDelegate(context);
        }
    }

}
