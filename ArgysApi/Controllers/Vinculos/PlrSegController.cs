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
    [Route("api/plr_seg")]
    [ApiController]
    public class PlrSegController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public PlrSegController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/PlrSeg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlrSeg>>> GetPlrSeg()
        {
          if (_context.PlrSeg == null)
          {
              return NotFound();
          }
            return await _context.PlrSeg.ToListAsync();
        }

        // GET: api/PlrSeg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlrSeg>> GetPlrSeg(long id)
        {
          if (_context.PlrSeg == null)
          {
              return NotFound();
          }
            var plrSeg = await _context.PlrSeg.FindAsync(id);

            if (plrSeg == null)
            {
                return NotFound();
            }

            return plrSeg;
        }

        // PUT: api/PlrSeg/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlrSeg(long id, PlrSeg plrSeg)
        {
            if (id != plrSeg.Id)
            {
                return BadRequest();
            }

            _context.Entry(plrSeg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlrSegExists(id))
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

        // POST: api/PlrSeg
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlrSeg>> PostPlrSeg(PlrSeg plrSeg)
        {
          if (_context.PlrSeg == null)
          {
              return Problem("Entity set 'ArgysApiContext.PlrSeg'  is null.");
          }
            _context.PlrSeg.Add(plrSeg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlrSeg", new { id = plrSeg.Id }, plrSeg);
        }

        // DELETE: api/PlrSeg/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlrSeg(long id)
        {
            if (_context.PlrSeg == null)
            {
                return NotFound();
            }
            var plrSeg = await _context.PlrSeg.FindAsync(id);
            if (plrSeg == null)
            {
                return NotFound();
            }

            _context.PlrSeg.Remove(plrSeg);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlrSegExists(long id)
        {
            return (_context.PlrSeg?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
