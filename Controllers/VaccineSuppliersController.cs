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
    public class VaccineSuppliersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public VaccineSuppliersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/VaccineSuppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccineSupplier>>> GetVaccineSuppliers()
        {
            return await _context.VaccineSuppliers.ToListAsync();
        }

        // GET: api/VaccineSuppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VaccineSupplier>> GetVaccineSupplier(string id)
        {
            var vaccineSupplier = await _context.VaccineSuppliers.FindAsync(id);

            if (vaccineSupplier == null)
            {
                return NotFound();
            }

            return vaccineSupplier;
        }

        // PUT: api/VaccineSuppliers/5sdd
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccineSupplier(string id, VaccineSupplier vaccineSupplier)
        {
            if (id != vaccineSupplier.Id)
            {
                return BadRequest();
            }

            _context.Entry(vaccineSupplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccineSupplierExists(id))
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

        // POST: api/VaccineSuppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VaccineSupplier>> PostVaccineSupplier(VaccineSupplier vaccineSupplier)
        {
            _context.VaccineSuppliers.Add(vaccineSupplier);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VaccineSupplierExists(vaccineSupplier.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVaccineSupplier", new { id = vaccineSupplier.Id }, vaccineSupplier);
        }

        // DELETE: api/VaccineSuppliers/
        [HttpDelete]
        public async Task<IActionResult> DeleteVaccineSupplier(string[] ids)
        {
            foreach (var id in ids)
            {
                var vaccineSupplier = await _context.VaccineSuppliers.FindAsync(id);
                if (vaccineSupplier == null)
                {
                    return NotFound();
                }

                _context.VaccineSuppliers.Remove(vaccineSupplier);
            }


            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaccineSupplierExists(string id)
        {
            return _context.VaccineSuppliers.Any(e => e.Id == id);
        }
    }
}
