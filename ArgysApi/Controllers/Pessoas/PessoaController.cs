using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Data;
using ArgysApi.Models.Pessoas;
using ArgysApi.request.Pessoas;
using ArgysApi.response.Pessoas;
using ArgysApi.mappers.Pessoas;

namespace ArgysApi.Controllers.Pessoas
{
    [Route("api/pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public PessoaController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/Pessoa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoa()
        {
          if (_context.Pessoa == null)
          {
              return NotFound();
          }
            return await _context.Pessoa.ToListAsync();
        }

        // GET: api/Pessoa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(long id)
        {
          if (_context.Pessoa == null)
          {
              return NotFound();
          }
            var pessoa = await _context.Pessoa.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        // PUT: api/Pessoa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(long id, Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return BadRequest();
            }

            _context.Entry(pessoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
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

        // POST: api/Pessoa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PessoaResponse>> PostPessoa(PessoaRequest request)
        {
            if (_context.Pessoa == null)
            {
                return Problem("Entity set 'ArgysApiContext.Pessoa'  is null.");
            }

            Pessoa pessoa = PessoaMapper.ToPessoaEntity(request);

            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync();

            PessoaEmail email = PessoaEmailMapper.ToPessoaEntity(request, pessoa.Id);
            PessoaEndereco endereco = PessoaEnderecoMapper.ToPessoaEntity(request, pessoa.Id);
            PessoaTelefone telefone = PessoaTelefoneMapper.ToPessoaEntity(request, pessoa.Id);

            _context.PessoaEmail.Add(email);
            _context.PessoaEndereco.Add(endereco);
            _context.PessoaTelefone.Add(telefone);
            await _context.SaveChangesAsync();

            PessoaResponse response = PessoaMapper.ToPessoaResponse(pessoa, email, endereco, telefone);    

            return CreatedAtAction("GetPessoa", response);
        }

        // DELETE: api/Pessoa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(long id)
        {
            if (_context.Pessoa == null)
            {
                return NotFound();
            }
            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaExists(long id)
        {
            return (_context.Pessoa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
