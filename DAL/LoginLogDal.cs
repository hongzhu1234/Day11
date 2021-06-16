using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class LoginLogDal
    {
        private string strconn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public int InsertLoginLog(string userno,DateTime dt)
        {
            using(IDbConnection db=new SqlConnection(strconn))
            {
                string sql = $"insert into LoginLog(UserNo,LogTime) values('{userno}','{dt}')";
                return db.Execute(sql);
            }
        }

        public List<View_LoginLog> GetLoginLog()
        {
            using (IDbConnection db=new SqlConnection(strconn))
            {
                string sql = $"select a.*,b.UserName from LoginLog a left join UserInfo b on a.UserNo=b.UserID";
                return db.Query<View_LoginLog>(sql).ToList();
            }
        }
    }
}
