
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.IdentityEntities;


namespace Domain.Entities
{

    public class property : BaseEntity
    {
        public property()
        {
            property_images = new HashSet<property_images>();
            property_amenities = new HashSet<property_amenities>();
            property_reviews = new HashSet<property_reviews>();
            transactions = new HashSet<transaction>();
            City = new City();
            currency = new currency();
            property_tybe = new property_tybe();
            country = new country();
            state = new state();
            Bookings = new HashSet<Booking>();
            User = new ApplicationUser();


        }

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        
        [ForeignKey("property_tybe")]
        public Nullable<int> property_type_id { get; set; }
        [ForeignKey("country")]

        public Nullable<int> country_id { get; set; }
        [ForeignKey("state")]

        public Nullable<int> state_id { get; set; }
        [ForeignKey("City")]

        public Nullable<int> city_id { get; set; }
        public string address { get; set; }
        public string latitude { get; set; }
        public string logitude { get; set; }
        public int bedroom_count { get; set; }
        public int bed_count { get; set; }
        public int bathroom_count { get; set; }
        public int accomodates_count { get; set; }
        public Nullable<byte> availability_tybe { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<byte> price_tybe { get; set; }
        public Nullable<int> minimum_stay { get; set; }
        public Nullable<byte> minimum_stay_tybe { get; set; }
        public Nullable<byte> refund_tybe { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public Nullable<byte> status { get; set; }
        [ForeignKey("currency")]
        public Nullable<int> currency_id { get; set; }


        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual City City { get; set; }
        public virtual country country { get; set; }
        public virtual currency currency { get; set; }
        public virtual property_tybe property_tybe { get; set; }
        public virtual state state { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<property_amenities> property_amenities { get; set; }

        public virtual ICollection<property_images> property_images { get; set; }

        public virtual ICollection<property_reviews> property_reviews { get; set; }

        public virtual ICollection<transaction> transactions { get; set; }
    }
}
