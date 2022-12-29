using ClassLibrary.connectdb;
using ClassLibrary.model;
using ClassLibrary.responsitory;
using System.Drawing;

namespace VNPT.AUTH.services.roles.impl
{
    public class RolerImpl : Responsetory<Roles>, IRoler
    {
       
        public RolerImpl(DataContext context) : base(context)
        {
        }
        public Roles getRoles(Roles role)
        {
            return m_context.Roles.Where(m => m.role_name == role.role_name).FirstOrDefault();
        }
        //checked role name if exist then don't add
        public Boolean checkRole(Roles role)
        {
            Roles roles = getRoles(role);
            if (roles == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
