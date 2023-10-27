using ClassLibrary.model;
using ClassLibrary.model.permission;
using ClassLibrary.responsitory;

namespace VNPT.PERMISSION.services.impl
{
    public interface ICategoryMenu : IResponsetory<CategoryMenus>
    {
        public dynamic getCategoryFath();
        bool checkCategory(CategoryMenus category);
        public dynamic getDanhSachMenuTheoNguoiDung(int employid);
    }
}
