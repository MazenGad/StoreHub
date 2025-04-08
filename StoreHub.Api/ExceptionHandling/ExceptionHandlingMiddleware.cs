using System.Net;
using System.Text.Json;

namespace StoreHub.Api.ExceptionHandling
{
	public class ExceptionHandlingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionHandlingMiddleware> _logger;

		public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context); // لو مفيش استثناء، كمل
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Unhandled exception");

				context.Response.ContentType = "application/json";
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

				var response = new
				{
					message = ex.Message,
					statusCode = context.Response.StatusCode
				};

				await context.Response.WriteAsync(JsonSerializer.Serialize(response));
			}
		}
	}

}
