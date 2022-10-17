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
    public class OrderingsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OrderingsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Orderings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordering>>> GetOrderings()
        {
            return await _context.Orderings.ToListAsync();
        }

        // GET: api/Orderings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordering>> GetOrdering(string id)
        {
            var ordering = await _context.Orderings.FindAsync(id);

            if (ordering == null)
            {
                return NotFound();
            }

            return ordering;
        }

        // PUT: api/Orderings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdering(string id, Ordering ordering)
        {
            if (id != ordering.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordering).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderingExists(id))
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

        // POST: api/Orderings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ordering>> PostOrdering(Ordering ordering)
        {
            _context.Orderings.Add(ordering);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderingExists(ordering.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrdering", new { id = ordering.Id }, ordering);
        }

        // DELETE: api/Orderings
        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(string[] ids)
        {
            foreach (string id in ids)
            {
                var ordering = await _context.Orderings.FindAsync(id);
                if (ordering == null)
                {
                    return NotFound();
                }

                _context.Orderings.Remove(ordering);
            }


            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderingExists(string id)
        {
            return _context.Orderings.Any(e => e.Id == id);
        }
    }
}
