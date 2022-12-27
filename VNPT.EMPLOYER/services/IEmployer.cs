using ClassLibrary.model;
using ClassLibrary.responsitory;

namespace VNPT.EMPLOYER.services
{
    public interface IEmployer :IResponsetory<Employers>
    {
        dynamic getAllEmployer();
    }
}
