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
    [Route("api/banco")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public BancoController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/Banco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banco>>> GetBanco()
        {
          if (_context.Banco == null)
          {
              return NotFound();
          }
            return await _context.Banco.ToListAsync();
        }

        // GET: api/Banco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banco>> GetBanco(long id)
        {
          if (_context.Banco == null)
          {
              return NotFound();
          }
            var banco = await _context.Banco.FindAsync(id);

            if (banco == null)
            {
                return NotFound();
            }

            return banco;
        }

        // PUT: api/Banco/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanco(long id, Banco banco)
        {
            if (id != banco.Id)
            {
                return BadRequest();
            }

            _context.Entry(banco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BancoExists(id))
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

        // POST: api/Banco
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Banco>> PostBanco(Banco banco)
        {
          if (_context.Banco == null)
          {
              return Problem("Entity set 'ArgysApiContext.Banco'  is null.");
          }
            _context.Banco.Add(banco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanco", new { id = banco.Id }, banco);
        }

        // DELETE: api/Banco/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanco(long id)
        {
            if (_context.Banco == null)
            {
                return NotFound();
            }
            var banco = await _context.Banco.FindAsync(id);
            if (banco == null)
            {
                return NotFound();
            }

            _context.Banco.Remove(banco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BancoExists(long id)
        {
            return (_context.Banco?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
