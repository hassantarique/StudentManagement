//using Microsoft.Extensions.Primitives;

//namespace StudentManagement.API.Middleware
//{
//    public class ApiKeyMiddleware_1
//    {
//        private readonly RequestDelegate _next; // Function pointer, represents next middleware in the request pipeline
//        private const string _ApiKeyName = "XApiKey";

//        public ApiKeyMiddleware_1(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async Task InvokeAsync(HttpContext context, IConfiguration config)
//        {
//            bool apiKeyPresentInHeader = context.Request.Headers.TryGetValue(_ApiKeyName, out StringValues extractedApiKey);
//            string? apiKey = config[_ApiKeyName];

//            if (apiKeyPresentInHeader && apiKey.Equals(extractedApiKey))
//            {
//                await _next(context); // Proceed after Api keys match
//                return;
//            }
//            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
//            await context.Response.WriteAsync("Invalid Api Key");

//            context.Response.StatusCode = StatusCodes.Status500InternalServerError; //Unreachable if 401 is returned
//            await context.Response.WriteAsync("An error occurred, please try again later.");
//        }
//    }

//    public static class ApiKeyMiddlewareExtensions_1 // Static class to hold extension method
//    {
//        public static IApplicationBuilder UseApiKeyMiddleware_1(this IApplicationBuilder builder)
//        {
//            return builder.UseMiddleware<ApiKeyMiddleware_1>();
//        }
//    }
//}

//// Checks for a valid Api key, if found correct, forwards the request to the next middleware in the pipeline,
//// If the key is missing, 401 unaturhorized is returned