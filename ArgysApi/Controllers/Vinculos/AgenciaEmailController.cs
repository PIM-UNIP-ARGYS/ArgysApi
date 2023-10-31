using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Data;
using ArgysApi.Models.Vinculos;

namespace ArgysApi.Controllers.Vinculos
{
    [Route("api/agencia_email")]
    [ApiController]
    public class AgenciaEmailController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public AgenciaEmailController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/AgenciaEmail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgenciaEmail>>> GetAgenciaEmail()
        {
          if (_context.AgenciaEmail == null)
          {
              return NotFound();
          }
            return await _context.AgenciaEmail.ToListAsync();
        }

        // GET: api/AgenciaEmail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgenciaEmail>> GetAgenciaEmail(long id)
        {
          if (_context.AgenciaEmail == null)
          {
              return NotFound();
          }
            var agenciaEmail = await _context.AgenciaEmail.FindAsync(id);

            if (agenciaEmail == null)
            {
                return NotFound();
            }

            return agenciaEmail;
        }

        // PUT: api/AgenciaEmail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgenciaEmail(long id, AgenciaEmail agenciaEmail)
        {
            if (id != agenciaEmail.Id)
            {
                return BadRequest();
            }

            _context.Entry(agenciaEmail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenciaEmailExists(id))
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

        // POST: api/AgenciaEmail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AgenciaEmail>> PostAgenciaEmail(AgenciaEmail agenciaEmail)
        {
          if (_context.AgenciaEmail == null)
          {
              return Problem("Entity set 'ArgysApiContext.AgenciaEmail'  is null.");
          }
            _context.AgenciaEmail.Add(agenciaEmail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgenciaEmail", new { id = agenciaEmail.Id }, agenciaEmail);
        }

        // DELETE: api/AgenciaEmail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgenciaEmail(long id)
        {
            if (_context.AgenciaEmail == null)
            {
                return NotFound();
            }
            var agenciaEmail = await _context.AgenciaEmail.FindAsync(id);
            if (agenciaEmail == null)
            {
                return NotFound();
            }

            _context.AgenciaEmail.Remove(agenciaEmail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgenciaEmailExists(long id)
        {
            return (_context.AgenciaEmail?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
