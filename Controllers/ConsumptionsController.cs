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
    public class ConsumptionsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ConsumptionsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Consumptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consumption>>> GetConsumptions()
        {
            return await _context.Consumptions.ToListAsync();
        }

        // GET: api/Consumptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consumption>> GetConsumption(string id)
        {
            var consumption = await _context.Consumptions.FindAsync(id);

            if (consumption == null)
            {
                return NotFound();
            }

            return consumption;
        }

        // PUT: api/Consumptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumption(string id, Consumption consumption)
        {
            if (id != consumption.Id)
            {
                return BadRequest();
            }

            _context.Entry(consumption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumptionExists(id))
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

        // POST: api/Consumptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Consumption>> PostConsumption(Consumption consumption)
        {
            _context.Consumptions.Add(consumption);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConsumptionExists(consumption.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConsumption", new { id = consumption.Id }, consumption);
        }

        // DELETE: api/Consumptions
        [HttpDelete]
        public async Task<IActionResult> DeleteConsumption(string[] ids)
        {
            foreach (var id in ids)
            {
                var consumption = await _context.Consumptions.FindAsync(id);
                            if (consumption == null)
                            {
                                return NotFound();
                            }

                            _context.Consumptions.Remove(consumption);
            }
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsumptionExists(string id)
        {
            return _context.Consumptions.Any(e => e.Id == id);
        }
    }
}
