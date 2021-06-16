using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using Day11.Filter;

namespace Day11.Controllers
{
   
    public class HomeController : Controller
    {
        UserInfoBll ub = new UserInfoBll();
        LoginLogBll lb = new LoginLogBll();
        MenusBll mb = new MenusBll();
        [MyFilter]
        public ActionResult HomePage()
        {
            ViewBag.menus = GetMenusByUserNo();
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ChkValidate(string userNo,string pwd)
        {
            Session["nm"] = userNo;
            int result = ub.ChkValidate(userNo, pwd);
            if (result > 0)
            {
                Session["userNo"] = userNo;
                DateTime dt = DateTime.Now;
                lb.InsertLoginLog(userNo,dt);
                return RedirectToAction("HomePage");
            }
            else
            {
                return Content("<script>alert('账号或密码不正确');window.location.href='/Home/Login'</script>");
            }
        }
        public void LogOut()
        {
            this.Session.Abandon();
            foreach (string cookieName in Request.Cookies.AllKeys)
            {
                HttpCookie cookie = new HttpCookie(cookieName);
                cookie.Expires = DateTime.Today.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("/Home/Login", true);
        }
        private string GetMenusByUserNo()
        {
            string userNo = Session["nm"] + "";
            List<Menus> ls = mb.GetMenusByNo(userNo);
            List<Menus> query = (from s in ls
                                 where s.PId.Equals(0)
                                 select s).ToList();
            var menu = "";
            foreach (var s in query)
            {
                menu += "<li class=\"layui-nav-item layui-nav-temed\">";
                menu += $"<a class=\"\" href=\"javascript:; \">{s.Name}</a>";
                menu += "<dl class=\"layui-nav-child\">";
                List<Menus> querySub = (from t in ls
                                        where t.PId.Equals(s.Id)
                                        select t).ToList();
                foreach (var m in querySub)
                {
                    menu += $"<dd><a href = \"{m.ResourceUrl}\" target=\"ifr\">{m.Name}</a></dd>";
                }
                menu += "</dl>";
                menu += "</li>";
     
            }
            return menu;
            //< li class="layui-nav-item layui-nav-itemed">
            //            <a class="" href="javascript:;">系统管理</a>
            //            <dl class="layui-nav-child">
            //                <dd><a href = "/Menus/MenusManage" target="ifr">菜单管理</a></dd>
            //                <dd><a href = "javascript:;" > 部门管理 </ a ></ dd >
            //                < dd >< a href="/UserInfo/Index" target="ifr">用户管理</a></dd>
            //                <dd><a href = "/RoleOne/RoleOne" target="ifr">角色管理</a></dd>
            //                <dd><a href = "/RoleStaff/Index" target="ifr">权限设置</a></dd>
            //                <dd><a href = "/LoginLog/LoginLog" target="ifr">日志管理</a></dd>
            //            </dl>
            //        </li>
            //        <li class="layui-nav-item"><a href = "" > 系统公告 </ a ></ li >
            //        < li class="layui-nav-item"><a href = "" > 兄弟链接 </ a ></ li >
        }
    }
}