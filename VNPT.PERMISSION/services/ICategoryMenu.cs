﻿using ClassLibrary.model;
using ClassLibrary.model.permission;
using ClassLibrary.responsitory;

namespace VNPT.PERMISSION.services
{
    public interface ICategoryMenu : IResponsetory<CategoryMenus>
    {
        public dynamic getCategoryFath();
        Boolean checkCategory(CategoryMenus category);
    }
}
