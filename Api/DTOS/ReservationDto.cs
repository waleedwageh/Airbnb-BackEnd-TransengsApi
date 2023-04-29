using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOS
{
    public class ResevationDto
    {
        public int propertyId { get; set; }
        public PaymentDto paymentDto { get; set; }
        public BookingDTO bookingDTO { get; set; }
        public TransactionDto transactionDto { get; set; }

    }
}