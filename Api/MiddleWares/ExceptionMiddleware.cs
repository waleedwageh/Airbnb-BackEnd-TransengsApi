using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Api.ErrorsHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api.MiddleWares
{
    public class ExceptionMiddleware
    {
          private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment host;

        public ExceptionMiddleware(RequestDelegate next
        , ILogger<ExceptionMiddleware> logger
        , IHostEnvironment host)
        {
            this.next = next;
            this.logger = logger;
            this.host = host;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = host.IsDevelopment()
                ?new ApiExceptionRespone((int)HttpStatusCode.InternalServerError,ex.Message
                ,ex.StackTrace.ToString()):new ApiExceptionRespone((int)HttpStatusCode.InternalServerError);

                var options =new JsonSerializerOptions{PropertyNamingPolicy=JsonNamingPolicy.CamelCase};

                var jsonResponse = JsonSerializer.Serialize(response,options);
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}