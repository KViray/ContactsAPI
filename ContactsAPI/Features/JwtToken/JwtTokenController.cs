using ContactsAPI.Features.Contact.Services;
using ContactsAPI.Features.JwtToken.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Features.JwtToken
{
    [ApiController]
    [Route("[controller]")]
    public class JwtTokenController : Controller
    {
        private readonly IJwtTokenService _jwtTokenService;
        public JwtTokenController(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }
        [HttpPost]
        public async Task<ActionResult> GenerateToken()
        {
            var token = await _jwtTokenService.CreateToken();
            var newToken = new
            {
                Token = token
            };
            return Ok(newToken);
        }
    }
}
