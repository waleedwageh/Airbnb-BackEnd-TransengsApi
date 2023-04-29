
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOS
    {
        public class PropertyDetailsDto
        {
            public PropertyDTo propertyDTo { get; set; }

            public List<PropertyReviewsDto> propertyReviewsDtos { get; set; }

            public List<PropertyImagesDto> propertyImagesDtos { get; set; }

            public List<AmenityDto> AmenitiesDtos { get; set; }
        }
    }
