using System;
using System.Linq;
using Domain.Entities;
using Domain.Specfication;

namespace Domain.EntitiesSpecification.Propertyspec
{
    public class PropertySpecwithFiltersAndIncludes : Specification<property>
    {
        public PropertySpecwithFiltersAndIncludes(
            PropertySpecParams propertySpecParams
        ) :
            base(
                  x =>
                (!propertySpecParams.NumOfBeds.HasValue ||x.bed_count == propertySpecParams.NumOfBeds)&&
                 (!propertySpecParams.NumofBathrooms.HasValue || x.bathroom_count == propertySpecParams.NumofBathrooms) &&
                (!propertySpecParams.NumOfBedrooms.HasValue || x.bedroom_count == propertySpecParams.NumOfBedrooms) &&
                (!propertySpecParams.StateId.HasValue || x.state_id == propertySpecParams.StateId) &&
                  (!propertySpecParams.Price.HasValue || x.price <= propertySpecParams.Price)&&
                (propertySpecParams.Amenities == null || x.property_amenities.Select(x => x.amenity).Select(x => x.name).ToList().All(propertySpecParams.Amenities.Contains) && x.property_amenities.Select(x => x.amenity).Select(x => x.name).ToList().Count == propertySpecParams.Amenities.Count) &&
                (string.IsNullOrEmpty(propertySpecParams.CityName) || x.City.name == propertySpecParams.CityName)&&
                (string.IsNullOrEmpty(propertySpecParams.PropertyType) || x.property_tybe.name == propertySpecParams.PropertyType)

                )
        {

  



            AddInclude(x => x.Bookings);
            AddInclude(x => x.User);
            AddInclude(x => x.City);
            AddInclude(x => x.country);
            AddInclude(x => x.state);
            AddInclude(x => x.currency);
            AddInclude(x => x.property_tybe);
            AddInclude(x => x.property_reviews);
            AddInclude(x => x.property_images);

            



            AddOrderBy(x => x.name);
            ApplyPaging(propertySpecParams.PageSize *
            (propertySpecParams.PageIndex - 1),
            propertySpecParams.PageSize);
            switch (propertySpecParams.sort)
            {
                case "priceAsc":
                    AddOrderBy(x => x.price);
                    break;
                case "priceDesc":
                    AddOrderByDescinding(x => x.price);
                    break;
                case "address":
                    AddOrderBy(x => x.address);
                    break;
                default:
                    AddOrderBy(x => x.name);
                    break;
            }
        }

        public PropertySpecwithFiltersAndIncludes(int id) :
            base(x => x.id == id)
        {
            AddInclude(x => x.Bookings);
            AddInclude(x => x.User);
            AddInclude(x => x.City);
            AddInclude(x => x.country);
            AddInclude(x => x.state);
            AddInclude(x => x.currency);
        }
    }
}
