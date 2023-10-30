using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Data;
using ArgysApi.Models.Usuarios;

namespace ArgysApi.Controllers.Usuarios
{
    [Route("api/usuario_empresa")]
    [ApiController]
    public class UsuarioEmpresaController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public UsuarioEmpresaController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioEmpresa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioEmpresa>>> GetUsuarioEmpresa()
        {
          if (_context.UsuarioEmpresa == null)
          {
              return NotFound();
          }
            return await _context.UsuarioEmpresa.ToListAsync();
        }

        // GET: api/UsuarioEmpresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioEmpresa>> GetUsuarioEmpresa(long id)
        {
          if (_context.UsuarioEmpresa == null)
          {
              return NotFound();
          }
            var usuarioEmpresa = await _context.UsuarioEmpresa.FindAsync(id);

            if (usuarioEmpresa == null)
            {
                return NotFound();
            }

            return usuarioEmpresa;
        }

        // PUT: api/UsuarioEmpresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioEmpresa(long id, UsuarioEmpresa usuarioEmpresa)
        {
            if (id != usuarioEmpresa.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioEmpresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioEmpresaExists(id))
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

        // POST: api/UsuarioEmpresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioEmpresa>> PostUsuarioEmpresa(UsuarioEmpresa usuarioEmpresa)
        {
          if (_context.UsuarioEmpresa == null)
          {
              return Problem("Entity set 'ArgysApiContext.UsuarioEmpresa'  is null.");
          }
            _context.UsuarioEmpresa.Add(usuarioEmpresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioEmpresa", new { id = usuarioEmpresa.Id }, usuarioEmpresa);
        }

        // DELETE: api/UsuarioEmpresa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioEmpresa(long id)
        {
            if (_context.UsuarioEmpresa == null)
            {
                return NotFound();
            }
            var usuarioEmpresa = await _context.UsuarioEmpresa.FindAsync(id);
            if (usuarioEmpresa == null)
            {
                return NotFound();
            }

            _context.UsuarioEmpresa.Remove(usuarioEmpresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioEmpresaExists(long id)
        {
            return (_context.UsuarioEmpresa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
