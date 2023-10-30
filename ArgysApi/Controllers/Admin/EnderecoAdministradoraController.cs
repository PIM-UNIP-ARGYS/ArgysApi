using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Data;
using ArgysApi.Models.Admin;

namespace ArgysApi.Controllers.Admin
{
    [Route("api/endereco_administradora")]
    [ApiController]
    public class EnderecoAdministradoraController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public EnderecoAdministradoraController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/EnderecoAdministradora
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoAdministradora>>> GetEnderecoAdministradora()
        {
            if (_context.EnderecoAdministradora == null)
            {
                return NotFound();
            }
            return await _context.EnderecoAdministradora.ToListAsync();
        }

        // GET: api/EnderecoAdministradora/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoAdministradora>> GetEnderecoAdministradora(long id)
        {
            if (_context.EnderecoAdministradora == null)
            {
                return NotFound();
            }
            var enderecoAdministradora = await _context.EnderecoAdministradora.FindAsync(id);

            if (enderecoAdministradora == null)
            {
                return NotFound();
            }

            return enderecoAdministradora;
        }

        // PUT: api/EnderecoAdministradora/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnderecoAdministradora(long id, EnderecoAdministradora enderecoAdministradora)
        {
            if (id != enderecoAdministradora.Id)
            {
                return BadRequest();
            }

            _context.Entry(enderecoAdministradora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoAdministradoraExists(id))
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

        // POST: api/EnderecoAdministradora
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnderecoAdministradora>> PostEnderecoAdministradora(EnderecoAdministradora enderecoAdministradora)
        {
            if (_context.EnderecoAdministradora == null)
            {
                return Problem("Entity set 'ArgysApiContext.EnderecoAdministradora'  is null.");
            }
            _context.EnderecoAdministradora.Add(enderecoAdministradora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnderecoAdministradora", new { id = enderecoAdministradora.Id }, enderecoAdministradora);
        }

        // DELETE: api/EnderecoAdministradora/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnderecoAdministradora(long id)
        {
            if (_context.EnderecoAdministradora == null)
            {
                return NotFound();
            }
            var enderecoAdministradora = await _context.EnderecoAdministradora.FindAsync(id);
            if (enderecoAdministradora == null)
            {
                return NotFound();
            }

            _context.EnderecoAdministradora.Remove(enderecoAdministradora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnderecoAdministradoraExists(long id)
        {
            return (_context.EnderecoAdministradora?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
