using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
namespace Day11.Controllers
{
    public class DeptController : Controller
    {
        DeptBll db = new DeptBll();
        // GET: Dept
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show(int psize,int pindex,string deptname)
        {
            int allcount;
            List<Dept> ls = db.Paging(psize, pindex,deptname, out allcount);
            return Json(new { data = ls, code = 0, count = allcount }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Edit(int id)
        {
            Session["id"] = id;
            return View();
        }

        public ActionResult BackFill()
        {
            int id = Convert.ToInt32(Session["id"]);
            List<Dept> ls = db.GetDept();
            Dept dp = ls.FirstOrDefault(m => m.Id == id);
            return Json(dp, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public int DelDept(int id)
        {
            return db.DelDept(id);
        }
    }
}