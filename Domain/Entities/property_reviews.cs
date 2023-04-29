
    using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.IdentityEntities;


namespace Domain.Entities
{
    
    public  class property_reviews : BaseEntity
    {
        public int id { get; set; }
        public string comment { get; set; }
        [Range(1,5)]
        public int? rating { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public Nullable<System.DateTime> moidfied { get; set; }
        public Nullable<byte> status { get; set; }
        
        
        [ForeignKey("Booking")]
        public int booking_id { get; set; }
        public string image { get; set; }
    
        public virtual Booking Booking { get; set; }
        public virtual property property { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
