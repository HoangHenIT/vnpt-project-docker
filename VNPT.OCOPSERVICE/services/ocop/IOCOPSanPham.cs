using ClassLibrary.model;
using ClassLibrary.model.OcopModel;
using ClassLibrary.responsitory;

namespace VNPT.OCOPSERVICE.services.ocop
{
    public interface IOCOPSanPham : IOCOPResponsetory<Nhomsps>
    {
        public dynamic getNhomSanPham();
    }
}
