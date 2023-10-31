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
    [Route("api/inss")]
    [ApiController]
    public class InssController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public InssController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/Inss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inss>>> GetInss()
        {
          if (_context.Inss == null)
          {
              return NotFound();
          }
            return await _context.Inss.ToListAsync();
        }

        // GET: api/Inss/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inss>> GetInss(long id)
        {
          if (_context.Inss == null)
          {
              return NotFound();
          }
            var inss = await _context.Inss.FindAsync(id);

            if (inss == null)
            {
                return NotFound();
            }

            return inss;
        }

        // PUT: api/Inss/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInss(long id, Inss inss)
        {
            if (id != inss.Id)
            {
                return BadRequest();
            }

            _context.Entry(inss).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InssExists(id))
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

        // POST: api/Inss
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inss>> PostInss(Inss inss)
        {
          if (_context.Inss == null)
          {
              return Problem("Entity set 'ArgysApiContext.Inss'  is null.");
          }
            _context.Inss.Add(inss);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInss", new { id = inss.Id }, inss);
        }

        // DELETE: api/Inss/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInss(long id)
        {
            if (_context.Inss == null)
            {
                return NotFound();
            }
            var inss = await _context.Inss.FindAsync(id);
            if (inss == null)
            {
                return NotFound();
            }

            _context.Inss.Remove(inss);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InssExists(long id)
        {
            return (_context.Inss?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
