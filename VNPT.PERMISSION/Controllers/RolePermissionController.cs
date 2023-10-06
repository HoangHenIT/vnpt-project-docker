using ClassLibrary.model.permission;
using ClassLibrary.respond;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VNPT.PERMISSION.services;
using VNPT.PERMISSION.services.permission;

namespace VNPT.PERMISSION.Controllers
{
    [Route("api/permission/[controller]")]
    [ApiController]
    [Authorize]
    public class RolePermissionController : Controller
    {
        private readonly IRolePermission m_rolePermission;
        public RolePermissionController(IRolePermission _rolePermission)
        {
            m_rolePermission = _rolePermission;
        }
        [HttpGet("getDanhSachMenuChuaGan")]
        public DataRespond getRolePermisionNotIn(int role_id)
           {
            DataRespond data = new DataRespond();
            try
            {

                data.success = true;
                data.data = m_rolePermission.getRolePermissionNotIn(role_id);
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
        [HttpGet("getDanhSachMenuDaGan")]
        public DataRespond getRolePermision(int role_id)
        {
            DataRespond data = new DataRespond();
            try
            {

                data.success = true;
                data.data = m_rolePermission.getDanhSachMenuDaGan(role_id);
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
        [HttpPost("addRolePermission")]
        public DataRespond addRolePermission([FromBody] List<RolePermissions> listRolePermissions)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.message = "success";
                 foreach (var i in listRolePermissions)
                {
                    m_rolePermission.insertGroupPermission(i);
                }

            }
            catch (Exception e)
            {
                data.success = false;
                data.message = e.Message;
                data.error = e;
            }
            return data;
        }
        [HttpPost("removeRolePermission")]
        public DataRespond removeRolePermission([FromBody] List<RolePermissions> listRolePermissions)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.message = "success";
                foreach (var i in listRolePermissions)
                {
                    i.createday = DateTime.Now;
                    m_rolePermission.removeRolePermission(i);
                }
                
            }
            catch (Exception e)
            {
                data.success = false;
                data.message = e.Message;
                data.error = e;
            }

            return data;
        }
    }
}
