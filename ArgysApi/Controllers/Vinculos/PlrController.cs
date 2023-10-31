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
    [Route("api/plr")]
    [ApiController]
    public class PlrController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public PlrController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/Plr
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plr>>> GetPlr()
        {
          if (_context.Plr == null)
          {
              return NotFound();
          }
            return await _context.Plr.ToListAsync();
        }

        // GET: api/Plr/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plr>> GetPlr(long id)
        {
          if (_context.Plr == null)
          {
              return NotFound();
          }
            var plr = await _context.Plr.FindAsync(id);

            if (plr == null)
            {
                return NotFound();
            }

            return plr;
        }

        // PUT: api/Plr/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlr(long id, Plr plr)
        {
            if (id != plr.Id)
            {
                return BadRequest();
            }

            _context.Entry(plr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlrExists(id))
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

        // POST: api/Plr
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plr>> PostPlr(Plr plr)
        {
          if (_context.Plr == null)
          {
              return Problem("Entity set 'ArgysApiContext.Plr'  is null.");
          }
            _context.Plr.Add(plr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlr", new { id = plr.Id }, plr);
        }

        // DELETE: api/Plr/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlr(long id)
        {
            if (_context.Plr == null)
            {
                return NotFound();
            }
            var plr = await _context.Plr.FindAsync(id);
            if (plr == null)
            {
                return NotFound();
            }

            _context.Plr.Remove(plr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlrExists(long id)
        {
            return (_context.Plr?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
