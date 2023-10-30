using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Data;
using ArgysApi.Models.Feriados;

namespace ArgysApi.Controllers.Feriados
{
    [Route("api/feriado")]
    [ApiController]
    public class FeriadoController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public FeriadoController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/Feriado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feriado>>> GetFeriado()
        {
          if (_context.Feriado == null)
          {
              return NotFound();
          }
            return await _context.Feriado.ToListAsync();
        }

        // GET: api/Feriado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feriado>> GetFeriado(long id)
        {
          if (_context.Feriado == null)
          {
              return NotFound();
          }
            var feriado = await _context.Feriado.FindAsync(id);

            if (feriado == null)
            {
                return NotFound();
            }

            return feriado;
        }

        // PUT: api/Feriado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeriado(long id, Feriado feriado)
        {
            if (id != feriado.Id)
            {
                return BadRequest();
            }

            _context.Entry(feriado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeriadoExists(id))
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

        // POST: api/Feriado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Feriado>> PostFeriado(Feriado feriado)
        {
          if (_context.Feriado == null)
          {
              return Problem("Entity set 'ArgysApiContext.Feriado'  is null.");
          }
            _context.Feriado.Add(feriado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeriado", new { id = feriado.Id }, feriado);
        }

        // DELETE: api/Feriado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeriado(long id)
        {
            if (_context.Feriado == null)
            {
                return NotFound();
            }
            var feriado = await _context.Feriado.FindAsync(id);
            if (feriado == null)
            {
                return NotFound();
            }

            _context.Feriado.Remove(feriado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeriadoExists(long id)
        {
            return (_context.Feriado?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
