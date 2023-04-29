 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOS
{
    public class PropertyWithImageDto
    {
        public PropertyDTo PropertyDTo { get; set; }

        public List<PropertyImagesDto> propertiesimages { get; set; }
    }
}
