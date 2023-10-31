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
    [Route("api/plano_saude")]
    [ApiController]
    public class PlanoSaudeController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public PlanoSaudeController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/PlanoSaude
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanoSaude>>> GetPlanoSaude()
        {
          if (_context.PlanoSaude == null)
          {
              return NotFound();
          }
            return await _context.PlanoSaude.ToListAsync();
        }

        // GET: api/PlanoSaude/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanoSaude>> GetPlanoSaude(long id)
        {
          if (_context.PlanoSaude == null)
          {
              return NotFound();
          }
            var planoSaude = await _context.PlanoSaude.FindAsync(id);

            if (planoSaude == null)
            {
                return NotFound();
            }

            return planoSaude;
        }

        // PUT: api/PlanoSaude/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanoSaude(long id, PlanoSaude planoSaude)
        {
            if (id != planoSaude.Id)
            {
                return BadRequest();
            }

            _context.Entry(planoSaude).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanoSaudeExists(id))
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

        // POST: api/PlanoSaude
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlanoSaude>> PostPlanoSaude(PlanoSaude planoSaude)
        {
          if (_context.PlanoSaude == null)
          {
              return Problem("Entity set 'ArgysApiContext.PlanoSaude'  is null.");
          }
            _context.PlanoSaude.Add(planoSaude);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanoSaude", new { id = planoSaude.Id }, planoSaude);
        }

        // DELETE: api/PlanoSaude/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanoSaude(long id)
        {
            if (_context.PlanoSaude == null)
            {
                return NotFound();
            }
            var planoSaude = await _context.PlanoSaude.FindAsync(id);
            if (planoSaude == null)
            {
                return NotFound();
            }

            _context.PlanoSaude.Remove(planoSaude);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanoSaudeExists(long id)
        {
            return (_context.PlanoSaude?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
