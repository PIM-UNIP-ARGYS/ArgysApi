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
    [Route("api/vinculo_plan_saude")]
    [ApiController]
    public class VinculoPlanoSaudeController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public VinculoPlanoSaudeController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/VinculoPlanoSaude
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VinculoPlanoSaude>>> GetVinculoPlanoSaude()
        {
          if (_context.VinculoPlanoSaude == null)
          {
              return NotFound();
          }
            return await _context.VinculoPlanoSaude.ToListAsync();
        }

        // GET: api/VinculoPlanoSaude/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VinculoPlanoSaude>> GetVinculoPlanoSaude(long id)
        {
          if (_context.VinculoPlanoSaude == null)
          {
              return NotFound();
          }
            var vinculoPlanoSaude = await _context.VinculoPlanoSaude.FindAsync(id);

            if (vinculoPlanoSaude == null)
            {
                return NotFound();
            }

            return vinculoPlanoSaude;
        }

        // PUT: api/VinculoPlanoSaude/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVinculoPlanoSaude(long id, VinculoPlanoSaude vinculoPlanoSaude)
        {
            if (id != vinculoPlanoSaude.Id)
            {
                return BadRequest();
            }

            _context.Entry(vinculoPlanoSaude).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VinculoPlanoSaudeExists(id))
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

        // POST: api/VinculoPlanoSaude
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VinculoPlanoSaude>> PostVinculoPlanoSaude(VinculoPlanoSaude vinculoPlanoSaude)
        {
          if (_context.VinculoPlanoSaude == null)
          {
              return Problem("Entity set 'ArgysApiContext.VinculoPlanoSaude'  is null.");
          }
            _context.VinculoPlanoSaude.Add(vinculoPlanoSaude);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVinculoPlanoSaude", new { id = vinculoPlanoSaude.Id }, vinculoPlanoSaude);
        }

        // DELETE: api/VinculoPlanoSaude/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVinculoPlanoSaude(long id)
        {
            if (_context.VinculoPlanoSaude == null)
            {
                return NotFound();
            }
            var vinculoPlanoSaude = await _context.VinculoPlanoSaude.FindAsync(id);
            if (vinculoPlanoSaude == null)
            {
                return NotFound();
            }

            _context.VinculoPlanoSaude.Remove(vinculoPlanoSaude);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VinculoPlanoSaudeExists(long id)
        {
            return (_context.VinculoPlanoSaude?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
