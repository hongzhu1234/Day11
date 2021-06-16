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
    public class MenusDal
    {
        private string strconn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public int Add(Menus menus)
        {
            using (IDbConnection db = new SqlConnection(strconn))
            {
                string str = "Insert into Menus(PId,Name,ResourceUrl,Remark,IsEnable) values(@PId,@Name,@ResourceUrl,@Remark,@IsEnable)";
                return db.Execute(str, menus);
            }
        }

        public int Del(int id)
        {
            using (IDbConnection db = new SqlConnection(strconn))
            {
                string str = $"delete from Menus where Id={id}";
                return db.Execute(str);
            }
        }

        public int Upt(Menus menus)
        {
            using (IDbConnection db = new SqlConnection(strconn))
            {
                string str = "update Menus set PId=@PId,Name=@Name,Remark=@Remark,ResourceUrl=@ResourceUrl,IsEnable=@IsEnable where Id=@Id";
                return db.Execute(str, menus);
            }
        }

        public List<Menus> GetList()
        {
            using (IDbConnection db = new SqlConnection(strconn))
            {
                string str = "select * from Menus";
                return db.Query<Menus>(str).ToList();
            }
        }
        public List<Menus> Paging(string name, int pindex, int psize,out int allcount)
        {
            using (IDbConnection db=new SqlConnection(strconn))
            {
                allcount = db.Query<int>($"select count(*) from Menus where Name like '%{name}%'").First();
                string str = $"select * from Menus where Name like '%{name}%' order by Id " +
                    $"OFFSET({(pindex-1)*psize}) ROW FETCH NEXT {psize} ROWS ONLY";
                return db.Query<Menus>(str).ToList();
            }
        }

        public List<Menus> GetMenusByNo(string userID)
        {
            using (IDbConnection db=new SqlConnection(strconn))
            {
                string sql = $@"select * from Menus where Id in
                            (
                                 select MenusId from RoleTwo where RoleId in
                                 (
                                     select RoleId from RoleStaff where UserId in
                                     (
                                            select Id from UserInfo where UserID='{userID}'
                                     )
                                 )
                            )";
                return db.Query<Menus>(sql).ToList();
            }
           
            
        }
    }
}
