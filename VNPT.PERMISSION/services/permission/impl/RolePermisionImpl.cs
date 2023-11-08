using ClassLibrary.connectdb;
using ClassLibrary.dbcontext.connect;
using ClassLibrary.model.permission;
using ClassLibrary.responsitory;
using Dapper;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using WebApi.data;

namespace VNPT.PERMISSION.services.permission.impl
{
    public class RolePermisionImpl: Responsetory<RolePermissions>, IRolePermission
    {
        private IConfiguration m_configuration;
        
        public RolePermisionImpl(DataContext context, IConfiguration configuration) : base(context)
        {
            m_configuration = configuration;
        }
        //public IDbConnection GetConnection()
        //{
        //    var connectionString = m_configuration.GetSection("connectionstrings").GetSection("defaultconnectionSQLServer").Value;
        //    var conn = new SqlConnection(connectionString);
        //    return conn;
        //}
        public IDbConnection GetConnection()
        {
            var conn = new SqlConnection(ConnectionStringImpl.defaultconnectionSQLServer);
            return conn;
        }

        public dynamic getRolePermissionNotIn(int role_id)
        {
            List<CategoryMenus> result = new List<CategoryMenus>();

            // Sử dụng phương thức GetConnection() để lấy kết nối
            using (IDbConnection conn = GetConnection())
            {
                conn.Open();

                // Sử dụng Dapper để thực hiện truy vấn
                var parameters = new DynamicParameters();
                parameters.Add("@role_id", role_id, DbType.Int32, ParameterDirection.Input);
                //parameters.Add("@o_data", dbType: DbType.Int32, direction: ParameterDirection.Output);

                result = conn.Query<CategoryMenus>("danhSachNhomQuyenChuaGan", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }
        public dynamic getDanhSachMenuDaGan(int role_id)
        {
            List<CategoryMenus> result = new List<CategoryMenus>();

            // Sử dụng phương thức GetConnection() để lấy kết nối
            using (IDbConnection conn = GetConnection())
            {
                conn.Open();

                // Sử dụng Dapper để thực hiện truy vấn
                var parameters = new DynamicParameters();
                parameters.Add("@role_id", role_id, DbType.Int32, ParameterDirection.Input);
                //parameters.Add("@o_data", dbType: DbType.Int32, direction: ParameterDirection.Output);
                result = conn.Query<CategoryMenus>("danhSachNhomQuyenDaGan", parameters, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
            }

            return result;
        }

        public dynamic insertGroupPermission(RolePermissions rolePermissions)
        {
            var connStr = m_configuration.GetSection("connectionstrings").GetSection("defaultconnectionSQLServer").Value;// m_configuration.GetConnectionString("DefaultConnection");
            var dt = new DataTable();
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"insertRolePermission", conn))
                {
                    cmd.Parameters.AddWithValue("@p_role_id", rolePermissions.role_id);
                    cmd.Parameters.AddWithValue("@p_category_id", rolePermissions.category_id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rdr = cmd.ExecuteReader())
                    {
                        dt.Load(rdr);
                    }
                    cmd.Parameters.Clear();
                    
                    return dt;
                }
                conn.Close();
            }
        }
        public dynamic removeRolePermission(RolePermissions rolePermissions)
        {
            List<CategoryMenus> result = new List<CategoryMenus>();

            // Sử dụng phương thức GetConnection() để lấy kết nối
            using (IDbConnection conn = GetConnection())
            {
                conn.Open();

                // Sử dụng Dapper để thực hiện truy vấn
                var parameters = new DynamicParameters();
                parameters.Add("@p_role_id", rolePermissions.role_id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@p_category_id", rolePermissions.category_id, DbType.Int32, ParameterDirection.Input);
                //parameters.Add("@o_data", dbType: DbType.Int32, direction: ParameterDirection.Output);
                result = conn.Query<CategoryMenus>("deleteRolePermission", parameters, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
            }
            return result;
        }
    }
}
