using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public class LoginLogBll
    {
        LoginLogDal ld = new LoginLogDal();
        public int InsertLoginLog(string userno,DateTime dt)
        {
            return ld.InsertLoginLog(userno,dt);
        }

        public List<View_LoginLog> GetLoginLog()
        {
            return ld.GetLoginLog();
        }
    }
}
