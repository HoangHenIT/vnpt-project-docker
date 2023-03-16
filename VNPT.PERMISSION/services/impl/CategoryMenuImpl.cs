using ClassLibrary.connectdb;
using ClassLibrary.model;
using ClassLibrary.model.permission;
using ClassLibrary.responsitory;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;
using System.Xml.Linq;

namespace VNPT.PERMISSION.services.impl
{
    public class CategoryMenuImpl : Responsetory<CategoryMenus>, ICategoryMenu
    {
        public CategoryMenuImpl(DataContext context) : base(context)
        {
        }

        public dynamic getCategoryFath()
        {
            //string[] menucha = { "0", "Menu Cha", "0", "", "", "true", "0", "0" };
            var res = (from category in m_context.CategoryMenu.Where(m => m.category_active == true)
                       select new
                       {
                           category_id = category.category_id,
                           category_name = category.category_name,
                           category_level = category.category_level,
                           category_icon = category.category_icon,
                           category_note = category.category_note,
                           category_active = category.category_active,
                           category_cha_id = category.category_cha_id,
                           position = category.position
                       }).ToList();
            return res;
        }

    }
}
