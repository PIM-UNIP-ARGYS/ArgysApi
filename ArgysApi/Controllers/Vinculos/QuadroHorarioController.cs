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
    [Route("api/quadro_horario")]
    [ApiController]
    public class QuadroHorarioController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public QuadroHorarioController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/QuadroHorario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuadroHorario>>> GetQuadroHorario()
        {
          if (_context.QuadroHorario == null)
          {
              return NotFound();
          }
            return await _context.QuadroHorario.ToListAsync();
        }

        // GET: api/QuadroHorario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuadroHorario>> GetQuadroHorario(long id)
        {
          if (_context.QuadroHorario == null)
          {
              return NotFound();
          }
            var quadroHorario = await _context.QuadroHorario.FindAsync(id);

            if (quadroHorario == null)
            {
                return NotFound();
            }

            return quadroHorario;
        }

        // PUT: api/QuadroHorario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuadroHorario(long id, QuadroHorario quadroHorario)
        {
            if (id != quadroHorario.Id)
            {
                return BadRequest();
            }

            _context.Entry(quadroHorario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuadroHorarioExists(id))
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

        // POST: api/QuadroHorario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuadroHorario>> PostQuadroHorario(QuadroHorario quadroHorario)
        {
          if (_context.QuadroHorario == null)
          {
              return Problem("Entity set 'ArgysApiContext.QuadroHorario'  is null.");
          }
            _context.QuadroHorario.Add(quadroHorario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuadroHorario", new { id = quadroHorario.Id }, quadroHorario);
        }

        // DELETE: api/QuadroHorario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuadroHorario(long id)
        {
            if (_context.QuadroHorario == null)
            {
                return NotFound();
            }
            var quadroHorario = await _context.QuadroHorario.FindAsync(id);
            if (quadroHorario == null)
            {
                return NotFound();
            }

            _context.QuadroHorario.Remove(quadroHorario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuadroHorarioExists(long id)
        {
            return (_context.QuadroHorario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
