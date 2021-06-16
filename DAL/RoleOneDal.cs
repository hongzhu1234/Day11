using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using Model;
namespace DAL
{
    public class RoleOneDal
    {
        private string strconn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public List<RoleOne> GetList()
        {
            using (IDbConnection db=new SqlConnection(strconn))
            {
                db.Open();
                string str = "select * from RoleOne";
                return db.Query<RoleOne>(str).ToList();
            }
        }

        public int SubmitRoleTwo(int roleId,string menusIds)
        {
            using(IDbConnection db=new SqlConnection(strconn))
            {
                db.Open();
                IDbTransaction tran = db.BeginTransaction();
                try
                {
                    string sql = $"delete RoleTwo where RoleId={roleId}";
                    db.Execute(sql, null, tran);
                    var ss = menusIds.Split(',');
                    foreach (var item in ss)
                    {
                         sql = $"insert into RoleTwo(RoleId,MenusId) values({roleId},{item})";
                        db.Execute(sql, null, tran);
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

        public string GetMenusIds(int roleId)
        {
            using (IDbConnection db=new SqlConnection(strconn))
            {
                string sql = $@"select * from RoleTwo where MenusId in
                    (select id from Menus where id not in(select pid from Menus))
                    and roleid={roleId}";
                List<RoleTwo> query = db.Query<RoleTwo>(sql).ToList();
                StringBuilder sb = new StringBuilder();
                foreach (var s in query)
                {
                    sb.Append(s.MenusId).Append(",");
                }
                return "[" + sb.ToString().Trim(',') + "]";

            }
        } 
    }
}
