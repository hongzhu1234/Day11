using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
    public class DeptBll
    {
        DeptDal dd = new DeptDal();
        public List<Dept> GetDept()
        {
            return dd.GetDept();
        }

        public List<Dept> Paging(int psize, int pindex, string deptname, out int allcount)
        {
            return dd.Paging(psize, pindex, deptname, out allcount);
        }
        public int DelDept(int id)
        {
            return dd.DelDept(id);
        }
    }
}
