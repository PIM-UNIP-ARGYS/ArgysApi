using ArgysApi.Data;
using ArgysApi.Models.Usuarios;
using ArgysApi.request.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArgysApi.Controllers.Auth
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public AuthController(ArgysApiContext context)
        {
            _context = context;
        }

        // POST: api/auth
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthRequest request)
        {
            var existingUser = await _context.Usuario.FirstOrDefaultAsync(x => x.Email == request.Email && x.Senha == request.Senha);

            if (existingUser == null)
            {
                return Unauthorized();
            }

            return Ok();
        }
    }
}
