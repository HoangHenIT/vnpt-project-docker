using ClassLibrary.auth.hashpass;
using ClassLibrary.model;
using ClassLibrary.model.permission;
using ClassLibrary.respond;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VNPT.PERMISSION.services;

namespace VNPT.PERMISSION.Controllers
{
    [Route("api/permission/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryMenuController : Controller
    {
        private readonly ICategoryMenu m_category;
        public CategoryMenuController(ICategoryMenu _category)
        {
            m_category = _category;
        }
        [HttpGet("getAllCategory")]
        public DataRespond getAllCategory()
        {
            DataRespond data = new DataRespond();
            try
            {

                data.success = true;
                data.data = m_category.getAll();
                data.message = "Get all Catagory success";
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
        [HttpGet("getCategoryFath")]
        public DataRespond getCategoryFath()
        {
            DataRespond data = new DataRespond();
            try
            {

                data.success = true;
                data.data = m_category.getCategoryFath();
                data.message = "Get all Catagory success";
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
        [HttpPost("InsertCategory")]
        public DataRespond InsertCategory(CategoryMenus categoryMenus)
        {
            DataRespond data = new DataRespond();
            try
            {
                CategoryMenus category = new CategoryMenus();
                category.category_name = categoryMenus.category_name;
                category.category_link = categoryMenus.category_link;
                category.category_level = categoryMenus.category_level;
                category.category_icon = categoryMenus.category_icon;
                category.category_note = categoryMenus.category_note;
                category.category_cha_id = categoryMenus.category_cha_id;
                category.category_active = true;
                category.position = categoryMenus.position;
                category.createday = DateTime.Now;
                m_category.insert(category);
                getAllCategory();
                data.success = true;
                data.message = "Insert menu " + category.category_name + " success";
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
        [HttpDelete("DeleteCategory")]
        public DataRespond DeleteCategory(int category_id)
        {
            DataRespond data = new DataRespond();
            try
            {
                CategoryMenus category = m_category.getById(category_id);
                data.success = true;
                 m_category.delete(category.category_id);
                data.message = "Delete Roler '" + category.category_name + "' success";
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
    }

}
