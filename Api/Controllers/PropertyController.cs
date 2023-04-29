using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.ApplictionExtentions;
using Api.DTOS;
using Api.ErrorsHandlers;
using Api.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.EntitiesSpecification.Propertyspec;
using Domain.IdentityEntities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    public class PropertyController : ApiBaseController
    {
        private readonly IGenericRepo<property> _genericRepo;

        private readonly IMapper _mapper;
        private readonly ApplicationContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public PropertyController(
            IGenericRepo<property> genericRepo,
            IMapper mapper,
            ApplicationContext context,
            UserManager<ApplicationUser> userManager
        )
        {
            _mapper = mapper;
            this.context = context;
            this.userManager = userManager;
            _genericRepo = genericRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<PropertyWithImageDto>>>
        GetProperties([FromQuery]PropertySpecParams specParams)
        {
            var spec = new PropertySpecwithFiltersAndIncludes(specParams);
            var specCount = new PropertySpecWithFilters(specParams);
            var propertiesWithoutIncludes = await _genericRepo.ListAllBySpec(specCount);
           // var propcounted = FilTer(propertiesWithoutIncludes,specParams);
            var properties = await _genericRepo.ListAllBySpec(spec);

           // var propertiesfiltered = FilTer(properties, specParams);
            //var propertiesfiltered = properties.Where(x=>(!specParams.StateId.HasValue || x.state_id == specParams.StateId)).ToList();
           // var data =
                //_mapper
                //    .Map
                //    <List<property>, List<PropertyDTo>>(propertiesfiltered);
            List<PropertyWithImageDto> propertyWithImageDtos = new List<PropertyWithImageDto>();
            foreach (var prop in properties)
            {
                var propimages = prop.property_images.ToList();
                var propdto = _mapper.Map<property, PropertyDTo>(prop);
                var imgaesdto = _mapper.Map<List<property_images>, List<PropertyImagesDto>>(propimages);
                propertyWithImageDtos.Add(new PropertyWithImageDto { PropertyDTo = propdto, propertiesimages = imgaesdto });
            }

            return Ok(new Pagination<PropertyWithImageDto>(specParams.PageIndex,
                specParams.PageSize,
                 propertiesWithoutIncludes.Count(),
                propertyWithImageDtos));
        }



        //private List<property> FilTer(IReadOnlyList<property> properties, PropertySpecParams specParams)
        //{
        //    //var filtered = properties.Where(  x=> (!specParams.NumOfBeds.HasValue || x.bed_count == specParams.NumOfBeds) &&
        //    //     (!specParams.NumOfBedrooms.HasValue || x.bedroom_count == specParams.NumOfBedrooms) &&
        //    //    (!specParams.StateId.HasValue || x.state_id == specParams.StateId) &&
        //    //     (!specParams.NumOfBedrooms.HasValue || x.bedroom_count == specParams.NumOfBedrooms) &&
        //    //    (!specParams.Price.HasValue || x.price <= specParams.Price) &&

        //    //     (specParams.Amenities == null ||  x.property_amenities.Select(s => s.amenity).Select(s => s.name).ToList().All(specParams.Amenities.Contains) &&  x.property_amenities.Select(s => s.amenity).Select(s => s.name).ToList().Count == specParams.Amenities.Count) &&
        //    //     (string.IsNullOrEmpty(specParams.PropertyType) || x.property_tybe.name == specParams.PropertyType)).ToList();
        //    var filtered = properties.Where(x =>
        //      (!specParams.StateId.HasValue || x.state_id == specParams.StateId) &&
        //      (!specParams.Price.HasValue || x.price <= specParams.Price) &&
        //      (string.IsNullOrEmpty(specParams.PropertyType) || x.property_tybe.name == specParams.PropertyType))
        //        .ToList();

        //    return filtered;
        //}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PropertyDetailsDto>> GetProperty(int id)
        {
            var property = context.Properties.Include(x=>x.City).Include(x=>x.state
            ).Include(x=>x.country).Include(x => x.property_reviews).Include(x => x.property_images).Include(x=>x.User)
            .Include(x => x.property_amenities).FirstOrDefault(x => x.id == id);
            var cityname = context.Cities.Find(property.city_id).name;
            var countryname = context.Countries.Find(property.country_id).name;
            var statename = context.States.Find(property.state_id).name;
            var proptyreviews = context.Property_Reviews.Include(x => x.User)
                .Where(x => x.property.id == id).ToList();
            var propertyimages = property.property_images.ToList();
            var propertyreviewsmapped = _mapper.Map<List<property_reviews>, List<PropertyReviewsDto>>(proptyreviews);

            
            var propertyAmenit = property.property_amenities.ToList().Select(x => x.amenity).ToList();
            if (property == null) return NotFound(new ApiErrorResponse(404));
            var propertymapped = _mapper.Map<property, PropertyDTo>(property);

            propertymapped.CityName = cityname;
            propertymapped.countryName = countryname;
            propertymapped.stateName = statename;

            var propertyimagesmapped = _mapper.Map<List<property_images>, List<PropertyImagesDto>>(propertyimages);
            var AmenitesMap = _mapper.Map<List<amenity>, List<AmenityDto>>(propertyAmenit);
            var propdetails = new PropertyDetailsDto
            {
                propertyDTo = propertymapped,
                propertyReviewsDtos = propertyreviewsmapped,
                propertyImagesDtos = propertyimagesmapped,
                AmenitiesDtos = AmenitesMap,

            };
            return Ok(propdetails);
        }


        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(ApiErrorResponse),StatusCodes.Status404NotFound)]

        //public async Task<ActionResult<PropertyDTo>> GetProperty(int id)
        //{
        //    // var spec = new PropertySpecwithFiltersAndIncludes(id);
        //    // var property = await _genericRepo.GetBySpec(spec);
        //        var property = context.Properties.Find(id);
        //    if(property==null) return NotFound(new ApiErrorResponse(404));
        //    var data = _mapper.Map<property, PropertyDTo>(property);
        //    return Ok(data);
        //}
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PropertyDTo>> PostProperty(PropertyDToPosting prop){

           
            var property = _mapper.Map<PropertyDTo, property>(prop.Propertydto);
            foreach (var item in prop.PropertyImages)
            {
                var image = _mapper.Map<PropertyImagesDto, property_images>(item);
                property.property_images.Add(image);
            }
            foreach (var item in prop.Amenities)
            {
                var amenity = _mapper.Map<AmenityDto, amenity>(item);
                var propamenity = new property_amenities
                {
                    amenity_id = amenity.Id,

                };
                property.property_amenities.Add(propamenity);
            }
            var country = context.Countries.Where(x => x.name == prop.state.countryName).FirstOrDefault();
            if (country == null)
            {
                context.Countries.Add(new country { name=prop.state.countryName,code =prop.state.countryName});
                context.SaveChanges();
                country = context.Countries.Where(x => x.name == prop.state.countryName).FirstOrDefault();
                property.country = country;
            }
            else
            {
                property.country = country;
            }
            var state = context.States.Where(x => x.name == prop.state.name).FirstOrDefault();
            if (state == null)
            {
                context.States.Add(new state { country=country,name=prop.state.name});
                context.SaveChanges();
                state = context.States.Where(x => x.name == prop.state.name).FirstOrDefault();
                property.state = state;
            }
            else
            {
                property.state = state;
            }
            var statecontained = country.states
                .FirstOrDefault(x => x.name == state.name);
            if (statecontained==null)
            {
                country.states.Add(state);
                context.SaveChanges();
            }

            property.User = await userManager.FindByEmailFromClaimsPrinciples(HttpContext.User) ?? null;

            var obj = await _genericRepo.AddAsync(property);

            return Ok(_mapper.Map<property, PropertyDTo>(obj));



        }
        [HttpGet("Random")]
        public async Task <ActionResult<List<PropertyWithImageDto>>>GetRandomPropety()
        {
            var properties = await context.Properties.Include(x=>x.property_images).OrderBy(x => Guid.NewGuid()).Take(4).ToListAsync();
            var PropertMap = _mapper.Map<List<property>, List<PropertyDTo>>(properties);
            List<PropertyWithImageDto> propertyWithImageDtos = new List<PropertyWithImageDto>();
            foreach(var prop in properties) {
                var propimages = prop.property_images.ToList();
                var propdto = _mapper.Map<property, PropertyDTo>(prop);
                var imgaesdto = _mapper.Map<List<property_images>, List<PropertyImagesDto>>(propimages);
                propertyWithImageDtos.Add(new PropertyWithImageDto {PropertyDTo= propdto, propertiesimages= imgaesdto });
           }
            return Ok(propertyWithImageDtos);           
        }



        [HttpPost("review")]
        [Authorize]
        public async Task<ActionResult<PropertyReviewsDto>> PostPropertyreview(PropertyReviewPostingDto propertyReviewPostingDto)
        {
            var reviewUser = await userManager.FindByEmailFromClaimsPrinciples(HttpContext.User);
            var booking = context.Bookings.Include(x => x.property).Include(x => x.User).Where(x => x.properity_id == propertyReviewPostingDto.PropertyId && x.User == reviewUser && x.check_out_date > DateTime.Now).ToList();
            if (booking != null)
            {
                var propertyrevirewmapped = _mapper.Map<PropertyReviewsDto, property_reviews>(propertyReviewPostingDto.PropertyReviewsDto);
                propertyrevirewmapped.property = context.Properties.Find(propertyReviewPostingDto.PropertyId);
                propertyrevirewmapped.User = reviewUser;
                await context.Property_Reviews.AddAsync(propertyrevirewmapped);
                await context.SaveChangesAsync();
                return Ok(propertyReviewPostingDto.PropertyReviewsDto);
            }

            return BadRequest(new ApiErrorResponse(400, "You must book the property and finsh the duration before leaving review "));
        }















        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var Prop = await _genericRepo.GetByIdAsync(id);
            if (Prop == null)
            {
                return NotFound();
            }

          await  _genericRepo.DeleteAsync(id);
            await context.SaveChangesAsync();

            return NoContent();
        }


    }
}
