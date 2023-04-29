using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class promo_codes : BaseEntity
    {
        public int Id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string code { get; set; }

        public Nullable<decimal> discount { get; set; }

        public Nullable<System.DateTime> created { get; set; }

        public Nullable<System.DateTime> modified { get; set; }

        public virtual ICollection<transaction> transactions { get; set; }
    }
}
