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
    [Route("api/ferias_historico")]
    [ApiController]
    public class FeriasHistoricoController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public FeriasHistoricoController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/FeriasHistorico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeriasHistorico>>> GetFeriasHistorico()
        {
          if (_context.FeriasHistorico == null)
          {
              return NotFound();
          }
            return await _context.FeriasHistorico.ToListAsync();
        }

        // GET: api/FeriasHistorico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeriasHistorico>> GetFeriasHistorico(long id)
        {
          if (_context.FeriasHistorico == null)
          {
              return NotFound();
          }
            var feriasHistorico = await _context.FeriasHistorico.FindAsync(id);

            if (feriasHistorico == null)
            {
                return NotFound();
            }

            return feriasHistorico;
        }

        // PUT: api/FeriasHistorico/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeriasHistorico(long id, FeriasHistorico feriasHistorico)
        {
            if (id != feriasHistorico.Id)
            {
                return BadRequest();
            }

            _context.Entry(feriasHistorico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeriasHistoricoExists(id))
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

        // POST: api/FeriasHistorico
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeriasHistorico>> PostFeriasHistorico(FeriasHistorico feriasHistorico)
        {
          if (_context.FeriasHistorico == null)
          {
              return Problem("Entity set 'ArgysApiContext.FeriasHistorico'  is null.");
          }
            _context.FeriasHistorico.Add(feriasHistorico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeriasHistorico", new { id = feriasHistorico.Id }, feriasHistorico);
        }

        // DELETE: api/FeriasHistorico/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeriasHistorico(long id)
        {
            if (_context.FeriasHistorico == null)
            {
                return NotFound();
            }
            var feriasHistorico = await _context.FeriasHistorico.FindAsync(id);
            if (feriasHistorico == null)
            {
                return NotFound();
            }

            _context.FeriasHistorico.Remove(feriasHistorico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeriasHistoricoExists(long id)
        {
            return (_context.FeriasHistorico?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
