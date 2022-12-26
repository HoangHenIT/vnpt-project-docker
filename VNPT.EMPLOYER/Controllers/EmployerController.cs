using ClassLibrary.respond;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VNPT.EMPLOYER.services;

namespace VNPT.EMPLOYER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployer m_employer;

        public EmployerController(IEmployer _employer)
        {
            m_employer = _employer;
        }
        [AllowAnonymous]
        [HttpGet("getAll")]
        public DataRespond getAllEmployer()
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.data = m_employer.getAll();
                data.message = "Get all Employer";
            }catch(Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }

    }
}
