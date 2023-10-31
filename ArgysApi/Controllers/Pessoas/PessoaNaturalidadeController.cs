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
    [Route("api/pessoa_naturalidade")]
    [ApiController]
    public class PessoaNaturalidadeController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public PessoaNaturalidadeController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/PessoaNaturalidade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaNaturalidade>>> GetPessoaNaturalidade()
        {
          if (_context.PessoaNaturalidade == null)
          {
              return NotFound();
          }
            return await _context.PessoaNaturalidade.ToListAsync();
        }

        // GET: api/PessoaNaturalidade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaNaturalidade>> GetPessoaNaturalidade(long id)
        {
          if (_context.PessoaNaturalidade == null)
          {
              return NotFound();
          }
            var pessoaNaturalidade = await _context.PessoaNaturalidade.FindAsync(id);

            if (pessoaNaturalidade == null)
            {
                return NotFound();
            }

            return pessoaNaturalidade;
        }

        // PUT: api/PessoaNaturalidade/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoaNaturalidade(long id, PessoaNaturalidade pessoaNaturalidade)
        {
            if (id != pessoaNaturalidade.Id)
            {
                return BadRequest();
            }

            _context.Entry(pessoaNaturalidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaNaturalidadeExists(id))
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

        // POST: api/PessoaNaturalidade
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PessoaNaturalidade>> PostPessoaNaturalidade(PessoaNaturalidade pessoaNaturalidade)
        {
          if (_context.PessoaNaturalidade == null)
          {
              return Problem("Entity set 'ArgysApiContext.PessoaNaturalidade'  is null.");
          }
            _context.PessoaNaturalidade.Add(pessoaNaturalidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoaNaturalidade", new { id = pessoaNaturalidade.Id }, pessoaNaturalidade);
        }

        // DELETE: api/PessoaNaturalidade/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoaNaturalidade(long id)
        {
            if (_context.PessoaNaturalidade == null)
            {
                return NotFound();
            }
            var pessoaNaturalidade = await _context.PessoaNaturalidade.FindAsync(id);
            if (pessoaNaturalidade == null)
            {
                return NotFound();
            }

            _context.PessoaNaturalidade.Remove(pessoaNaturalidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaNaturalidadeExists(long id)
        {
            return (_context.PessoaNaturalidade?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
