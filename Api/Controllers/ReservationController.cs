using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.ApplictionExtentions;
using Api.DTOS;
using Api.Helpers;
using AutoMapper;
using Domain.Entities;

using Domain.IdentityEntities;

using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    public class ReservationController : ApiBaseController
    {
        private readonly ApplicationContext context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public ReservationController(
       ApplicationContext context,
       IMapper mapper,
       UserManager<ApplicationUser> userManager
       )
        {
            this.context = context;
            _mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BookingDTO>> Reserve(ResevationDto resevationDto)
        {
            var result = await new MakePayment().PayAsync(resevationDto.paymentDto);
            if (result == "success")
            {
                var prop = await context.Properties.Include(x => x.User).FirstOrDefaultAsync(x => x.id == resevationDto.propertyId);
                var mappedBooking =
                _mapper.Map<BookingDTO, Booking>(resevationDto.bookingDTO);
                var mappedtransaction =
                _mapper.Map<TransactionDto, transaction>(resevationDto.transactionDto);
                mappedBooking.property = prop;
                
                mappedBooking.transaction = mappedtransaction;
                mappedtransaction.payee = prop.User;
                mappedtransaction.Recevier = await userManager.FindByEmailFromClaimsPrinciples(HttpContext.User);
                prop.Bookings.Add(mappedBooking);
                prop.transactions.Add(mappedtransaction);
                await context.SaveChangesAsync();

                return Ok(resevationDto.bookingDTO);

            }
            return BadRequest("Your Card information is not correct");
        }

        [HttpGet("bookings/{propertyid}")]
        public async Task<ActionResult<List<BookingDTO>>> GetBookings(int propertyid)
        {

            var bookings = await context.Bookings.Where(x => x.properity_id == propertyid).ToListAsync();
            var mapped =
            _mapper.Map<IReadOnlyList<Booking>, List<BookingDTO>>(bookings);
            return Ok(mapped);
        }

        [HttpGet("transaction/{propertyid}")]
        public async Task<ActionResult<List<TransactionDto>>>
       Gettransactions(int propertyid)
        {
            var transactions = await context.Transactions.Where(x => x.property.id == propertyid).ToListAsync();
            var mapped =
            _mapper
            .Map
            <IReadOnlyList<transaction>, List<TransactionDto>
            >(transactions);
            return Ok(mapped);
        }

    }
}