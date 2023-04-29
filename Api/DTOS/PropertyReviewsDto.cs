using System;

namespace Api.DTOS
{
    public class PropertyReviewsDto
    {
         public int id { get; set; }
        public string comment { get; set; }
        public int rating { get; set; }
        public string image { get; set; }
        public string UserName { get; set; }
       public string DateTime { get; set; }
        public Nullable<DateTime> created { get; set; }
    }
}