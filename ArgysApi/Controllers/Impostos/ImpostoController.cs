using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Data;
using ArgysApi.Models.Impostos;

namespace ArgysApi.Controllers.Impostos
{
    [Route("api/impostos")]
    [ApiController]
    public class ImpostoController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public ImpostoController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/Imposto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imposto>>> GetImposto()
        {
          if (_context.Imposto == null)
          {
              return NotFound();
          }
            return await _context.Imposto.ToListAsync();
        }

        // GET: api/Imposto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Imposto>> GetImposto(long id)
        {
          if (_context.Imposto == null)
          {
              return NotFound();
          }
            var imposto = await _context.Imposto.FindAsync(id);

            if (imposto == null)
            {
                return NotFound();
            }

            return imposto;
        }

        // PUT: api/Imposto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImposto(long id, Imposto imposto)
        {
            if (id != imposto.Id)
            {
                return BadRequest();
            }

            _context.Entry(imposto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImpostoExists(id))
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

        // POST: api/Imposto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Imposto>> PostImposto(Imposto imposto)
        {
          if (_context.Imposto == null)
          {
              return Problem("Entity set 'ArgysApiContext.Imposto'  is null.");
          }
            _context.Imposto.Add(imposto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImposto", new { id = imposto.Id }, imposto);
        }

        // DELETE: api/Imposto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImposto(long id)
        {
            if (_context.Imposto == null)
            {
                return NotFound();
            }
            var imposto = await _context.Imposto.FindAsync(id);
            if (imposto == null)
            {
                return NotFound();
            }

            _context.Imposto.Remove(imposto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImpostoExists(long id)
        {
            return (_context.Imposto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
