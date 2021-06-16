using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public class RoleStaffBll
    {
        RoleStaffDal rd = new RoleStaffDal();
        public List<View_UserInfo> GetRoleStaffList(int roleId)
        {
            return rd.GetRoleStaffList(roleId);
        }

        public int SubmitRoleStaff(int roleId, string stuffIds)
        {
            return rd.SubmitRoleStaff(roleId, stuffIds);

        }
    }
}
