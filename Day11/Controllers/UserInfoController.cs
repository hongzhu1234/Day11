using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
namespace Day11.Controllers
{
    public class UserInfoController : Controller
    {
        UserInfoBll ub = new UserInfoBll();
        DeptBll db = new DeptBll();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserInfoShow(int pindex, int psize, string name)
        {
            int allcount;
            List<View_UserInfo> ls = ub.GetUserInfo(pindex,psize,out allcount,name);
            return Json(new { data=ls,code=0,count=allcount}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            List<UserInfo> ls = ub.GetList();
            UserInfo us = ls.FirstOrDefault(m => m.Id == id);
            List<Dept> dl = db.GetDept();
            Session["id"] = id;
            ViewBag.dept = new SelectList(dl, "Id", "DeptName");
            return View(us);
        }

        public ActionResult BackFill()
        {
            int Id = Convert.ToInt32(Session["id"]);

            List<UserInfo> ls = ub.GetList();
            UserInfo us = ls.FirstOrDefault(m => m.Id == Id);
            return Json(us, JsonRequestBehavior.AllowGet);
        }


    }
}