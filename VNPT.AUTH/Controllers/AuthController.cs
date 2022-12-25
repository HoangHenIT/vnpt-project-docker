using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VNPT.AUTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("getValues")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
