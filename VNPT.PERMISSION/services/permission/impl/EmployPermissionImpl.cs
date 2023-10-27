using ClassLibrary.connectdb;
using ClassLibrary.model;
using ClassLibrary.model.permission;
using ClassLibrary.responsitory;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace VNPT.PERMISSION.services.permission.impl
{
    public class EmployPermissionImpl : Responsetory<EmployePermissions>, IEmployPermission
    {
        private IConfiguration m_configuration;

        public EmployPermissionImpl(DataContext context, IConfiguration configuration) : base(context)
        {
            m_configuration = configuration;
        }
        public IDbConnection GetConnection()
        {
            var connectionString = m_configuration.GetSection("connectionstrings").GetSection("defaultconnectionSQLServer").Value;
            var conn = new SqlConnection(connectionString);
            return conn;
        }

        public dynamic getDanhSachNguoiDungChuaGan(int role_id)
        {
            List<Employers> result = new List<Employers>();

            // Sử dụng phương thức GetConnection() để lấy kết nối
            using (IDbConnection conn = GetConnection())
            {
                conn.Open();

                // Sử dụng Dapper để thực hiện truy vấn
                var parameters = new DynamicParameters();
                parameters.Add("@role_id", role_id, DbType.Int32, ParameterDirection.Input);
                //parameters.Add("@o_data", dbType: DbType.Int32, direction: ParameterDirection.Output);

                result = conn.Query<Employers>("danhSachNguoiDungChuaGan", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }
    }
}
