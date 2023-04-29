using System;

namespace Api.DTOS
{
    public class TransactionDto
    {
        public int id { get; set; }

        public Nullable<decimal> site_fees { get; set; }

        public Nullable<decimal> amount { get; set; }

        public Nullable<System.DateTime> trancfer_on { get; set; }

        public Nullable<int> currency_id { get; set; }

        public Nullable<int> promo_code_id { get; set; }

        public Nullable<decimal> discount_amt { get; set; }


        


      
    }
}
