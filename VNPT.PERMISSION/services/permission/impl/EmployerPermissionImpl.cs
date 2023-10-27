using ClassLibrary.connectdb;
using ClassLibrary.dbcontext.connect;
using ClassLibrary.model;
using ClassLibrary.model.permission;
using ClassLibrary.responsitory;
using Dapper;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace VNPT.PERMISSION.services.permission.impl
{
    public class EmployerPermissionImpl : Responsetory<EmployePermissions>, IEmployerPermission
    {
        private IConfiguration m_configuration;

        public EmployerPermissionImpl(DataContext context, IConfiguration configuration) : base(context)
        {
            m_configuration = configuration;
        }
        public IDbConnection GetConnection()
        {
            var conn = new SqlConnection(ConnectionStringImpl.defaultconnectionSQLServer);
            return conn;
        }

        public dynamic getEmployPermissionNotIn(int role_id)
        {
            List<EmployersRequest> result = new List<EmployersRequest>();

            // Sử dụng phương thức GetConnection() để lấy kết nối
            using (IDbConnection conn = GetConnection())
            {
                conn.Open();

                // Sử dụng Dapper để thực hiện truy vấn
                var parameters = new DynamicParameters();
                parameters.Add("@role_id", role_id, DbType.Int32, ParameterDirection.Input);
                //parameters.Add("@o_data", dbType: DbType.Int32, direction: ParameterDirection.Output);

                result = conn.Query<EmployersRequest>("danhSachNguoiDungChuaGan", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }

        public dynamic getDanhSachNguoiDungDaGan(int role_id)
        {
            List<EmployersRequest> result = new List<EmployersRequest>();

            // Sử dụng phương thức GetConnection() để lấy kết nối
            using (IDbConnection conn = GetConnection())
            {
                conn.Open();

                // Sử dụng Dapper để thực hiện truy vấn
                var parameters = new DynamicParameters();
                parameters.Add("@role_id", role_id, DbType.Int32, ParameterDirection.Input);
                //parameters.Add("@o_data", dbType: DbType.Int32, direction: ParameterDirection.Output);
                result = conn.Query<EmployersRequest>("danhSachNguoiDungDaGan", parameters, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
            }

            return result;
        }
        public dynamic insertEmployPermission(EmployePermissions employe)
        {
            List<EmployePermissions> result = new List<EmployePermissions>();
             using (IDbConnection conn = GetConnection())
                {
                conn.Open();

                // Sử dụng Dapper để thực hiện truy vấn
                var parameters = new DynamicParameters();
                parameters.Add("@p_role_id", employe.role_id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@p_employer_id", employe.employer_id, DbType.Int32, ParameterDirection.Input);
                //parameters.Add("@o_data", dbType: DbType.Int32, direction: ParameterDirection.Output);
                result = conn.Query<EmployePermissions>("insertEmployPermission", parameters, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
            }
            return result;
        }

        public dynamic deleteEmployPermission(EmployePermissions employe)
        {
            List<EmployePermissions> result = new List<EmployePermissions>();
            using (IDbConnection conn = GetConnection())
            {
                conn.Open();

                // Sử dụng Dapper để thực hiện truy vấn
                var parameters = new DynamicParameters();
                parameters.Add("@p_role_id", employe.role_id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@p_employer_id", employe.employer_id, DbType.Int32, ParameterDirection.Input);
                //parameters.Add("@o_data", dbType: DbType.Int32, direction: ParameterDirection.Output);
                result = conn.Query<EmployePermissions>("deleteEmployPermission", parameters, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
            }
            return result;
        }
    }
}
