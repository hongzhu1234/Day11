using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
namespace Day11.Controllers
{
    public class LoginLogController : Controller
    {
        // GET: LoginLog
        LoginLogBll lb = new LoginLogBll();
        public ActionResult LoginLog()
        {
            return View();
        }

        public ActionResult GetLog()
        {
            List<View_LoginLog> ls = lb.GetLoginLog();
            var query = from s in ls
                        select new { UserNo = s.UserNo, LogTime = s.LogTime.ToString("yyyy-MM-dd HH:mm:ss"), UserName = s.UserName };
            return Json(new {data= query,code=0 }, JsonRequestBehavior.AllowGet);
        }
    }
}