using ClassLibrary.connectdb;
using ClassLibrary.model.permission;
using ClassLibrary.responsitory;

namespace VNPT.PERMISSION.services.impl
{
    public class CategoryMenuImpl : Responsetory<CategoryMenus>, ICategoryMenu
    {
        public CategoryMenuImpl(DataContext context) : base(context)
        {
        }

        //public dynamic getAllCategory()
        //{
        //    var res = (from category in m_context.CategoryMenus.Where(m=>m.category_active == true)
        //               )
        //    return res;
        //}
    }
}
