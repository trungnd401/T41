using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace T41.Areas.Admin.Model.BusinessModel
{
    public class AuthorizeT41 :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(HttpContext.Current.Session["userid"] == null)
            { filterContext.Result = new RedirectResult("/Admin/Home/Login"); return; }

            int userId = int.Parse(HttpContext.Current.Session["userid"].ToString());
            string actionName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "Controller-" + filterContext.ActionDescriptor.ActionName;
            DTPowerDBContext db = new DTPowerDBContext();
            var admin = db.Administrator.Where(a => a.UserId == userId && a.IsAdmin.Value != 0).FirstOrDefault();
            if (admin != null)
                return;
            var listpermission = from p in db.Permission
                                 join g in db.GrantPermission on p.PermissionId equals g.PermissionId
                                 where g.UserId == userId
                                 select p.PermissionName;
            if(!listpermission.Contains(actionName))
            {
                filterContext.Result = new RedirectResult("/Admin/Home/NotificationAuthorize");
                return;
            }
        }

    }
}