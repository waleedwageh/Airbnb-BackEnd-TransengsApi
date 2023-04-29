using System;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Specfication;

namespace Domain.EntitiesSpecification.TransactionSpec
{
    public class TransactionSpecification : Specification<transaction>
    {
        public TransactionSpecification(int bookingid) : base(x=>x.booking_id==bookingid)
        {
            AddInclude(x=>x.property);
            AddInclude(x=>x.payee);
            AddInclude(x=>x.Recevier);
            AddInclude(x=>x.Booking);
            
        }
    }
}