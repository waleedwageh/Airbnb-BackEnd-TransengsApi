using Api.DTOS;
using AutoMapper;
using Domain.Entities;
using Domain.IdentityEntities;

namespace Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            MapProperty();
            MapPropertyDto();

            // Booking
            CreateMap<Booking, BookingDTO>()
            .ReverseMap();
            //User
            CreateMap<ApplicationUser,UserDto>().ReverseMap();
            //Transaction
            CreateMap<transaction,TransactionDto>().ReverseMap();

            // state
            CreateMap<state, StateDTO>()
                .ForMember(d => d.countryName, o => o.MapFrom(s => s.country.name)).ReverseMap();
            //applicationuser
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            //amenity
            CreateMap<amenity, AmenityDto>().ReverseMap();
            //propamenity
            CreateMap<PropertyAmenitiesDto, property_amenities>().ReverseMap();

            //propertyPosting
            CreateMap<PropertyDTo, property>();
            //
            CreateMap<PropertyImagesDto,property_images>();
            CreateMap<property_images, PropertyImagesDto>().ForMember(d=>d.image,o=>o.MapFrom<propertyImagerResolver>());
            CreateMap<PropertyAmenitiesDto,property_amenities>().ReverseMap();
            //create map review
            CreateMap<PropertyReviewsDto, property_reviews>();
            CreateMap<property_reviews, PropertyReviewsDto>().ForMember(d => d.UserName, o => o.MapFrom(s => s.User.DisplayName));



            //////Create State Image 
            CreateMap<state, StateDTO>().ForMember(d => d.PictureUrl, o => o.MapFrom<StateImageResolver>());
            CreateMap< StateDTO, state>();
        }

        public void MapProperty()
        {


            CreateMap<property, PropertyDTo>()
                .ForMember(d => d.CityName, o => o.MapFrom(s => s.City.name))
                .ForMember(d => d.countryName,
                o => o.MapFrom(s => s.country.name))
                .ForMember(d => d.currencyName,
                o => o.MapFrom(s => s.currency.name))
                .ForMember(d => d.propertybeName,
                o => o.MapFrom(s => s.property_tybe.name))
                .ForMember(d => d.stateName, o => o.MapFrom(s => s.state.name));
                
            
        }
        public void MapPropertyDto(){
              //CreateMap<PropertyDTo, property>()
              //  .ForMember(d => d.User,
              //  o => o.MapFrom(s => s.User))
              ////  .ForMember(d=>d.property_amenities,o=>o.MapFrom(s=>s.property_amenities))
              //  .ForMember(d=>d.property_reviews,o=>o.MapFrom(s=>s.property_reviews))
              //  .ForMember(d=>d.property_images,o=>o.MapFrom(s=>s.property_images)); 
        } 
    }
}
