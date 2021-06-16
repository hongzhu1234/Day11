using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DAL
{
    public class UserInfoDal
    {
        private string strconn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public List<View_UserInfo> GetUserInfo(int pindex,int psize,out int allcount,string name)
        {
            using (IDbConnection db=new SqlConnection(strconn))
            {
                allcount = db.Query<int>($"select count(*) from View_UserInfo where UserName like '%{name}%'").First();
                string sql = $@"select *from View_UserInfo where UserName like '%{name}%' 
                             order by Id OFFSET({(pindex-1)*psize}) ROW FETCH NEXT {psize} ROWS ONLY";
                return db.Query<View_UserInfo>(sql).ToList();
            }
        }

        public List<View_UserInfo> GetUserInfoById()
        {
            using (IDbConnection db = new SqlConnection(strconn))
            {
                string sql = "select * from View_UserInfo";
                return db.Query<View_UserInfo>(sql).ToList();
            }
        }
        public List<UserInfo> GetList()
        {
            using (IDbConnection db = new SqlConnection(strconn))
            {
                string sql = "select * from UserInfo";
                return db.Query<UserInfo>(sql).ToList();
            }
        }

        public int Del(int id)
        {
            using (IDbConnection db=new SqlConnection(strconn))
            {
                string sql = $"delete from UserInfo where Id={id}";
                return db.Execute(sql);
            }
        }

        public int Upt(UserInfo userInfo)
        {
            using (IDbConnection db = new SqlConnection(strconn))
            {
                string sql = $"update UserInfo set UserID=@UserID,UserName=@UserName,Pwd=@Pwd,DeptId=@DeptId,Email=@Email where Id=@Id";
                return db.Execute(sql,userInfo);
            }
        }

        public int ChkValidate(string userNo,string pwd)
        {
            using (IDbConnection db=new SqlConnection(strconn))
            {
                string sql = $"select count(*) from UserInfo where UserId='{userNo}' and Pwd='{pwd}'";
                return db.Query<int>(sql).FirstOrDefault();
            }
        }


    }
}
