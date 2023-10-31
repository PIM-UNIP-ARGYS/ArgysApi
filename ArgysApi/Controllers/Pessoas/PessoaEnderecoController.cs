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
    [Route("api/pessoa_endereco")]
    [ApiController]
    public class PessoaEnderecoController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public PessoaEnderecoController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/PessoaEndereco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaEndereco>>> GetPessoaEndereco()
        {
          if (_context.PessoaEndereco == null)
          {
              return NotFound();
          }
            return await _context.PessoaEndereco.ToListAsync();
        }

        // GET: api/PessoaEndereco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaEndereco>> GetPessoaEndereco(long id)
        {
          if (_context.PessoaEndereco == null)
          {
              return NotFound();
          }
            var pessoaEndereco = await _context.PessoaEndereco.FindAsync(id);

            if (pessoaEndereco == null)
            {
                return NotFound();
            }

            return pessoaEndereco;
        }

        // PUT: api/PessoaEndereco/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoaEndereco(long id, PessoaEndereco pessoaEndereco)
        {
            if (id != pessoaEndereco.Id)
            {
                return BadRequest();
            }

            _context.Entry(pessoaEndereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaEnderecoExists(id))
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

        // POST: api/PessoaEndereco
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PessoaEndereco>> PostPessoaEndereco(PessoaEndereco pessoaEndereco)
        {
          if (_context.PessoaEndereco == null)
          {
              return Problem("Entity set 'ArgysApiContext.PessoaEndereco'  is null.");
          }
            _context.PessoaEndereco.Add(pessoaEndereco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoaEndereco", new { id = pessoaEndereco.Id }, pessoaEndereco);
        }

        // DELETE: api/PessoaEndereco/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoaEndereco(long id)
        {
            if (_context.PessoaEndereco == null)
            {
                return NotFound();
            }
            var pessoaEndereco = await _context.PessoaEndereco.FindAsync(id);
            if (pessoaEndereco == null)
            {
                return NotFound();
            }

            _context.PessoaEndereco.Remove(pessoaEndereco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaEnderecoExists(long id)
        {
            return (_context.PessoaEndereco?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
