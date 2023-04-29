
    using System;
    using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    
    public  class state : BaseEntity
    {
        public state()
        {
            properties = new HashSet<property>();
            country = new country();
            Cities = new HashSet<City>();
        }

        public int id { get; set; }
        [ForeignKey("country")]
        public Nullable<int> country_id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public Nullable<byte> status { get; set; }
    
        public string PictureUrl { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual country country { get; set; }
        public virtual ICollection<property> properties { get; set; }
    }
}
