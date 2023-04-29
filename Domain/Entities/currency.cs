
    using System;
    using System.Collections.Generic;

namespace Domain.Entities
{
    
    public  class currency : BaseEntity
    {
    public int Id { get; set; }
       
    
        public string name { get; set; }
        public string icon_image { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public Nullable<byte> status { get; set; }
    
        public virtual ICollection<property> properties { get; set; }
        public virtual ICollection<transaction> transactions { get; set; }
    }
}
