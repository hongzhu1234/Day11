using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
namespace DAL
{
    public class RoleStaffDal
    {
        private string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public List<View_UserInfo>GetRoleStaffList(int roleId)
        {
            using (IDbConnection db=new SqlConnection(strcon))
            {
                string sql = $"select b.*from RoleStaff a inner join View_UserInfo b on a.UserId=b.Id where a.roleId={roleId}";
                return db.Query<View_UserInfo>(sql).ToList();
            }
        }

        public int SubmitRoleStaff(int roleId,string stuffIds)
        {
            using (IDbConnection db = new SqlConnection(strcon))
            {
                db.Open();
                IDbTransaction tran = db.BeginTransaction();
                try
                {
                    var ss = stuffIds.Split(',');
                    foreach (var stuffId in ss)
                    {
                        string sql = $"insert into RoleStaff(RoleId,UserId) values({roleId},{stuffId})";
                    }
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    return 0;
                }
                return 1;
            }
        }
    }
}
