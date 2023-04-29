using System.Linq;
using Api.ErrorsHandlers;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repo;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.ApplictionExtentions
{
    public static class ApplicationServicesExtention
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services){
            
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped<ITokenService,TokenService>();

            services.Configure<ApiBehaviorOptions>(Opt =>
            {
                Opt.InvalidModelStateResponseFactory=ActionContext=>{
                  var errors =  ActionContext.ModelState.Where(x=>x.Value.Errors.Count>0)
                    .SelectMany(y=>y.Value.Errors)
                    .Select(y=>y.ErrorMessage)
                    .ToArray();
                    var ValidationErrors = new ApiValidationError{
                        Errors=errors
                    };
                    return new BadRequestObjectResult(ValidationErrors);

                };
            });
            return services;
        }
        
    }
}