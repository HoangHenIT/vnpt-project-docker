using ClassLibrary.respond;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VNPT.AUTH.services.roles;

namespace VNPT.AUTH.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IRoler m_roler;
        public RolesController(IRoler _roler)
        {
            m_roler = _roler;
        }

        [HttpGet("getAllRoler")]
        public DataRespond getAllRoler()
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.data = m_roler.getAll();
                data.message = "Get all Roler success";
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
    }
}
