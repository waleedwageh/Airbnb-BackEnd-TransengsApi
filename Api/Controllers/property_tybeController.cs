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
    public class property_tybeController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public property_tybeController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/property_tybe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<property_tybe>>> GetProperty_Tybes()
        {
            return await _context.Property_Tybes.Take(3).ToListAsync();
        }

        // GET: api/property_tybe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<property_tybe>> Getproperty_tybe(int id)
        {
            var property_tybe = await _context.Property_Tybes.FindAsync(id);

            if (property_tybe == null)
            {
                return NotFound();
            }

            return property_tybe;
        }

        // PUT: api/property_tybe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproperty_tybe(int id, property_tybe property_tybe)
        {
            if (id != property_tybe.id)
            {
                return BadRequest();
            }

            _context.Entry(property_tybe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!property_tybeExists(id))
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

        // POST: api/property_tybe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<property_tybe>> Postproperty_tybe(property_tybe property_tybe)
        {
            _context.Property_Tybes.Add(property_tybe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproperty_tybe", new { id = property_tybe.id }, property_tybe);
        }

        // DELETE: api/property_tybe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproperty_tybe(int id)
        {
            var property_tybe = await _context.Property_Tybes.FindAsync(id);
            if (property_tybe == null)
            {
                return NotFound();
            }

            _context.Property_Tybes.Remove(property_tybe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool property_tybeExists(int id)
        {
            return _context.Property_Tybes.Any(e => e.id == id);
        }
    }
}
