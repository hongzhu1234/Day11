using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
namespace Day11.Controllers
{
    public class MenusController : Controller
    {
        MenusBll mb = new MenusBll();
        // GET: Menus
        public ActionResult MenusManage()
        {
            return View();
        }

        public ActionResult Show()
        {
            List<Menus> ls = mb.GetList();
            return Json(new {data= ls,code=0,msg="" } , JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Paging(int pindex,int psize, string name = "") 
        {
            int allcount;
            List<Menus> ls = mb.Paging(name, pindex, psize,out allcount);
            return Json(new { data = ls, code = 0, count = allcount }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            Session["id"] = id;
            return View();
        }
        [HttpPost]
        public int Del(int id)
        {
           
            return mb.Del(id);
        }
        public ActionResult BackFill()
        {
            int MenuId = Convert.ToInt32( Session["Id"]);
            List<Menus> ls = mb.GetList();
            Menus ms = ls.FirstOrDefault(m => m.Id == MenuId);
            return Json(ms, JsonRequestBehavior.AllowGet);
        }
        public int Upt(Menus obj)
        {
            
            return mb.Upt(obj);
        }
        public int Add(Menus obj)
        {
            return mb.Add(obj);
        }
        
        

    }
}