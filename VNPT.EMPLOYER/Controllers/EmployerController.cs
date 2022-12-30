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
                if (m_employer.checkeEmployer(employers))
                {
                    m_employer.insert(employers);
                    data.success = true;
                    data.message = "Insert Employer '" + employers.full_name + "' success";
                }else
                {
                    data.success = false;
                    data.message = "Employer '" + employers.email + "' already exists!!! ";
                }
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;      
            }
            return data;
        }

        //update new Employer
        [HttpPost("updateEmployer")]
        public DataRespond updateEmployer([FromBody] Employers employer)
        {
            DataRespond data = new DataRespond();
            try
            {
                var empl =  m_employer.getById(employer.employer_id);
                empl.full_name = employer.full_name;
                empl.email = employer.email;
                empl.number_phone = employer.number_phone;
                empl.email = employer.email;
                empl.password = employer.password;
                empl.active = employer.active;
                empl.role_id = employer.role_id;

                if (m_employer.checkeEmployer(empl))
                {
                    m_employer.update(empl);
                    data.success = true;
                    data.data = m_employer.getById(empl.employer_id);
                    data.message = "Update Employer '"+ empl.full_name + "' success";
                }
                else
                {
                    data.success = false;
                    data.message = "Employer '" + empl.email + "' already exists!!! ";
                }
                
                
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
        [HttpDelete("deleteEmployer")]
        public DataRespond deleteEmployer(int employer_id)
        {
            DataRespond data = new DataRespond();
            try
            {
                Employers empl = m_employer.getById(employer_id);
                data.success = true;
                m_employer.delete(empl.employer_id);
                data.data = m_employer.getAll();
                data.message = "Delete Roler '" + empl.full_name + "' success";

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
