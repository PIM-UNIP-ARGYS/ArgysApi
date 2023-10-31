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
    [Route("api/vinculo_cargo")]
    [ApiController]
    public class VinculoCargoController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public VinculoCargoController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/VinculoCargo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VinculoCargo>>> GetVinculoCargo()
        {
          if (_context.VinculoCargo == null)
          {
              return NotFound();
          }
            return await _context.VinculoCargo.ToListAsync();
        }

        // GET: api/VinculoCargo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VinculoCargo>> GetVinculoCargo(long id)
        {
          if (_context.VinculoCargo == null)
          {
              return NotFound();
          }
            var vinculoCargo = await _context.VinculoCargo.FindAsync(id);

            if (vinculoCargo == null)
            {
                return NotFound();
            }

            return vinculoCargo;
        }

        // PUT: api/VinculoCargo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVinculoCargo(long id, VinculoCargo vinculoCargo)
        {
            if (id != vinculoCargo.Id)
            {
                return BadRequest();
            }

            _context.Entry(vinculoCargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VinculoCargoExists(id))
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

        // POST: api/VinculoCargo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VinculoCargo>> PostVinculoCargo(VinculoCargo vinculoCargo)
        {
          if (_context.VinculoCargo == null)
          {
              return Problem("Entity set 'ArgysApiContext.VinculoCargo'  is null.");
          }
            _context.VinculoCargo.Add(vinculoCargo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVinculoCargo", new { id = vinculoCargo.Id }, vinculoCargo);
        }

        // DELETE: api/VinculoCargo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVinculoCargo(long id)
        {
            if (_context.VinculoCargo == null)
            {
                return NotFound();
            }
            var vinculoCargo = await _context.VinculoCargo.FindAsync(id);
            if (vinculoCargo == null)
            {
                return NotFound();
            }

            _context.VinculoCargo.Remove(vinculoCargo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VinculoCargoExists(long id)
        {
            return (_context.VinculoCargo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
