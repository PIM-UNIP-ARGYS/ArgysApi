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
    [Route("api/cargo")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public CargoController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/Cargo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargo()
        {
          if (_context.Cargo == null)
          {
              return NotFound();
          }
            return await _context.Cargo.ToListAsync();
        }

        // GET: api/Cargo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cargo>> GetCargo(long id)
        {
          if (_context.Cargo == null)
          {
              return NotFound();
          }
            var cargo = await _context.Cargo.FindAsync(id);

            if (cargo == null)
            {
                return NotFound();
            }

            return cargo;
        }

        // PUT: api/Cargo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargo(long id, Cargo cargo)
        {
            if (id != cargo.Id)
            {
                return BadRequest();
            }

            _context.Entry(cargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoExists(id))
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

        // POST: api/Cargo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cargo>> PostCargo(CargoRequest request)
        {
            if (_context.Cargo == null)
            {
                return Problem("Entity set 'ArgysApiContext.Cargo'  is null.");
            }

            int newCode = GetNewCode();

            var cbo = await _context.Cbo.FirstOrDefaultAsync(x => x.Descricao == request.Cbo);

            Cargo cargo = CargoMapper.ToCargoEntity(request);
            cargo.CboId = cbo.Id;
            cargo.Codigo = newCode.ToString();

            _context.Cargo.Add(cargo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCargo", cargo);
        }

        // DELETE: api/Cargo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargo(long id)
        {
            if (_context.Cargo == null)
            {
                return NotFound();
            }
            var cargo = await _context.Cargo.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }

            _context.Cargo.Remove(cargo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CargoExists(long id)
        {
            return (_context.Cargo?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private int GetNewCode()
        {
            var cargo = _context.Cargo.OrderByDescending(p => p.Codigo).FirstOrDefault();

            if (cargo == null)
            {
                return 1;
            }

            var newCode = int.Parse(cargo.Codigo) + 1;

            return newCode;

        }
    }
}
