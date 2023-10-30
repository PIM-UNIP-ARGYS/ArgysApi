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
    [Route("api/grupo_empresa")]
    [ApiController]
    public class GrupoEmpresaController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public GrupoEmpresaController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/GrupoEmpresa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoEmpresa>>> GetGrupoEmpresa()
        {
          if (_context.GrupoEmpresa == null)
          {
              return NotFound();
          }
            return await _context.GrupoEmpresa.ToListAsync();
        }

        // GET: api/GrupoEmpresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoEmpresa>> GetGrupoEmpresa(long id)
        {
          if (_context.GrupoEmpresa == null)
          {
              return NotFound();
          }
            var grupoEmpresa = await _context.GrupoEmpresa.FindAsync(id);

            if (grupoEmpresa == null)
            {
                return NotFound();
            }

            return grupoEmpresa;
        }

        // PUT: api/GrupoEmpresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoEmpresa(long id, GrupoEmpresa grupoEmpresa)
        {
            if (id != grupoEmpresa.Id)
            {
                return BadRequest();
            }

            _context.Entry(grupoEmpresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoEmpresaExists(id))
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

        // POST: api/GrupoEmpresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GrupoEmpresa>> PostGrupoEmpresa(GrupoEmpresa grupoEmpresa)
        {
          if (_context.GrupoEmpresa == null)
          {
              return Problem("Entity set 'ArgysApiContext.GrupoEmpresa'  is null.");
          }
            _context.GrupoEmpresa.Add(grupoEmpresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrupoEmpresa", new { id = grupoEmpresa.Id }, grupoEmpresa);
        }

        // DELETE: api/GrupoEmpresa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoEmpresa(long id)
        {
            if (_context.GrupoEmpresa == null)
            {
                return NotFound();
            }
            var grupoEmpresa = await _context.GrupoEmpresa.FindAsync(id);
            if (grupoEmpresa == null)
            {
                return NotFound();
            }

            _context.GrupoEmpresa.Remove(grupoEmpresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrupoEmpresaExists(long id)
        {
            return (_context.GrupoEmpresa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
