using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api.ApplictionExtentions
{
    public static class ApplicationSwaggerSettings
    {
        public static IServiceCollection AddSwaggerSetting(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
           });
            return services;

        }
        public static IApplicationBuilder UseSwaggerSettings(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airbnbks Api"));

            return app;
        }
    }
}