namespace Clean.API.MiddleWares
{
    public class TrackMiddleWare
    {
        private readonly ILogger<TrackMiddleWare> _logger;
        private readonly RequestDelegate _next;

        public TrackMiddleWare(ILogger<TrackMiddleWare> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestSeq = Guid.NewGuid().ToString();
            _logger.LogInformation($"Request Starts {requestSeq}");
            context.Items.Add("RequestSequence", requestSeq);
            await _next(context);
            _logger.LogInformation($"Request Ends {requestSeq}");
        }
    }
}
