using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Data;
using ArgysApi.Models.Empresas;

namespace ArgysApi.Controllers.Empresas
{
    [Route("api/endereco_empresa")]
    [ApiController]
    public class EnderecoEmpresaController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public EnderecoEmpresaController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/EnderecoEmpresa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoEmpresa>>> GetEnderecoEmpresa()
        {
          if (_context.EnderecoEmpresa == null)
          {
              return NotFound();
          }
            return await _context.EnderecoEmpresa.ToListAsync();
        }

        // GET: api/EnderecoEmpresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoEmpresa>> GetEnderecoEmpresa(long id)
        {
          if (_context.EnderecoEmpresa == null)
          {
              return NotFound();
          }
            var enderecoEmpresa = await _context.EnderecoEmpresa.FindAsync(id);

            if (enderecoEmpresa == null)
            {
                return NotFound();
            }

            return enderecoEmpresa;
        }

        // PUT: api/EnderecoEmpresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnderecoEmpresa(long id, EnderecoEmpresa enderecoEmpresa)
        {
            if (id != enderecoEmpresa.Id)
            {
                return BadRequest();
            }

            _context.Entry(enderecoEmpresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoEmpresaExists(id))
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

        // POST: api/EnderecoEmpresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnderecoEmpresa>> PostEnderecoEmpresa(EnderecoEmpresa enderecoEmpresa)
        {
          if (_context.EnderecoEmpresa == null)
          {
              return Problem("Entity set 'ArgysApiContext.EnderecoEmpresa'  is null.");
          }
            _context.EnderecoEmpresa.Add(enderecoEmpresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnderecoEmpresa", new { id = enderecoEmpresa.Id }, enderecoEmpresa);
        }

        // DELETE: api/EnderecoEmpresa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnderecoEmpresa(long id)
        {
            if (_context.EnderecoEmpresa == null)
            {
                return NotFound();
            }
            var enderecoEmpresa = await _context.EnderecoEmpresa.FindAsync(id);
            if (enderecoEmpresa == null)
            {
                return NotFound();
            }

            _context.EnderecoEmpresa.Remove(enderecoEmpresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnderecoEmpresaExists(long id)
        {
            return (_context.EnderecoEmpresa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
