using ClassLibrary.model;
using ClassLibrary.respond;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VNPT.AUTH.services.auth;

namespace VNPT.AUTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuth m_auth;
        public AuthController(IAuth _auth)
        {
            m_auth = _auth;
        }
        [AllowAnonymous]
        [HttpGet("login")]
        public DataRespond login(Employers employers)
        {
            return m_auth.login(employers);
        }

    }
}
