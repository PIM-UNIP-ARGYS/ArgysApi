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
    [Route("api/agencia_telefone")]
    [ApiController]
    public class AgenciaTelefoneController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public AgenciaTelefoneController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/AgenciaTelefone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgenciaTelefone>>> GetAgenciaTelefone()
        {
          if (_context.AgenciaTelefone == null)
          {
              return NotFound();
          }
            return await _context.AgenciaTelefone.ToListAsync();
        }

        // GET: api/AgenciaTelefone/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgenciaTelefone>> GetAgenciaTelefone(long id)
        {
          if (_context.AgenciaTelefone == null)
          {
              return NotFound();
          }
            var agenciaTelefone = await _context.AgenciaTelefone.FindAsync(id);

            if (agenciaTelefone == null)
            {
                return NotFound();
            }

            return agenciaTelefone;
        }

        // PUT: api/AgenciaTelefone/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgenciaTelefone(long id, AgenciaTelefone agenciaTelefone)
        {
            if (id != agenciaTelefone.Id)
            {
                return BadRequest();
            }

            _context.Entry(agenciaTelefone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenciaTelefoneExists(id))
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

        // POST: api/AgenciaTelefone
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AgenciaTelefone>> PostAgenciaTelefone(AgenciaTelefone agenciaTelefone)
        {
          if (_context.AgenciaTelefone == null)
          {
              return Problem("Entity set 'ArgysApiContext.AgenciaTelefone'  is null.");
          }
            _context.AgenciaTelefone.Add(agenciaTelefone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgenciaTelefone", new { id = agenciaTelefone.Id }, agenciaTelefone);
        }

        // DELETE: api/AgenciaTelefone/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgenciaTelefone(long id)
        {
            if (_context.AgenciaTelefone == null)
            {
                return NotFound();
            }
            var agenciaTelefone = await _context.AgenciaTelefone.FindAsync(id);
            if (agenciaTelefone == null)
            {
                return NotFound();
            }

            _context.AgenciaTelefone.Remove(agenciaTelefone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgenciaTelefoneExists(long id)
        {
            return (_context.AgenciaTelefone?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
