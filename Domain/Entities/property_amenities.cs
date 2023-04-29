
    using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    
    public  class property_amenities : BaseEntity
    {
        
        [ForeignKey("amenity")]
        public Nullable<int> amenity_id { get; set; }
         
        [ForeignKey("property")]
        public Nullable<int> property_id { get; set; }
        public string icon_image { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public Nullable<byte> status { get; set; }
    
        public virtual amenity amenity { get; set; }
        public virtual property property { get; set; }
    }
}
