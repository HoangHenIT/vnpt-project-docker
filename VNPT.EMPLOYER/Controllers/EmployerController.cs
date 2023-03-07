using ClassLibrary.auth.hashpass;
using ClassLibrary.model;
using ClassLibrary.respond;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using VNPT.EMPLOYER.services;

namespace VNPT.EMPLOYER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployer m_employer;
        private IHashPass m_hashPass;
        public EmployerController(IEmployer _employer, IHashPass _hashPass)
        {
            m_employer = _employer;
            m_hashPass = _hashPass;
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
        [AllowAnonymous]
        [HttpPost("InsertEmployer")]
        public DataRespond InsertEmployer([FromBody] Employers employer)
        {
            DataRespond data = new DataRespond();
            try
            {
                Employers empl = new Employers();
                empl.full_name = employer.full_name;
                empl.name_profile = employer.name_profile;
                empl.job_name = employer.job_name;
                empl.company = employer.company;
                empl.email = employer.email;
                empl.number_phone = employer.number_phone;
                empl.mobile = employer.mobile;
                empl.email = employer.email;
                empl.password = m_hashPass.hashPass(employer.password);
                empl.active = employer.active;
                empl.role_id = employer.role_id;
                empl.address = employer.address;
                empl.link_website = employer.link_website;
                empl.link_git = employer.link_git;
                empl.link_facebook = employer.link_facebook;
                if (m_employer.checkeEmployer(empl))
                {
                    m_employer.insert(empl);
                    data.success = true;
                    data.message = "Insert Employer '" + empl.full_name + "' success";
                }else
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

        //update new Employer
        [HttpPost("updateEmployer")]
        public DataRespond updateEmployer([FromBody] Employers employer)
        {
            DataRespond data = new DataRespond();
            try
            {
                var empl =  m_employer.getById(employer.employer_id);
                empl.full_name = employer.full_name;
                empl.name_profile = employer.name_profile;
                empl.job_name = employer.job_name;
                empl.company = employer.company;
                empl.email = employer.email;
                empl.number_phone = employer.number_phone;
                empl.mobile= employer.mobile;
                empl.email = employer.email;
                empl.password = m_hashPass.hashPass(employer.password);
                empl.active = employer.active;
                empl.role_id = employer.role_id;
                empl.address = employer.address;
                empl.link_website = employer.link_website;
                empl.link_git= employer.link_git;
                empl.link_facebook= employer.link_facebook;

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
