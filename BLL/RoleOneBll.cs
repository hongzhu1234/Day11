using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public class RoleOneBll
    {
        RoleOneDal rd = new RoleOneDal();
        public List<RoleOne> GetList()
        {
            return rd.GetList();
        }

        public int SubmitRoleTwo(int roleId, string menusIds)
        {
            return rd.SubmitRoleTwo(roleId, menusIds);
        }

        public string GetMenusIds(int roleId)
        {
            return rd.GetMenusIds(roleId);
        }
    }
}
