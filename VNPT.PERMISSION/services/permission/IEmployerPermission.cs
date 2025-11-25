using ClassLibrary.model.permission;
using ClassLibrary.responsitory;

namespace VNPT.PERMISSION.services.permission
{
    public interface IEmployerPermission : IResponsetory<EmployePermissions>
    {
        public dynamic getEmployPermissionNotIn(int role_id);
        public dynamic getDanhSachNguoiDungDaGan(int role_id);
        public dynamic insertEmployPermission(EmployePermissions employe);
        public dynamic deleteEmployPermission(EmployePermissions employe);
    }
}
