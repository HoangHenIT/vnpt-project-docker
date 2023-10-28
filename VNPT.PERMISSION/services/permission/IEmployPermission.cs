using ClassLibrary.model.permission;
using ClassLibrary.responsitory;

namespace VNPT.PERMISSION.services.permission
{
    public interface IEmployPermission : IOCOPResponsetory<EmployePermissions>
    {
        public dynamic getDanhSachNguoiDungChuaGan(int role_id);
    }
}
