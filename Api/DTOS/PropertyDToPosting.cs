using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOS
{
    public class PropertyDToPosting
    {
        public PropertyDTo Propertydto { get; set; }
        public List<PropertyImagesDto> PropertyImages { get; set; }
        public List<AmenityDto> Amenities { get; set; }
        public UserDto User { get; set; }
        public StateDTO state { get; set; }
        

    }
}
