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
    [Route("api/agencia")]
    [ApiController]
    public class AgenciaController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public AgenciaController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/Agencia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agencia>>> GetAgencia()
        {
          if (_context.Agencia == null)
          {
              return NotFound();
          }
            return await _context.Agencia.ToListAsync();
        }

        // GET: api/Agencia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agencia>> GetAgencia(long id)
        {
          if (_context.Agencia == null)
          {
              return NotFound();
          }
            var agencia = await _context.Agencia.FindAsync(id);

            if (agencia == null)
            {
                return NotFound();
            }

            return agencia;
        }

        // PUT: api/Agencia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgencia(long id, Agencia agencia)
        {
            if (id != agencia.Id)
            {
                return BadRequest();
            }

            _context.Entry(agencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenciaExists(id))
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

        // POST: api/Agencia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agencia>> PostAgencia(Agencia agencia)
        {
          if (_context.Agencia == null)
          {
              return Problem("Entity set 'ArgysApiContext.Agencia'  is null.");
          }
            _context.Agencia.Add(agencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgencia", new { id = agencia.Id }, agencia);
        }

        // DELETE: api/Agencia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgencia(long id)
        {
            if (_context.Agencia == null)
            {
                return NotFound();
            }
            var agencia = await _context.Agencia.FindAsync(id);
            if (agencia == null)
            {
                return NotFound();
            }

            _context.Agencia.Remove(agencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgenciaExists(long id)
        {
            return (_context.Agencia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
