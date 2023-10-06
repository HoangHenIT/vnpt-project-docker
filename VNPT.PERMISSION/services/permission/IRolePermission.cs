using ClassLibrary.model.permission;
using ClassLibrary.responsitory;

namespace VNPT.PERMISSION.services.permission
{
    public interface IRolePermission:IResponsetory<RolePermissions>
    {
        public dynamic getRolePermissionNotIn(int role_id);
        public dynamic getDanhSachMenuDaGan(int role_id);
        public dynamic insertGroupPermission (RolePermissions rolePermissions);
        public dynamic removeRolePermission(RolePermissions rolePermissions);
    }
}
