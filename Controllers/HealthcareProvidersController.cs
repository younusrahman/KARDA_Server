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
    public class HealthcareProvidersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public HealthcareProvidersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/HealthcareProviders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthcareProvider>>> GetHealthcareProviders()
        {
            return await _context.HealthcareProviders.ToListAsync();
        }

        // GET: api/HealthcareProviders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HealthcareProvider>> GetHealthcareProvider(string id)
        {
            var healthcareProvider = await _context.HealthcareProviders.FindAsync(id);

            if (healthcareProvider == null)
            {
                return NotFound();
            }

            return healthcareProvider;
        }

        // PUT: api/HealthcareProviders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHealthcareProvider(string id, HealthcareProvider healthcareProvider)
        {
            if (id != healthcareProvider.Id)
            {
                return BadRequest();
            }

            _context.Entry(healthcareProvider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthcareProviderExists(id))
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

        // POST: api/HealthcareProviders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HealthcareProvider>> PostHealthcareProvider(HealthcareProvider healthcareProvider)
        {
            _context.HealthcareProviders.Add(healthcareProvider);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HealthcareProviderExists(healthcareProvider.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHealthcareProvider", new { id = healthcareProvider.Id }, healthcareProvider);
        }

        // DELETE: api/HealthcareProviders/
        [HttpDelete]
        public async Task<IActionResult> DeleteHealthcareProvider(string[] ids)
        {

            foreach (var id in ids)
            {
                var healthcareProvider = await _context.HealthcareProviders.FindAsync(id);
                if (healthcareProvider == null)
                {
                    return NotFound();
                }

                _context.HealthcareProviders.Remove(healthcareProvider);

            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HealthcareProviderExists(string id)
        {
            return _context.HealthcareProviders.Any(e => e.Id == id);
        }
    }
}
