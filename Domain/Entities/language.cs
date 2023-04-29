
    using System;
    using System.Collections.Generic;

namespace Domain.Entities
{
    
    public  class language : BaseEntity
    {
    public int Id { get; set; }

        public string name { get; set; }
        public string code { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public Nullable<byte> status { get; set; }
    }
}
