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
                password = n.password,
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

    }
}
