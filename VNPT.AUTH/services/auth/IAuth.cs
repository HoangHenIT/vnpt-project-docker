using ClassLibrary.model;
using ClassLibrary.respond;
using ClassLibrary.responsitory;

namespace VNPT.AUTH.services.auth
{

    public interface IAuth: IResponsetory<Employers>
    {
        DataRespond login(Employers employers);
    }
}
