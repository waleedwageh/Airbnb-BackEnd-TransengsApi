 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.IdentityEntities;


namespace Domain.Entities
{
    
    public  class transaction : BaseEntity
    {
        public transaction()
        {
            property = new property();
            payee = new ApplicationUser();
            Recevier = new ApplicationUser();
            currency = new currency();
            promo_codes = new promo_codes();

    }
    
        public int id { get; set; }
        [ForeignKey("property")]
        public Nullable<int> property_id { get; set; }
        
       
        [ForeignKey("Booking")]
        public Nullable<int> booking_id { get; set; }
        public Nullable<decimal> site_fees { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<System.DateTime> trancfer_on { get; set; }
        [ForeignKey("currency")]
        public Nullable<int> currency_id { get; set; }
        [ForeignKey("promo_codes")]
        public Nullable<int> promo_code_id { get; set; }
        public Nullable<decimal> discount_amt { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public Nullable<byte> status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  Booking Booking { get; set; }
        public  currency currency { get; set; }
        public  promo_codes promo_codes { get; set; }
        public  property property { get; set; }
        public  ApplicationUser payee { get; set; }
        public  ApplicationUser Recevier { get; set; }
    }
}
