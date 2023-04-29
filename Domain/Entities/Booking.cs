
  using System;
  using System.Collections.Generic;
using Domain.IdentityEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
  
    
    public  class Booking : BaseEntity
    {
        public Booking()
        {
            property = new property();
            User = new ApplicationUser();
            property_reviews = new HashSet<property_reviews>();
        }

        public int Id { get; set; }

        [ForeignKey("property")]
        public int properity_id { get; set; }
      
        
        public DateTime check_in_date { get; set; }
        public DateTime check_out_date { get; set; }
        public decimal price_per_day { get; set; }
        public decimal price_per_stay { get; set; }
        
        public decimal tax_paid { get; set; }
        
        public decimal site_fees { get; set; }
        public decimal amount_paid { get; set; }
        public bool is_refund { get; set; }
        public DateTime? cancel_date { get; set; }
        public decimal refund_paid { get; set; }
        
        public decimal effective_amount { get; set; }
        public Nullable<System.DateTime> booking_date { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
    
        public  property property { get; set; }
        
        public  ApplicationUser User { get; set; }

        public  ICollection<property_reviews> property_reviews { get; set; }
        public  transaction transaction { get; set; }
    }
}
