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
    [Route("api/vinculo")]
    [ApiController]
    public class VinculoController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public VinculoController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/Vinculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vinculo>>> GetVinculo()
        {
          if (_context.Vinculo == null)
          {
              return NotFound();
          }
            return await _context.Vinculo.ToListAsync();
        }

        // GET: api/Vinculo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vinculo>> GetVinculo(long id)
        {
          if (_context.Vinculo == null)
          {
              return NotFound();
          }
            var vinculo = await _context.Vinculo.FindAsync(id);

            if (vinculo == null)
            {
                return NotFound();
            }

            return vinculo;
        }

        // PUT: api/Vinculo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVinculo(long id, Vinculo vinculo)
        {
            if (id != vinculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(vinculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VinculoExists(id))
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

        // POST: api/Vinculo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vinculo>> PostVinculo(Vinculo vinculo)
        {
          if (_context.Vinculo == null)
          {
              return Problem("Entity set 'ArgysApiContext.Vinculo'  is null.");
          }
            _context.Vinculo.Add(vinculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVinculo", new { id = vinculo.Id }, vinculo);
        }

        // DELETE: api/Vinculo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVinculo(long id)
        {
            if (_context.Vinculo == null)
            {
                return NotFound();
            }
            var vinculo = await _context.Vinculo.FindAsync(id);
            if (vinculo == null)
            {
                return NotFound();
            }

            _context.Vinculo.Remove(vinculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VinculoExists(long id)
        {
            return (_context.Vinculo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
