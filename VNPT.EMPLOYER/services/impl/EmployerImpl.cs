using ClassLibrary.connectdb;
using ClassLibrary.model;
using ClassLibrary.responsitory;
using System;

namespace VNPT.EMPLOYER.services.impl
{
    public class EmployerImpl: Responsetory<Employers>, IEmployer
    {
        public EmployerImpl(DataContext context) : base(context)
        {
        }

        public dynamic getAllEmployer(Employers employers)
        {
            return getAll().Where(m => m.email == employers.email).Select( n => new
            {
                
                employer_id = n.employer_id,
                full_name = n.full_name,
                email = n.email,
                number_phone = n.number_phone,
                username = n.username,
                //password = n.password,
                role_id = n.role_id,
                active = n.active,
            }).ToList();
        }
        public bool checkeEmployer(Employers employers)
        {
            var empl = getAllEmployer(employers);
            if(empl.Count <= 1)
            {
                return true;
            }
            return false;
        }

        public dynamic getEmployer()
        {
            var res = (from employer in m_context.Employers
                       join role in m_context.Roles
            on employer.role_id equals role.role_id
                       select new
                       {
                           employer_id = employer.employer_id,
                           full_name = employer.full_name,
                           name_profile = employer.name_profile,
                           job_name = employer.job_name,
                           company = employer.company,
                           email = employer.email,
                           number_phone = employer.number_phone,
                           mobile = employer.mobile,
                           username = employer.username,
                           password = employer.password,
                           role_id = employer.role_id,
                           role_name = role.role_name,
                           active = employer.active,
                           address = employer.address,
                           link_website = employer.link_website,
                           link_git = employer.link_git,
                           link_facebook = employer.link_facebook,
                       }).ToList();
            return res;
        }
    }
}
