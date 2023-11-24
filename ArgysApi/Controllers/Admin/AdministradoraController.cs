using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Data;
using ArgysApi.Models.Admin;
using ArgysApi.request.Admin;
using ArgysApi.mappers.Admin;

namespace ArgysApi.Controllers.Admin
{
    [Route("api/administradora")]
    [ApiController]
    public class AdministradoraController : ControllerBase
    {
        private readonly ArgysApiContext _context;
        private readonly AdministradoraMapper _mapper;

        public AdministradoraController(ArgysApiContext context, AdministradoraMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Administradora
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administradora>>> GetAdministradora()
        {
            if (_context.Administradora == null)
            {
                return NotFound();
            }
            return await _context.Administradora.ToListAsync();
        }

        // GET: api/Administradora/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administradora>> GetAdministradora(long id)
        {
            if (_context.Administradora == null)
            {
                return NotFound();
            }
            var administradora = await _context.Administradora.FindAsync(id);

            if (administradora == null)
            {
                return NotFound();
            }

            return administradora;
        }

        // PUT: api/Administradora/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministradora(long id, Administradora administradora)
        {
            if (id != administradora.Id)
            {
                return BadRequest();
            }

            _context.Entry(administradora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradoraExists(id))
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

        // POST: api/Administradora
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdministradoraResponse>> PostAdministradora(AdministradoraRequest request)
        {
            if (_context.Administradora == null)
            {
                return Problem("Entity set 'ArgysApiContext.Administradora'  is null.");
            }

            Administradora administradora = _mapper.MapToEntity(request);

            _context.Administradora.Add(administradora);
            await _context.SaveChangesAsync();

            AdministradoraResponse administradoraResponse = _mapper.MapToResponse(administradora);

            return CreatedAtAction("GetAdministradora", administradoraResponse);
        }

        // DELETE: api/Administradora/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministradora(long id)
        {
            if (_context.Administradora == null)
            {
                return NotFound();
            }
            var administradora = await _context.Administradora.FindAsync(id);
            if (administradora == null)
            {
                return NotFound();
            }

            _context.Administradora.Remove(administradora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministradoraExists(long id)
        {
            return (_context.Administradora?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
