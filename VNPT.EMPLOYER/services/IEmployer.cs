using ClassLibrary.model;
using ClassLibrary.responsitory;

namespace VNPT.EMPLOYER.services
{
    public interface IEmployer :IResponsitory<Employers>
    {
        dynamic getAllEmployer();
    }
}
