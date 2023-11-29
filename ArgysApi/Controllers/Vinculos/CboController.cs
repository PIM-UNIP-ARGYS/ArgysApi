using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Data;
using ArgysApi.Models.Vinculos;
using ArgysApi.request.Vinculos;
using ArgysApi.mappers.Vinculos;

namespace ArgysApi.Controllers.Vinculos
{
    [Route("api/cbo")]
    [ApiController]
    public class CboController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public CboController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/Cbo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cbo>>> GetCbo()
        {
          if (_context.Cbo == null)
          {
              return NotFound();
          }
            return await _context.Cbo.ToListAsync();
        }

        // GET: api/Cbo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cbo>> GetCbo(long id)
        {
          if (_context.Cbo == null)
          {
              return NotFound();
          }
            var cbo = await _context.Cbo.FindAsync(id);

            if (cbo == null)
            {
                return NotFound();
            }

            return cbo;
        }

        // PUT: api/Cbo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCbo(long id, Cbo cbo)
        {
            if (id != cbo.Id)
            {
                return BadRequest();
            }

            _context.Entry(cbo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CboExists(id))
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

        // POST: api/Cbo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cbo>> PostCbo(CboRequest request)
        {
            if (_context.Cbo == null)
            {
                return Problem("Entity set 'ArgysApiContext.Cbo'  is null.");
            }

            int newCode = this.GetNewCode();

            Cbo cbo = CboMapper.ToCboEntity(request);
            cbo.Codigo = newCode.ToString();

            _context.Cbo.Add(cbo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCbo", cbo);
        }

        // DELETE: api/Cbo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCbo(long id)
        {
            if (_context.Cbo == null)
            {
                return NotFound();
            }
            var cbo = await _context.Cbo.FindAsync(id);
            if (cbo == null)
            {
                return NotFound();
            }

            _context.Cbo.Remove(cbo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CboExists(long id)
        {
            return (_context.Cbo?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private int GetNewCode()
        {
            var cbo = _context.Cbo.OrderByDescending(p => p.Codigo).FirstOrDefault();

            if (cbo == null)
            {
                return 1;
            }

            var newCode = int.Parse(cbo.Codigo) + 1;

            return newCode;

        }
    }
}
