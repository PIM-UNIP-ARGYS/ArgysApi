using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Data;
using ArgysApi.Models.Vinculos;

namespace ArgysApi.Controllers.Vinculos
{
    [Route("api/vinculo_transp")]
    [ApiController]
    public class VinculoTransporteController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public VinculoTransporteController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/VinculoTransporte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VinculoTransporte>>> GetVinculoTransporte()
        {
          if (_context.VinculoTransporte == null)
          {
              return NotFound();
          }
            return await _context.VinculoTransporte.ToListAsync();
        }

        // GET: api/VinculoTransporte/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VinculoTransporte>> GetVinculoTransporte(long id)
        {
          if (_context.VinculoTransporte == null)
          {
              return NotFound();
          }
            var vinculoTransporte = await _context.VinculoTransporte.FindAsync(id);

            if (vinculoTransporte == null)
            {
                return NotFound();
            }

            return vinculoTransporte;
        }

        // PUT: api/VinculoTransporte/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVinculoTransporte(long id, VinculoTransporte vinculoTransporte)
        {
            if (id != vinculoTransporte.Id)
            {
                return BadRequest();
            }

            _context.Entry(vinculoTransporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VinculoTransporteExists(id))
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

        // POST: api/VinculoTransporte
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VinculoTransporte>> PostVinculoTransporte(VinculoTransporte vinculoTransporte)
        {
          if (_context.VinculoTransporte == null)
          {
              return Problem("Entity set 'ArgysApiContext.VinculoTransporte'  is null.");
          }
            _context.VinculoTransporte.Add(vinculoTransporte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVinculoTransporte", new { id = vinculoTransporte.Id }, vinculoTransporte);
        }

        // DELETE: api/VinculoTransporte/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVinculoTransporte(long id)
        {
            if (_context.VinculoTransporte == null)
            {
                return NotFound();
            }
            var vinculoTransporte = await _context.VinculoTransporte.FindAsync(id);
            if (vinculoTransporte == null)
            {
                return NotFound();
            }

            _context.VinculoTransporte.Remove(vinculoTransporte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VinculoTransporteExists(long id)
        {
            return (_context.VinculoTransporte?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
