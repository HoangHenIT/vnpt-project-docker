using ClassLibrary.connectdb;
using ClassLibrary.dbcontext.connect;
using ClassLibrary.model.OcopModel;
using ClassLibrary.responsitory;
using Microsoft.Data.SqlClient;
using System.Data;

namespace VNPT.OCOPSERVICE.services.ocop.impl
{
    public class OCOPSanPhamImpl : OCOPResponsetory<Nhomsps>, IOCOPSanPham
    {
        private IConfiguration m_configuration;

        public OCOPSanPhamImpl(DataContextOCOP context, IConfiguration configuration) : base(context)
        {
            m_configuration = configuration;
        }
        public IDbConnection GetConnection()
        {
            var conn = new SqlConnection(ConnectionStringImpl.defaultconnectionSQLServerOCOP);
            return conn;
        }

        public dynamic getNhomSanPham()
        {
            return m_context.Nhomsps.OrderByDescending(m => m.TEN).ToList();
           
        }
    }
}
