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
    [Route("api/pessoa_email")]
    [ApiController]
    public class PessoaEmailController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public PessoaEmailController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/PessoaEmail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaEmail>>> GetPessoaEmail()
        {
          if (_context.PessoaEmail == null)
          {
              return NotFound();
          }
            return await _context.PessoaEmail.ToListAsync();
        }

        // GET: api/PessoaEmail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaEmail>> GetPessoaEmail(long id)
        {
          if (_context.PessoaEmail == null)
          {
              return NotFound();
          }
            var pessoaEmail = await _context.PessoaEmail.FindAsync(id);

            if (pessoaEmail == null)
            {
                return NotFound();
            }

            return pessoaEmail;
        }

        // PUT: api/PessoaEmail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoaEmail(long id, PessoaEmail pessoaEmail)
        {
            if (id != pessoaEmail.Id)
            {
                return BadRequest();
            }

            _context.Entry(pessoaEmail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaEmailExists(id))
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

        // POST: api/PessoaEmail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PessoaEmail>> PostPessoaEmail(PessoaEmail pessoaEmail)
        {
          if (_context.PessoaEmail == null)
          {
              return Problem("Entity set 'ArgysApiContext.PessoaEmail'  is null.");
          }
            _context.PessoaEmail.Add(pessoaEmail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoaEmail", new { id = pessoaEmail.Id }, pessoaEmail);
        }

        // DELETE: api/PessoaEmail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoaEmail(long id)
        {
            if (_context.PessoaEmail == null)
            {
                return NotFound();
            }
            var pessoaEmail = await _context.PessoaEmail.FindAsync(id);
            if (pessoaEmail == null)
            {
                return NotFound();
            }

            _context.PessoaEmail.Remove(pessoaEmail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaEmailExists(long id)
        {
            return (_context.PessoaEmail?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
