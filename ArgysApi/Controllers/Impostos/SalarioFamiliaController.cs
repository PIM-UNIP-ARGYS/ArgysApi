using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Data;
using ArgysApi.Models.Impostos;

namespace ArgysApi.Controllers.Impostos
{
    [Route("api/salario_familia")]
    [ApiController]
    public class SalarioFamiliaController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public SalarioFamiliaController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/SalarioFamilia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalarioFamilia>>> GetSalarioFamilia()
        {
          if (_context.SalarioFamilia == null)
          {
              return NotFound();
          }
            return await _context.SalarioFamilia.ToListAsync();
        }

        // GET: api/SalarioFamilia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalarioFamilia>> GetSalarioFamilia(long id)
        {
          if (_context.SalarioFamilia == null)
          {
              return NotFound();
          }
            var salarioFamilia = await _context.SalarioFamilia.FindAsync(id);

            if (salarioFamilia == null)
            {
                return NotFound();
            }

            return salarioFamilia;
        }

        // PUT: api/SalarioFamilia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalarioFamilia(long id, SalarioFamilia salarioFamilia)
        {
            if (id != salarioFamilia.Id)
            {
                return BadRequest();
            }

            _context.Entry(salarioFamilia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalarioFamiliaExists(id))
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

        // POST: api/SalarioFamilia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalarioFamilia>> PostSalarioFamilia(SalarioFamilia salarioFamilia)
        {
          if (_context.SalarioFamilia == null)
          {
              return Problem("Entity set 'ArgysApiContext.SalarioFamilia'  is null.");
          }
            _context.SalarioFamilia.Add(salarioFamilia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalarioFamilia", new { id = salarioFamilia.Id }, salarioFamilia);
        }

        // DELETE: api/SalarioFamilia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalarioFamilia(long id)
        {
            if (_context.SalarioFamilia == null)
            {
                return NotFound();
            }
            var salarioFamilia = await _context.SalarioFamilia.FindAsync(id);
            if (salarioFamilia == null)
            {
                return NotFound();
            }

            _context.SalarioFamilia.Remove(salarioFamilia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalarioFamiliaExists(long id)
        {
            return (_context.SalarioFamilia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
