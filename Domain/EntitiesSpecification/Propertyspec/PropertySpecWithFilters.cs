using Domain.Entities;
using Domain.Specfication;
using System.Linq;

namespace Domain.EntitiesSpecification.Propertyspec
{
    public class PropertySpecWithFilters : Specification<property>
    {
        public PropertySpecWithFilters(PropertySpecParams propertySpecParams) :
        base(x=>
                (!propertySpecParams.NumOfBeds.HasValue || x.bed_count == propertySpecParams.NumOfBeds) &&
                (!propertySpecParams.NumofBathrooms.HasValue || x.bathroom_count == propertySpecParams.NumofBathrooms) &&
                (!propertySpecParams.NumOfBedrooms.HasValue || x.bedroom_count == propertySpecParams.NumOfBedrooms) &&
                 (!propertySpecParams.Price.HasValue || x.price <= propertySpecParams.Price) &&

                (!propertySpecParams.StateId.HasValue || x.state_id == propertySpecParams.StateId) &&
                (propertySpecParams.Amenities == null || x.property_amenities.Select(x => x.amenity).Select(x => x.name).ToList().All(propertySpecParams.Amenities.Contains) && x.property_amenities.Select(x => x.amenity).Select(x => x.name).ToList().Count == propertySpecParams.Amenities.Count) &&
                (string.IsNullOrEmpty(propertySpecParams.PropertyType) || x.property_tybe.name == propertySpecParams.PropertyType)

        )
        {

            AddInclude(x => x.property_tybe);
            AddInclude(x => x.property_reviews);
            AddInclude(x => x.property_images);
        }
    }
}