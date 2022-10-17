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
    public class InventoryBalancesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public InventoryBalancesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/InventoryBalances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryBalance>>> GetInventoryBalances()
        {
            return await _context.InventoryBalances.ToListAsync();
        }

        // GET: api/InventoryBalances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryBalance>> GetInventoryBalance(string id)
        {
            var inventoryBalance = await _context.InventoryBalances.FindAsync(id);

            if (inventoryBalance == null)
            {
                return NotFound();
            }

            return inventoryBalance;
        }

        // PUT: api/InventoryBalances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryBalance(string id, InventoryBalance inventoryBalance)
        {
            if (id != inventoryBalance.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventoryBalance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryBalanceExists(id))
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

        // POST: api/InventoryBalances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventoryBalance>> PostInventoryBalance(InventoryBalance inventoryBalance)
        {
            _context.InventoryBalances.Add(inventoryBalance);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InventoryBalanceExists(inventoryBalance.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInventoryBalance", new { id = inventoryBalance.Id }, inventoryBalance);
        }

        // DELETE: api/InventoryBalances/5
        [HttpDelete]
        public async Task<IActionResult> DeleteInventoryBalance(string[] ids)
        {
            foreach (var id in ids)
            {
                var inventoryBalance = await _context.InventoryBalances.FindAsync(id);
                            if (inventoryBalance == null)
                            {
                                return NotFound();
                            }

                            _context.InventoryBalances.Remove(inventoryBalance);
            }

            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryBalanceExists(string id)
        {
            return _context.InventoryBalances.Any(e => e.Id == id);
        }
    }
}
