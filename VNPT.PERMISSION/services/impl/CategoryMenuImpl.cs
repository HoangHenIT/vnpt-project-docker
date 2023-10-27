using ClassLibrary.connectdb;
using ClassLibrary.dbcontext.connect;
using ClassLibrary.model;
using ClassLibrary.model.permission;
using ClassLibrary.responsitory;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Xml.Linq;

namespace VNPT.PERMISSION.services.impl
{
    public class CategoryMenuImpl : Responsetory<CategoryMenus>, ICategoryMenu
    {
        public CategoryMenuImpl(DataContext context) : base(context)
        {
        }
        public IDbConnection GetConnection()
        {
            var conn = new SqlConnection(ConnectionStringImpl.defaultconnectionSQLServer);
            return conn;
        }
        public CategoryMenus getCategory(CategoryMenus category)
        {
            return m_context.CategoryMenu.Where(m => m.category_name == category.category_name).FirstOrDefault();
        }
        public dynamic getCategoryFath()
        {
            //string[] menucha = { "0", "Menu Cha", "0", "", "", "true", "0", "0" };
            var res = (from category in m_context.CategoryMenu.Where(m => m.category_active == true)
                       select new
                       {
                           category_id = category.category_id,
                           category_name = category.category_name,
                           category_level = category.category_level,
                           category_icon = category.category_icon,
                           category_note = category.category_note,
                           category_active = category.category_active,
                           category_cha_id = category.category_cha_id,
                           position = category.position
                       }).ToList();
            return res;
        }
        public bool checkCategory(CategoryMenus category)
        {
            CategoryMenus categorys = getCategory(category);
            if (categorys != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public dynamic getDanhSachMenuTheoNguoiDung(int employid)
        {
            List<CategoryMenus> result = new List<CategoryMenus>();
            using (IDbConnection conn = GetConnection())
            {
                conn.Open();

                // Sử dụng Dapper để thực hiện truy vấn
                var parameters = new DynamicParameters();
                parameters.Add("@p_employer_id", employid, DbType.Int32, ParameterDirection.Input);
                //parameters.Add("@o_data", dbType: DbType.Int32, direction: ParameterDirection.Output);
                result = conn.Query<CategoryMenus>("layDanhSachMenu", parameters, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
            }
            return result;
        }
    }
}
