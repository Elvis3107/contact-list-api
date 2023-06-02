using System;
namespace contact_list_api.Configurations
{
	public static class ApplicationBuilderExtension
	{
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseMiddleware<GlobalErrorHandlingMiddleware>();
    }
}

