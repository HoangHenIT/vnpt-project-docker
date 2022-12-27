using ClassLibrary.model;
using ClassLibrary.respond;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VNPT.EMPLOYER.services;

namespace VNPT.EMPLOYER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployer m_employer;

        public EmployerController(IEmployer _employer)
        {
            m_employer = _employer;
        }
        [HttpGet("getAllEmployer")]
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
        //insert new Employer
        [HttpPost("InsertEmployer")]
        public DataRespond InsertEmployer([FromForm] Employers employer)
        {
            DataRespond data = new DataRespond();
            try
            {
                Employers employers = new Employers();
                employers.full_name = employer.full_name;
                employers.email = employer.email;
                employers.number_phone = employer.number_phone;
                employers.email= employer.email;
                employers.password = employer.password;
                employers.active = true;
                employers.role_id = employer.role_id;
                m_employer.insert(employers);
                data.success = true;
                data.data= m_employer.getAll();
                data.message = "Insert Employer success";
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
