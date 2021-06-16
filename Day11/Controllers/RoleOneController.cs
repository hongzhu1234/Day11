using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using Day11.Filter;
namespace Day11.Controllers
{
    [MyFilter]
    public class RoleOneController : Controller
    {
        // GET: RoleOne
        RoleOneBll rb = new RoleOneBll();
        MenusBll mb = new MenusBll();
        public ActionResult RoleOne()
        {
            return View();
        }

        //public ActionResult GetRole()
        //{
        //    List<RoleOne> ls = rb.GetList();

        //    List<Dictionary<string, object>> jsonList = new List<Dictionary<string, object>>();

        //    Dictionary<string, object> json1 = new Dictionary<string, object>();
        //    json1.Add("id", 0);
        //    json1.Add("title", "所有角色");
        //    json1.Add("spread", true);

        //    List<Dictionary<string, object>> jsonListSub = new List<Dictionary<string, object>>();

        //    foreach (var item in ls)
        //    {
        //        Dictionary<string, object> json = new Dictionary<string, object>();
        //        json.Add("id", item.Id);
        //        json.Add("title", item.RoleName);
        //        json.Add("children", null);
        //        jsonListSub.Add(json);
        //    }
        //    json1.Add("children", jsonListSub);

        //    jsonList.Add(json1);
        //    return Json(jsonList, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult GetMenus()
        //{
        //    List<Menus> ls = mb.GetList();
        //   List<Menus> ml = ls.Where(m => m.PId == 0).ToList();
        //    List<Dictionary<string, object>> jsonList = new List<Dictionary<string, object>>();

        //    foreach (var item in ml)
        //    {
        //        Dictionary<string, object> json = new Dictionary<string, object>();
        //        json.Add("id", item.Id);
        //        json.Add("title", item.Name);
        //        json.Add("spread", true);
        //        GetMenusTwo(ls, json, item.Id);
        //        jsonList.Add(json);
        //    }
        //    return Json(jsonList, JsonRequestBehavior.AllowGet);
            
        //}

        //public void GetMenusTwo(List<Menus> ls,Dictionary<string,object> json,int menuId)
        //{
        //    List<Menus> ml = ls.Where(m => m.PId == menuId).ToList();
        //    if (ml.Count == 0)
        //    {
        //        json.Add("children", null);
        //        return;
        //    }
        //    List<Dictionary<string, object>> jsonList = new List<Dictionary<string, object>>();
        //    foreach (var item in ml)
        //    {
        //        Dictionary<string, object> json1 = new Dictionary<string, object>();
        //        json1.Add("id", item.Id);
        //        json1.Add("title", item.Name);
        //        GetMenusTwo(ls, json1, item.Id);
        //        jsonList.Add(json1);
        //    }
        //    json.Add("children", jsonList);
        //}
            //GetRole
            //GetMenusTwo
            //GetMenus

        public ActionResult GetRole()
        {
            List<RoleOne> ls = rb.GetList();
            List<Dictionary<string, object>> jsonList = new List<Dictionary<string, object>>();
            List<Dictionary<string, object>> jsonListsub = new List<Dictionary<string, object>>();
            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("id",0);
            json.Add("title","所有角色");
            json.Add("spread", true);
            foreach (var item in ls)
            {
                Dictionary<string, object> json1 = new Dictionary<string, object>();
                json1.Add("id", item.Id);
                json1.Add("title", item.RoleName);
                json1.Add("children", null);
                jsonListsub.Add(json1);
            }
            json.Add("children",jsonListsub);
            jsonList.Add(json);
            return Json(jsonList,JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMenus()
        {
            List<Menus> ls = mb.GetList();
            List<Menus> ml = ls.Where(m => m.PId == 0).ToList();
            List<Dictionary<string, object>> jsonList = new List<Dictionary<string, object>>();
            
            foreach (var item in ml)
            {
                Dictionary<string, object> json = new Dictionary<string, object>();
                json.Add("id", item.Id);
                json.Add("title", item.Name);
                json.Add("spread", true);
                GetMenusTwo(ls, json, item.Id);
                jsonList.Add(json);
            }
            return Json(jsonList, JsonRequestBehavior.AllowGet);
        }

        public void GetMenusTwo(List<Menus> ls,Dictionary<string,object> json,int menusId)
        {
            List<Menus> ml = ls.Where(m => m.PId == menusId).ToList();
            List<Dictionary<string, object>> jsonList = new List<Dictionary<string, object>>();
            if (ml.Count == 0)
            {
                json.Add("children", null);
                return;
            }
            foreach (var item in ml)
            {
                Dictionary<string, object> json1 = new Dictionary<string, object>();
                json1.Add("id", item.Id);
                json1.Add("title", item.Name);
                  GetMenusTwo(ls, json1, item.Id);
                jsonList.Add(json1);
            }
            json.Add("children", jsonList);
        }

        public int AddRoleTwo(int roleId,string menuIds)
        {
            return rb.SubmitRoleTwo(roleId, menuIds);
        }

        public string GetMenusIds(int roleId)
        {
            return rb.GetMenusIds(roleId);
        }
    }
}