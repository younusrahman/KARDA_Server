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
    public class DeliveryStatusController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public DeliveryStatusController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryStatus>>> GetDeliveryStatuses()
        {
            return await _context.DeliveryStatuses.ToListAsync();
        }

        // GET: api/DeliveryStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryStatus>> GetDeliveryStatus(string id)
        {
            var deliveryStatus = await _context.DeliveryStatuses.FindAsync(id);

            if (deliveryStatus == null)
            {
                return NotFound();
            }

            return deliveryStatus;
        }

        // PUT: api/DeliveryStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryStatus(string id, DeliveryStatus deliveryStatus)
        {
            if (id != deliveryStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryStatusExists(id))
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

        // POST: api/DeliveryStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryStatus>> PostDeliveryStatus(DeliveryStatus deliveryStatus)
        {
            _context.DeliveryStatuses.Add(deliveryStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeliveryStatusExists(deliveryStatus.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeliveryStatus", new { id = deliveryStatus.Id }, deliveryStatus);
        }

        // DELETE: api/DeliveryStatus/5
        [HttpDelete]
        public async Task<IActionResult> DeleteDeliveryStatus(string[] ids)
        {

            foreach (var id in ids)
            {
                var deliveryStatus = await _context.DeliveryStatuses.FindAsync(id);
                if (deliveryStatus == null)
                {
                    return NotFound();
                }

                _context.DeliveryStatuses.Remove(deliveryStatus);
            }



            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryStatusExists(string id)
        {
            return _context.DeliveryStatuses.Any(e => e.Id == id);
        }
    }
}
