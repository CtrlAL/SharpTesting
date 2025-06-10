using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers.ExceptionFilters
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
	public class NotFoundFilterAttribute : TypeFilterAttribute
	{
		public NotFoundFilterAttribute()
		: base(typeof(NotFoundFilter))
		{
		}
	}
}
