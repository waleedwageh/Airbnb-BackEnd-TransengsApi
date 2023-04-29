using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOS
{
    public class PropertyReviewPostingDto
    {
        
            public int PropertyId { get; set; }
            public PropertyReviewsDto PropertyReviewsDto { get; set; }

        
    }
}
