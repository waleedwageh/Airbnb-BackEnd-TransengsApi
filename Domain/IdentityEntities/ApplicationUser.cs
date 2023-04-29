

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;

namespace Domain.IdentityEntities
{

    public class ApplicationUser : IdentityUser
    {


        public string firstName { get; set; }
        public string lastName { get; set; }
        public Nullable<byte> user_type { get; set; }

        public Address Address { get; set; }

        public Nullable<System.DateTime> date_of_birth { get; set; }
        public Nullable<byte> login_with { get; set; }

        public string about { get; set; }
        public string DisplayName { get; set; }
        public Nullable<byte> recive_coupon { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public Nullable<System.DateTime> moidfied { get; set; }
        public Nullable<byte> status { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<property> properties { get; set; }
        public virtual ICollection<property_images> property_images { get; set; }
        public virtual ICollection<property_reviews> property_reviews { get; set; }
        public virtual ICollection<transaction> transactions { get; set; }
    }
}
