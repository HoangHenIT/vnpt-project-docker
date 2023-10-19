using ClassLibrary.respond;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VNPT.PERMISSION.services.permission;
using VNPT.PERMISSION.services.permission.impl;

namespace VNPT.PERMISSION.Controllers
{
    [Route("api/permission/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployerPermissionController : Controller
    {
        private readonly IEmployPermission m_employPermission;
        public EmployerPermissionController(IEmployPermission _employPermission)
        {
            m_employPermission = _employPermission;
        }
        [HttpGet("getDanhSachNguoiDungChuaGan")]
        public DataRespond getDanhSachNguoiDungChuaGan(int role_id)
        {
            DataRespond data = new DataRespond();
            try
            {

                data.success = true;
                data.data = m_employPermission.getDanhSachNguoiDungChuaGan(role_id);
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
    }
}
