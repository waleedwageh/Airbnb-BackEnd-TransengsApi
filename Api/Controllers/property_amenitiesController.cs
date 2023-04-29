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
    public class property_amenitiesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public property_amenitiesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/property_amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<property_amenities>>> GetProperty_Amenities()
        {
            return await _context.Property_Amenities.ToListAsync();
        }

        // GET: api/property_amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<property_amenities>> Getproperty_amenities(int? id)
        {
            var property_amenities = await _context.Property_Amenities.FindAsync(id);

            if (property_amenities == null)
            {
                return NotFound();
            }

            return property_amenities;
        }

        // PUT: api/property_amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproperty_amenities(int? id, property_amenities property_amenities)
        {
            if (id != property_amenities.amenity_id)
            {
                return BadRequest();
            }

            _context.Entry(property_amenities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!property_amenitiesExists(id))
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

        // POST: api/property_amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<property_amenities>> Postproperty_amenities(property_amenities property_amenities)
        {
            _context.Property_Amenities.Add(property_amenities);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (property_amenitiesExists(property_amenities.amenity_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getproperty_amenities", new { id = property_amenities.amenity_id }, property_amenities);
        }

        // DELETE: api/property_amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproperty_amenities(int? id)
        {
            var property_amenities = await _context.Property_Amenities.FindAsync(id);
            if (property_amenities == null)
            {
                return NotFound();
            }

            _context.Property_Amenities.Remove(property_amenities);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool property_amenitiesExists(int? id)
        {
            return _context.Property_Amenities.Any(e => e.amenity_id == id);
        }
    }
}
