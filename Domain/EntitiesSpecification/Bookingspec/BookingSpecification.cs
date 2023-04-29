using System;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Specfication;

namespace Domain.EntitiesSpecification.Bookingspec
{
    public class BookingSpecification : Specification<Booking>
    {
        public BookingSpecification(int propertyId) : base(x=>x.property.id==propertyId)
        {
            AddInclude(x=>x.property);
            AddInclude(x=>x.transaction);
            AddInclude(x=>x.User);
            AddOrderBy(x=>x.booking_date);
        }
    }
}