﻿using ClassLibrary.connectdb;
using ClassLibrary.model;
using ClassLibrary.responsitory;

namespace VNPT.EMPLOYER.services.impl
{
    public class EmployerImpl: Responsetory<Employers>, IEmployer
    {
        public EmployerImpl(DataContext context) : base(context)
        {
        }

        public dynamic getAllEmployer()
        {
            throw new NotImplementedException();
        }
    }
}
