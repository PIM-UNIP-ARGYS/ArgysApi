using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Data;
using ArgysApi.Models.Pessoas;

namespace ArgysApi.Controllers.Pessoas
{
    [Route("api/pessoa_telefone")]
    [ApiController]
    public class PessoaTelefoneController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public PessoaTelefoneController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/PessoaTelefone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaTelefone>>> GetPessoaTelefone()
        {
          if (_context.PessoaTelefone == null)
          {
              return NotFound();
          }
            return await _context.PessoaTelefone.ToListAsync();
        }

        // GET: api/PessoaTelefone/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaTelefone>> GetPessoaTelefone(long id)
        {
          if (_context.PessoaTelefone == null)
          {
              return NotFound();
          }
            var pessoaTelefone = await _context.PessoaTelefone.FindAsync(id);

            if (pessoaTelefone == null)
            {
                return NotFound();
            }

            return pessoaTelefone;
        }

        // PUT: api/PessoaTelefone/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoaTelefone(long id, PessoaTelefone pessoaTelefone)
        {
            if (id != pessoaTelefone.Id)
            {
                return BadRequest();
            }

            _context.Entry(pessoaTelefone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaTelefoneExists(id))
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

        // POST: api/PessoaTelefone
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PessoaTelefone>> PostPessoaTelefone(PessoaTelefone pessoaTelefone)
        {
          if (_context.PessoaTelefone == null)
          {
              return Problem("Entity set 'ArgysApiContext.PessoaTelefone'  is null.");
          }
            _context.PessoaTelefone.Add(pessoaTelefone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoaTelefone", new { id = pessoaTelefone.Id }, pessoaTelefone);
        }

        // DELETE: api/PessoaTelefone/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoaTelefone(long id)
        {
            if (_context.PessoaTelefone == null)
            {
                return NotFound();
            }
            var pessoaTelefone = await _context.PessoaTelefone.FindAsync(id);
            if (pessoaTelefone == null)
            {
                return NotFound();
            }

            _context.PessoaTelefone.Remove(pessoaTelefone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaTelefoneExists(long id)
        {
            return (_context.PessoaTelefone?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
