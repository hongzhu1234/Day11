using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DAL
{
    public class DeptDal
    {
        private string strconn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public List<Dept> GetDept()
        {
            using (IDbConnection db= new SqlConnection(strconn))
            {
                string sql = $"select * from Dept";
                return db.Query<Dept>(sql).ToList();
            }
        }

        public List<Dept> Paging(int psize,int pindex,string deptname,out int allcount)
        {
            using (IDbConnection db = new SqlConnection(strconn))
            {
                allcount = db.Query<int>($"select count(*) from Dept where DeptName like '%{deptname}%'").First();
                string sql = $@"select * from Dept where DeptName like '%{deptname}'
                order by Id offset({(pindex - 1) * psize}) row fetch next {psize} rows only";
                return db.Query<Dept>(sql).ToList();
            }
        }

        public int DelDept(int id)
        {
            using (IDbConnection db=new SqlConnection(strconn))
            {
                string sql = $"delete from Dept where Id ={id}";
                return db.Execute(sql);
            }
        }
    }
}
