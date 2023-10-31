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
    [Route("api/ferias")]
    [ApiController]
    public class FeriasController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public FeriasController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/Ferias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ferias>>> GetFerias()
        {
          if (_context.Ferias == null)
          {
              return NotFound();
          }
            return await _context.Ferias.ToListAsync();
        }

        // GET: api/Ferias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ferias>> GetFerias(long id)
        {
          if (_context.Ferias == null)
          {
              return NotFound();
          }
            var ferias = await _context.Ferias.FindAsync(id);

            if (ferias == null)
            {
                return NotFound();
            }

            return ferias;
        }

        // PUT: api/Ferias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFerias(long id, Ferias ferias)
        {
            if (id != ferias.Id)
            {
                return BadRequest();
            }

            _context.Entry(ferias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeriasExists(id))
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

        // POST: api/Ferias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ferias>> PostFerias(Ferias ferias)
        {
          if (_context.Ferias == null)
          {
              return Problem("Entity set 'ArgysApiContext.Ferias'  is null.");
          }
            _context.Ferias.Add(ferias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFerias", new { id = ferias.Id }, ferias);
        }

        // DELETE: api/Ferias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFerias(long id)
        {
            if (_context.Ferias == null)
            {
                return NotFound();
            }
            var ferias = await _context.Ferias.FindAsync(id);
            if (ferias == null)
            {
                return NotFound();
            }

            _context.Ferias.Remove(ferias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeriasExists(long id)
        {
            return (_context.Ferias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
