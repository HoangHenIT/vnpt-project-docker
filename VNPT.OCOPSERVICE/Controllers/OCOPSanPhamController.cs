using ClassLibrary.auth.hashpass;
using ClassLibrary.model;
using ClassLibrary.model.OcopModel;
using ClassLibrary.model.permission;
using ClassLibrary.respond;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
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
                data.data = m_oCOPSanPham.getAll();
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
        [HttpPost("insertDanhSachNhomSanPham")]
        public DataRespond insertDanhSachNhomSanPham([FromBody] NhomspsRequest nhomspsRequest )
        {
            DataRespond data = new DataRespond();
            try
            {

                data.success = true;
                data.data = m_oCOPSanPham.insertDanhSachNhomSanPham(nhomspsRequest);
                data.message = "Thêm mới nhóm sản phẩm ' " + nhomspsRequest.TEN + " ' thành công";
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
        [HttpPost("updateDanhSachNhomSanPham")]
        public DataRespond updateDanhSachNhomSanPham([FromBody] NhomspsRequest nhomspsRequest)
        {
            DataRespond data = new DataRespond();
            try
            {

                data.success = true;
                //string token = Request.Headers["Authorization"][0].Replace("Bearer ", "");
                //var usid_cn = parseJWTT(token);
                data.data = m_oCOPSanPham.updateDanhSachNhomSanPham(nhomspsRequest);
                data.message = "Cập nhật nhóm sản phẩm ' " + nhomspsRequest.TEN + " ' thành công";
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
        [HttpDelete("deleteDanhSachNhomSanPham")]
        public DataRespond deleteDanhSachNhomSanPham(int id)
        {
            DataRespond data = new DataRespond();
            try
            {

                data.success = true;
                //string token = Request.Headers["Authorization"][0].Replace("Bearer ", "");
                //var usid_cn = parseJWTT(token);
                m_oCOPSanPham.delete(id);
                data.message = "Xóa danh mục sản phẩm thành công";
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
        //lấy token user

        //public dynamic parseJWTT(string token)
        //{
        //    var handler = new JwtSecurityTokenHandler();
        //    var jsonToken = handler.ReadToken(token);
        //    var tokenS = handler.ReadToken(token) as JwtSecurityToken;
        //    return tokenS.Claims.First(claim => claim.Type == "sub").Value;
        //}
    }

}
