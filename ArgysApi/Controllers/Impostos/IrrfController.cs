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
    [Route("api/irrf")]
    [ApiController]
    public class IrrfController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public IrrfController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/Irrf
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Irrf>>> GetIrrf()
        {
          if (_context.Irrf == null)
          {
              return NotFound();
          }
            return await _context.Irrf.ToListAsync();
        }

        // GET: api/Irrf/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Irrf>> GetIrrf(long id)
        {
          if (_context.Irrf == null)
          {
              return NotFound();
          }
            var irrf = await _context.Irrf.FindAsync(id);

            if (irrf == null)
            {
                return NotFound();
            }

            return irrf;
        }

        // PUT: api/Irrf/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIrrf(long id, Irrf irrf)
        {
            if (id != irrf.Id)
            {
                return BadRequest();
            }

            _context.Entry(irrf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IrrfExists(id))
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

        // POST: api/Irrf
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Irrf>> PostIrrf(Irrf irrf)
        {
          if (_context.Irrf == null)
          {
              return Problem("Entity set 'ArgysApiContext.Irrf'  is null.");
          }
            _context.Irrf.Add(irrf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIrrf", new { id = irrf.Id }, irrf);
        }

        // DELETE: api/Irrf/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIrrf(long id)
        {
            if (_context.Irrf == null)
            {
                return NotFound();
            }
            var irrf = await _context.Irrf.FindAsync(id);
            if (irrf == null)
            {
                return NotFound();
            }

            _context.Irrf.Remove(irrf);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IrrfExists(long id)
        {
            return (_context.Irrf?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
