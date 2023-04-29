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
    public class property_imagesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public property_imagesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/property_images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<property_images>>> GetProperty_Images()
        {
            return await _context.Property_Images.ToListAsync();
        }

        // GET: api/property_images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<property_images>> Getproperty_images(int id)
        {
            var property_images = await _context.Property_Images.FindAsync(id);

            if (property_images == null)
            {
                return NotFound();
            }

            return property_images;
        }

        // PUT: api/property_images/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproperty_images(int id, property_images property_images)
        {
            if (id != property_images.id)
            {
                return BadRequest();
            }

            _context.Entry(property_images).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!property_imagesExists(id))
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

        // POST: api/property_images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<property_images>> Postproperty_images(property_images property_images)
        {
            _context.Property_Images.Add(property_images);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproperty_images", new { id = property_images.id }, property_images);
        }

        // DELETE: api/property_images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproperty_images(int id)
        {
            var property_images = await _context.Property_Images.FindAsync(id);
            if (property_images == null)
            {
                return NotFound();
            }

            _context.Property_Images.Remove(property_images);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool property_imagesExists(int id)
        {
            return _context.Property_Images.Any(e => e.id == id);
        }
    }
}
