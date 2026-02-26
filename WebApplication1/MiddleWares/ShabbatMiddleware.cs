using Microsoft.Extensions.Logging;

namespace Clean.API.MiddleWares
{
    public class ShabbatMiddleware
    {
        private readonly RequestDelegate _next;


        public ShabbatMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            var currentDay = DateTime.UtcNow.DayOfWeek;
            if (currentDay == DayOfWeek.Friday || currentDay == DayOfWeek.Saturday)
            {
                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                await context.Response.WriteAsync("The service is unavailable on Shabbat.");
            }
            else
            {
                Console.WriteLine("Handling request...");
                await _next(context);

            }
        }
    }
}
