
﻿using ClassLibrary.model.permission;
using ClassLibrary.respond;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VNPT.PERMISSION.services.permission;

namespace VNPT.PERMISSION.Controllers
{
    [Route("api/permission/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployerPermissionController : Controller
    {
        private readonly IEmployerPermission m_employerPermission;
        public EmployerPermissionController(IEmployerPermission _employerPermission)
        {
            m_employerPermission = _employerPermission;
        }
        [HttpGet("getDanhSachNguoiDungChuaGan")]
        public DataRespond getDanhSachNguoiDungChuaGan(int role_id)
        {
            DataRespond data = new DataRespond();
            try
            {

                data.success = true;
                data.data = m_employerPermission.getEmployPermissionNotIn(role_id);
                data.message = "Lấy danh sách người dùng thành công";
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
        [HttpGet("getDanhSachNguoiDungDaGan")]
        public DataRespond getDanhSachNguoiDungDaGan(int role_id)
        {
            DataRespond data = new DataRespond();
            try
            {

                data.success = true;
                data.data = m_employerPermission.getDanhSachNguoiDungDaGan(role_id);
                data.message = "Lấy danh sách người dùng thành công";
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
        [HttpPost("insertEmployPermission")]
        public DataRespond insertEmployPermission([FromBody] List<EmployePermissions> listEmployes)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.message = "success";
                foreach (var i in listEmployes)
                {
                    m_employerPermission.insertEmployPermission(i);
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
        [HttpPost("deleteEmployPermission")]
        public DataRespond deleteEmployPermission([FromBody] List<EmployePermissions> listEmployes)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.message = "success";
                foreach (var i in listEmployes)
                {
                    m_employerPermission.deleteEmployPermission(i);
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
