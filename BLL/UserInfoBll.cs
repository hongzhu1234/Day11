using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
    public class UserInfoBll
    {
        UserInfoDal ud = new UserInfoDal();

        public List<View_UserInfo> GetUserInfo(int pindex, int psize, out int allcount, string name)
        {
            return ud.GetUserInfo(pindex,  psize, out allcount, name);
        }
        public int Del(int id)
        {
            return ud.Del(id);
        }

        public int Upt(UserInfo userInfo)
        {
            return ud.Upt(userInfo);
        }
        public List<UserInfo> GetList()
        {
            return ud. GetList();
        }



        public int ChkValidate(string userNo, string pwd)
        {
            return ud.ChkValidate(userNo, pwd);
        }
    }
}
