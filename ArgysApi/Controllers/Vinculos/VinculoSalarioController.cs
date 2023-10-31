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
    [Route("api/vinculo_salario")]
    [ApiController]
    public class VinculoSalarioController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public VinculoSalarioController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/VinculoSalario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VinculoSalario>>> GetVinculoSalario()
        {
          if (_context.VinculoSalario == null)
          {
              return NotFound();
          }
            return await _context.VinculoSalario.ToListAsync();
        }

        // GET: api/VinculoSalario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VinculoSalario>> GetVinculoSalario(long id)
        {
          if (_context.VinculoSalario == null)
          {
              return NotFound();
          }
            var vinculoSalario = await _context.VinculoSalario.FindAsync(id);

            if (vinculoSalario == null)
            {
                return NotFound();
            }

            return vinculoSalario;
        }

        // PUT: api/VinculoSalario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVinculoSalario(long id, VinculoSalario vinculoSalario)
        {
            if (id != vinculoSalario.Id)
            {
                return BadRequest();
            }

            _context.Entry(vinculoSalario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VinculoSalarioExists(id))
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

        // POST: api/VinculoSalario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VinculoSalario>> PostVinculoSalario(VinculoSalario vinculoSalario)
        {
          if (_context.VinculoSalario == null)
          {
              return Problem("Entity set 'ArgysApiContext.VinculoSalario'  is null.");
          }
            _context.VinculoSalario.Add(vinculoSalario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVinculoSalario", new { id = vinculoSalario.Id }, vinculoSalario);
        }

        // DELETE: api/VinculoSalario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVinculoSalario(long id)
        {
            if (_context.VinculoSalario == null)
            {
                return NotFound();
            }
            var vinculoSalario = await _context.VinculoSalario.FindAsync(id);
            if (vinculoSalario == null)
            {
                return NotFound();
            }

            _context.VinculoSalario.Remove(vinculoSalario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VinculoSalarioExists(long id)
        {
            return (_context.VinculoSalario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
