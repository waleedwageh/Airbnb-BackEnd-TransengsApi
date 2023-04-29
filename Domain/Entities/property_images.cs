 using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.IdentityEntities;

namespace Domain.Entities
{
   
    
    public  class property_images : BaseEntity
    {
        public int id { get; set; }
        public string image { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public Nullable<byte> status { get; set; }
        [ForeignKey("property")]
        public Nullable<int> property_id { get; set; }
     
        public virtual property property { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
