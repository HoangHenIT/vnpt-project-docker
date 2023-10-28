using ClassLibrary.auth.hashpass;
using ClassLibrary.model;
using ClassLibrary.model.permission;
using ClassLibrary.respond;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using VNPT.AUTH.services.roles;
using VNPT.OCOPSERVICE.services.ocop;
using VNPT.PERMISSION.services.impl;

namespace VNPT.PERMISSION.Controllers
{
    [Route("api/ocop/[controller]")]
    [ApiController]
    [Authorize]
    public class OCOPSanPhamController : Controller
    {
        private readonly IOCOPSanPham m_oCOPSanPham;
        public OCOPSanPhamController(IOCOPSanPham _oCOPSanPham)
        {
            m_oCOPSanPham = _oCOPSanPham;
        }
        [HttpGet("getDanhSachNhomSanPham")]
        public DataRespond getDanhSachNhomSanPham()
        {
            DataRespond data = new DataRespond();
            try
            {

                data.success = true;
                data.data = m_oCOPSanPham.getNhomSanPham();
                data.message = "Lấy danh sách nhóm sản phẩm thành công";
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
