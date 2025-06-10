using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace TestApi.Controllers.ExceptionFilters
{
	public class NotFoundFilter : IExceptionFilter
	{
		private readonly ILogger<NotFoundFilter> _logger;
		public NotFoundFilter(ILogger<NotFoundFilter> logger)
		{
			_logger = logger;
		}

		public void OnException(ExceptionContext context)
		{

			if (context.Exception.Message.Contains("Entity not found"))
			{
				_logger.LogError(context.Exception, "Unhandled exception occurred: {Message}", context.Exception.Message);

				context.Result = new BadRequestObjectResult(new
				{
					error = "Entity not found",
					message = context.Exception.Message
				});
			}
		}
	}
}
