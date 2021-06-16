using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
namespace Day11.Controllers
{
    public class RoleStaffController : Controller
    {
        RoleStaffBll rb = new RoleStaffBll();
        // GET: RoleStaff
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetRoleStaffList(int roleId = 0)
        {
            List<View_UserInfo> ls = rb.GetRoleStaffList(roleId);
            return Json(new { data = ls, code = 0 }, JsonRequestBehavior.AllowGet);
        }
    }
}