using ClassLibrary.model;
using ClassLibrary.respond;
using ClassLibrary.responsitory;
using WebApi.reponsitory;

namespace VNPT.AUTH.services.auth
{

    public interface IAuth: IReponsitory<Employers>
    {
        DataRespond login(Employers employers);
        Employers findByLogin(string username);
    }
}
