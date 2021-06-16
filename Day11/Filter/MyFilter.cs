using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day11.Filter
{
    public class MyFilter:ActionFilterAttribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filtercontext)
        {
            if (HttpContext.Current.Session["userNo"] == null)
            {
                filtercontext.HttpContext.Response.Redirect("/Home/Login");
            }
        }
    }
}