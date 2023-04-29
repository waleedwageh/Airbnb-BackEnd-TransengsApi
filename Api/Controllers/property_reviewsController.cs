using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class property_reviewsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public property_reviewsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/property_reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<property_reviews>>> GetProperty_Reviews()
        {
            return await _context.Property_Reviews.ToListAsync();
        }

        // GET: api/property_reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<property_reviews>> Getproperty_reviews(int id)
        {
            var property_reviews = await _context.Property_Reviews.FindAsync(id);

            if (property_reviews == null)
            {
                return NotFound();
            }

            return property_reviews;
        }

        // PUT: api/property_reviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproperty_reviews(int id, property_reviews property_reviews)
        {
            if (id != property_reviews.id)
            {
                return BadRequest();
            }

            _context.Entry(property_reviews).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!property_reviewsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/property_reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<property_reviews>> Postproperty_reviews(property_reviews property_reviews)
        {
            _context.Property_Reviews.Add(property_reviews);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproperty_reviews", new { id = property_reviews.id }, property_reviews);
        }

        // DELETE: api/property_reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproperty_reviews(int id)
        {
            var property_reviews = await _context.Property_Reviews.FindAsync(id);
            if (property_reviews == null)
            {
                return NotFound();
            }

            _context.Property_Reviews.Remove(property_reviews);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool property_reviewsExists(int id)
        {
            return _context.Property_Reviews.Any(e => e.id == id);
        }
    }
}
