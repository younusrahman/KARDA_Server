using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacitiesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CapacitiesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Capacities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Capacity>>> GetCapacitys()
        {
            return await _context.Capacitys.ToListAsync();
        }

        // GET: api/Capacities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Capacity>> GetCapacity(string id)
        {
            var capacity = await _context.Capacitys.FindAsync(id);

            if (capacity == null)
            {
                return NotFound();
            }

            return capacity;
        }

        // PUT: api/Capacities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapacity(string id, Capacity capacity)
        {
            if (id != capacity.Id)
            {
                return BadRequest();
            }

            _context.Entry(capacity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapacityExists(id))
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

        // POST: api/Capacities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Capacity>> PostCapacity(Capacity capacity)
        {
            _context.Capacitys.Add(capacity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CapacityExists(capacity.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCapacity", new { id = capacity.Id }, capacity);
        }

        // DELETE: api/Capacities
        [HttpDelete]
        public async Task<IActionResult> DeleteCapacity(string[] ids)
        {
            foreach (var id in ids)
            {
                var capacity = await _context.Capacitys.FindAsync(id);
                if (capacity == null)
                {
                    return NotFound();
                }

                _context.Capacitys.Remove(capacity);
            }
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CapacityExists(string id)
        {
            return _context.Capacitys.Any(e => e.Id == id);
        }
    }
}
