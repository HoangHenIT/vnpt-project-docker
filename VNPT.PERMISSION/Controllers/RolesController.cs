using ClassLibrary.model;
using ClassLibrary.respond;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using VNPT.AUTH.services.roles;

namespace VNPT.PERMISSION.Controllers
{
    [Route("api/permission/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : Controller
    {
        private readonly IRoler m_roler;
        public RolesController(IRoler _roler)
        {
            m_roler = _roler;
        }

        [HttpGet("getAllRoler")]
        public DataRespond getAllRoler()
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.data = m_roler.getAll();
                data.message = "Get all Roler success";
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
        [HttpPost("insertRoler")]
        public DataRespond insertRoler( Roles role)
        {
            DataRespond data = new DataRespond();
            try
            {
                Roles roles = new Roles();
                roles.role_name = role.role_name;
                roles.active = role.active;
                roles.note = role.note;
                if (m_roler.checkRole(role))
                {
                    m_roler.insert(roles);
                    data.success = true;
                    data.data = m_roler.getById(roles.role_id);
                    data.message = "Get all Roler '" + roles.role_name + "' success";
                }
                else
                {
                    data.success = false;
                    data.message = "Role name '" + roles.role_name + "' already exists!!! ";
                }
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
        [HttpPost("updateRoler")]
        public DataRespond updateRoler([FromBody] Roles role)
        {
            DataRespond data = new DataRespond();
            try
            {
                Roles roles = m_roler.getById(role.role_id);
                if (roles != null)
                {
                    //gán giá trị cập nhật
                    roles.role_id = role.role_id;
                    roles.role_name = role.role_name;
                    roles.active = true;
                    roles.note = role.note;
                    //kiểm tra có trùng hay không? 
                    if (m_roler.checkRole(roles))
                    {
                        m_roler.update(roles);
                        data.success = true;
                        data.data = m_roler.getById(roles.role_id);
                        data.message = "Update Roler '" + roles.role_name + "' success";
                    }
                    else
                    {
                        data.success = false;
                        data.message = "Role name '" + roles.role_name + "' already exists!!! ";
                    }
                }
                else
                {
                    data.success = false;
                    data.message = "Role name '" + role.role_name + "' not found!!! ";
                }
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
        [HttpDelete("deleteRoler")]
        public DataRespond deleteRoler(int role_id)
        {
            DataRespond data = new DataRespond();
            try
            {
                Roles role = m_roler.getById(role_id);
                data.success = true;
                m_roler.delete(role.role_id);
                data.message = "Delete Roler '" + role.role_name + "' success";
                
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
