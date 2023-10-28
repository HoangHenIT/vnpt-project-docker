

using ClassLibrary.model;
using ClassLibrary.responsitory;

namespace VNPT.EMPLOYER.services
{
    public interface IEmployer :IResponsetory<Employers>
    {
        Boolean checkeEmployer(Employers employers);
        public dynamic getEmployer();
    }
}
