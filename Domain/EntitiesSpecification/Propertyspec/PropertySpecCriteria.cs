using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.EntitiesSpecification.Propertyspec
{
    public class PropertySpecCriteria
    {
        private readonly PropertySpecParams _propertySpecParams;
        public PropertySpecCriteria(PropertySpecParams propertySpecParams)
        {
            _propertySpecParams = propertySpecParams;
        }

        public static Func<property, bool> CreateCriteria(PropertySpecParams _propertySpecParams)
        {

            Func<property, bool> criteria = (x) =>
            {
                var amenities = x.property_amenities.Select(s => s.amenity).Select(s => s.name).ToList();
                return (!_propertySpecParams.NumOfBeds.HasValue || x.bed_count == _propertySpecParams.NumOfBeds) &&
                 (!_propertySpecParams.NumOfBedrooms.HasValue || x.bedroom_count == _propertySpecParams.NumOfBedrooms) &&
                 (!_propertySpecParams.NumOfBedrooms.HasValue || x.bedroom_count == _propertySpecParams.NumOfBedrooms) &&
                 (_propertySpecParams.Amenities == null || amenities.All(_propertySpecParams.Amenities.Contains) && amenities.Count == _propertySpecParams.Amenities.Count) &&
                 (string.IsNullOrEmpty(_propertySpecParams.PropertyType) || x.property_tybe.name == _propertySpecParams.PropertyType)
                 ;

            };


            return  criteria;
        }
       
            
    }
}