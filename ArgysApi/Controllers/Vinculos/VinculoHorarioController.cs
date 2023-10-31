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
    [Route("api/vinculo_horario")]
    [ApiController]
    public class VinculoHorarioController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public VinculoHorarioController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/VinculoHorario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VinculoHorario>>> GetVinculoHorario()
        {
          if (_context.VinculoHorario == null)
          {
              return NotFound();
          }
            return await _context.VinculoHorario.ToListAsync();
        }

        // GET: api/VinculoHorario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VinculoHorario>> GetVinculoHorario(long id)
        {
          if (_context.VinculoHorario == null)
          {
              return NotFound();
          }
            var vinculoHorario = await _context.VinculoHorario.FindAsync(id);

            if (vinculoHorario == null)
            {
                return NotFound();
            }

            return vinculoHorario;
        }

        // PUT: api/VinculoHorario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVinculoHorario(long id, VinculoHorario vinculoHorario)
        {
            if (id != vinculoHorario.Id)
            {
                return BadRequest();
            }

            _context.Entry(vinculoHorario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VinculoHorarioExists(id))
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

        // POST: api/VinculoHorario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VinculoHorario>> PostVinculoHorario(VinculoHorario vinculoHorario)
        {
          if (_context.VinculoHorario == null)
          {
              return Problem("Entity set 'ArgysApiContext.VinculoHorario'  is null.");
          }
            _context.VinculoHorario.Add(vinculoHorario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVinculoHorario", new { id = vinculoHorario.Id }, vinculoHorario);
        }

        // DELETE: api/VinculoHorario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVinculoHorario(long id)
        {
            if (_context.VinculoHorario == null)
            {
                return NotFound();
            }
            var vinculoHorario = await _context.VinculoHorario.FindAsync(id);
            if (vinculoHorario == null)
            {
                return NotFound();
            }

            _context.VinculoHorario.Remove(vinculoHorario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VinculoHorarioExists(long id)
        {
            return (_context.VinculoHorario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
