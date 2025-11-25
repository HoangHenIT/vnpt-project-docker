using ClassLibrary.connectdb;
using ClassLibrary.dbcontext.connect;
using ClassLibrary.model.OcopModel;
using ClassLibrary.model.permission;
using ClassLibrary.model.productModel;
using ClassLibrary.responsitory;
using Dapper;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Any;
using System.Data;
using System.Drawing;
using System.Globalization;

namespace VNPT.OCOPSERVICE.services.ocop.impl
{
    public class ProductImpl : ProductResponsetory<Products>, IProduct
    {
        private IConfiguration m_configuration;

        public ProductImpl(DataContextProduct context, IConfiguration configuration) : base(context)
        {
            m_configuration = configuration;
        }
        public IDbConnection GetConnection()
        {
            var conn = new SqlConnection(ConnectionStringImpl.defaultconnectionSQLServerProduct);
            return conn;
        }

        public dynamic getListProduct()
        {
            return m_context.Product.OrderByDescending(m => m.product_creatdate).ToList();
        }

        public dynamic insertProduct(ProductsRequest productsRequest)
        {
            throw new NotImplementedException();
        }

        public dynamic updateProduct(ProductsRequest productsRequest)
        {
            throw new NotImplementedException();
        }


        //public dynamic getNhomSanPham()
        //{
        //    return m_context.Nhomsps.OrderByDescending(m => m.CREATED_DATE).ToList();

        //}
        ////Cách dùng PRO
        //public dynamic insertDanhSachNhomSanPham(NhomspsRequest nhomspsRequest)
        //{
        //    List<NhomspsRequest> result = new List<NhomspsRequest>();
        //    using (IDbConnection conn = GetConnection())
        //    {
        //        //Open connect
        //        conn.Open();
        //        //Parameter sent Pro
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@p_ten", nhomspsRequest.TEN, DbType.String, ParameterDirection.Input);
        //        parameters.Add("@p_mo_ta", nhomspsRequest.MO_TA, DbType.String, ParameterDirection.Input);
        //        parameters.Add("@p_trang_thai", nhomspsRequest.TRANG_THAI, DbType.String, ParameterDirection.Input);
        //        parameters.Add("@p_is_delete", nhomspsRequest.IS_DELETE, DbType.Int32, ParameterDirection.Input);
        //        parameters.Add("@p_create_user", nhomspsRequest.CREATE_USER, DbType.Int32, ParameterDirection.Input);
        //        parameters.Add("@p_created_date", DateTime.Now.ToString("dd/MM/yyyy"), DbType.DateTime, ParameterDirection.Input);
        //        parameters.Add("@p_update_date", nhomspsRequest.UPDATED_DATE, DbType.DateTime, ParameterDirection.Input);
        //        parameters.Add("@p_update_user", nhomspsRequest.UPDATE_USER, DbType.Int32, ParameterDirection.Input);
        //        //Run query 
        //        result = conn.Query<NhomspsRequest>("PRO_insertNhomSP", parameters, commandType: CommandType.StoredProcedure).ToList();
        //        //Close connect
        //        conn.Close();
        //    }
        //    return result;
        //}
        ////Cách dùng Res
        //public dynamic updateDanhSachNhomSanPham(NhomspsRequest nhomspsRequest)
        //{
        //    var empl = getById(nhomspsRequest.ID);
        //    if(empl != null)
        //    {
        //        empl.ID= nhomspsRequest.ID;
        //        empl.TEN = nhomspsRequest.TEN;
        //        empl.MO_TA = nhomspsRequest.MO_TA;
        //        empl.TRANG_THAI = nhomspsRequest.TRANG_THAI;
        //        empl.CREATE_USER = nhomspsRequest.CREATE_USER;
        //        empl.IS_DELETE = empl.IS_DELETE;
        //        var date_f = nhomspsRequest.CREATED_DATE;
        //        empl.CREATED_DATE = DateTime.ParseExact(date_f, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //        empl.UPDATE_USER = nhomspsRequest.UPDATE_USER;
        //        empl.UPDATED_DATE = DateTime.Now;
        //        update(empl);
        //    }
        //    else
        //    {
        //        return "Dữ liệu chưa có!";
        //    }
        //    return empl;
        //}
    }
}
