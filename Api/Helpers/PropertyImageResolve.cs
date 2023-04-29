using Api.DTOS;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;



namespace Api.Helpers
{
    public class propertyImagerResolver : IValueResolver<property_images, PropertyImagesDto, string>
    {
        private readonly IConfiguration configuration;



        public propertyImagerResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }



        public string Resolve(property_images source, PropertyImagesDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.image))
            {
                return "https://localhost:44351/Images/PropertyImages/" + source.image;
            }
            return null;
        }
    }
}
