

namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public  class City : BaseEntity
    {
        
    
    public int Id { get; set; }
        
        [ForeignKey("state")]
        public Nullable<int> state_id_fk { get; set; }
        public string name { get; set; }

        public virtual country Country { get; set; }
    
        public virtual state state { get; set; }
        public virtual ICollection<property> properties { get; set; }
    }
}
