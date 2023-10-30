using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Data;
using ArgysApi.Models.Feriados;

namespace ArgysApi.Controllers.Feriados
{
    [Route("api/feriado_empresa")]
    [ApiController]
    public class FeriadoEmpresaController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public FeriadoEmpresaController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/FeriadoEmpresa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeriadoEmpresa>>> GetFeriadoEmpresa()
        {
          if (_context.FeriadoEmpresa == null)
          {
              return NotFound();
          }
            return await _context.FeriadoEmpresa.ToListAsync();
        }

        // GET: api/FeriadoEmpresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeriadoEmpresa>> GetFeriadoEmpresa(long id)
        {
          if (_context.FeriadoEmpresa == null)
          {
              return NotFound();
          }
            var feriadoEmpresa = await _context.FeriadoEmpresa.FindAsync(id);

            if (feriadoEmpresa == null)
            {
                return NotFound();
            }

            return feriadoEmpresa;
        }

        // PUT: api/FeriadoEmpresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeriadoEmpresa(long id, FeriadoEmpresa feriadoEmpresa)
        {
            if (id != feriadoEmpresa.Id)
            {
                return BadRequest();
            }

            _context.Entry(feriadoEmpresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeriadoEmpresaExists(id))
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

        // POST: api/FeriadoEmpresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeriadoEmpresa>> PostFeriadoEmpresa(FeriadoEmpresa feriadoEmpresa)
        {
          if (_context.FeriadoEmpresa == null)
          {
              return Problem("Entity set 'ArgysApiContext.FeriadoEmpresa'  is null.");
          }
            _context.FeriadoEmpresa.Add(feriadoEmpresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeriadoEmpresa", new { id = feriadoEmpresa.Id }, feriadoEmpresa);
        }

        // DELETE: api/FeriadoEmpresa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeriadoEmpresa(long id)
        {
            if (_context.FeriadoEmpresa == null)
            {
                return NotFound();
            }
            var feriadoEmpresa = await _context.FeriadoEmpresa.FindAsync(id);
            if (feriadoEmpresa == null)
            {
                return NotFound();
            }

            _context.FeriadoEmpresa.Remove(feriadoEmpresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeriadoEmpresaExists(long id)
        {
            return (_context.FeriadoEmpresa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
