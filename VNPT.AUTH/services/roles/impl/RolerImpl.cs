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
    }
}
