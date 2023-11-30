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
    [Route("api/vinculo")]
    [ApiController]
    public class VinculoController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public VinculoController(ArgysApiContext context)
        {
            _context = context;
        }

        // GET: api/Vinculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vinculo>>> GetVinculo()
        {
          if (_context.Vinculo == null)
          {
              return NotFound();
          }
            return await _context.Vinculo.ToListAsync();
        }

        // GET: api/Vinculo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vinculo>> GetVinculo(long id)
        {
          if (_context.Vinculo == null)
          {
              return NotFound();
          }
            var vinculo = await _context.Vinculo.FindAsync(id);

            if (vinculo == null)
            {
                return NotFound();
            }

            return vinculo;
        }

        // PUT: api/Vinculo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVinculo(long id, Vinculo vinculo)
        {
            if (id != vinculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(vinculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VinculoExists(id))
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

        // POST: api/Vinculo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vinculo>> PostVinculo(VinculoRequest request)
        {
            if (_context.Vinculo == null)
            {
                return Problem("Entity set 'ArgysApiContext.Vinculo'  is null.");
            }

            int newCode = GetNewCode();

            var pessoa = await _context.Pessoa.FirstOrDefaultAsync(x => x.Nome == request.Pessoa);
            var cbo = await _context.Cbo.FirstOrDefaultAsync(x => x.Descricao == request.Cbo);
            var cargo = await _context.Cargo.FirstOrDefaultAsync(x => x.Descricao == request.Cargo);

            Vinculo vinculo = VinculoMapper.ToVinculoEntity(request);
            vinculo.CboId = cbo.Id;
            vinculo.PessoaId = pessoa.Id;
            vinculo.Matricula = newCode.ToString();

            _context.Vinculo.Add(vinculo);
            await _context.SaveChangesAsync();

            VinculoCargo vinculoCargo = VinculoCargoMapper.ToVinculoCargoEntity(vinculo.Id, cargo.Id);
            _context.VinculoCargo.Add(vinculoCargo);
            await _context.SaveChangesAsync();

            VinculoSalario vinculoSalario = VinculoSalarioMapper.ToEntity(request, vinculo.Id);
            _context.VinculoSalario.Add(vinculoSalario);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetVinculo", new { id = vinculo.Id }, vinculo);
        }

        // DELETE: api/Vinculo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVinculo(long id)
        {
            if (_context.Vinculo == null)
            {
                return NotFound();
            }
            var vinculo = await _context.Vinculo.FindAsync(id);
            if (vinculo == null)
            {
                return NotFound();
            }

            _context.Vinculo.Remove(vinculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VinculoExists(long id)
        {
            return (_context.Vinculo?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private int GetNewCode()
        {
            var vinculo = _context.Vinculo.OrderByDescending(p => p.Matricula).FirstOrDefault();

            if (vinculo == null)
            {
                return 1;
            }

            var newCode = int.Parse(vinculo.Matricula) + 1;

            return newCode;

        }
    }
}
