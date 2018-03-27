using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using T41.Areas.Admin.Model.BusinessModel;
using T41.Areas.Admin.Model.DataModel;

namespace T41.Areas.Admin.Controllers
{
    [AuthorizeT41]
    public class GrantPermissionsController : Controller
    {
        private DTPowerDBContext db = new DTPowerDBContext();

        // GET: Admin/GrantPermissions
        public ActionResult Index(int id)
        {
            //var grantPermission = db.GrantPermission.Include(g => g.Administrator).Include(g => g.Permission);
            //return View(grantPermission.ToList());

            var listcontrol = db.Business.AsEnumerable();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in listcontrol)
            {
                items.Add(new SelectListItem() { Text = item.BusinessName, Value = item.BusinessId });
            }
            ViewBag.items = items;
            var listgranted = from g in db.GrantPermission
                              join p in db.Permission on g.PermissionId equals p.PermissionId
                              where g.UserId == id
                              select new SelectListItem() { Value = p.PermissionId.ToString(), Text = p.Description };
            ViewBag.listgranted = listgranted;
            Session["usergrant"] = id;
            var usergrant = db.Administrator.Find(id);
            ViewBag.usergrant = usergrant.UserName + "" + usergrant.FullName + ")";
            return View();
        }
        // GET: Admin/getPermissions
        public JsonResult getPermissions(string id, int usertemp)
        {
            // Lất tất của permission của user  và business
            var listgranted =( from g in db.GrantPermission
                              join p in db.Permission on g.PermissionId equals p.PermissionId
                              where g.UserId == usertemp && p.BusinessId == id
                              select new PermissionAction {PermissionId = p.PermissionId, PermissionName = p.PermissionName, Description = p.Description, IsGranted = true }).ToList();
            // Lấy tất cả permission của business hiện tại
            var listpermission = from p in db.Permission                        
                               where  p.BusinessId == id
                               select new PermissionAction { PermissionId = p.PermissionId, PermissionName = p.PermissionName, Description = p.Description, IsGranted = false };
            // Lấy các id của permission đã được gán ở trên cho người dùng
            var listpermissionId = listgranted.Select(p => p.PermissionId);
            // Kiểm tra permissionId nào của bisiness mà chưa  có trong listgrant thi đưa vào (IsGrant = false)
            foreach(var item in listpermission)
            {
                if (!listpermissionId.Contains(item.PermissionId))
                    listgranted.Add(item);
            }
            return Json(listgranted.OrderBy(x=> x.Description), JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/updatePermission
        public string  updatePermission(int id, int usertemp)
        {
            string msg = "";
            var grant = db.GrantPermission.Find(id, usertemp);
            if(grant==null)
            {
                GrantPermission g = new GrantPermission() {PermissionId = id, UserId = usertemp, Description = "" };
                db.GrantPermission.Add(g);
                msg = "<div class='alert alert-success'>Cấp quyền thành công</div>";
            }
            else
            {
                db.GrantPermission.Remove(grant);
                msg = "<div class='alert alert-danger'>Hủy quyền thành công</div>";
            }
            db.SaveChanges();
            return msg;
        }

        // GET: Admin/GrantPermissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantPermission grantPermission = db.GrantPermission.Find(id);
            if (grantPermission == null)
            {
                return HttpNotFound();
            }
            return View(grantPermission);
        }

        // GET: Admin/GrantPermissions/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "UserName");
            ViewBag.PermissionId = new SelectList(db.Permission, "PermissionId", "PermissionName");
            return View();
        }

        // POST: Admin/GrantPermissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PermissionId,UserId,Description")] GrantPermission grantPermission)
        {
            if (ModelState.IsValid)
            {
                db.GrantPermission.Add(grantPermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "UserName", grantPermission.UserId);
            ViewBag.PermissionId = new SelectList(db.Permission, "PermissionId", "PermissionName", grantPermission.PermissionId);
            return View(grantPermission);
        }

        // GET: Admin/GrantPermissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantPermission grantPermission = db.GrantPermission.Find(id);
            if (grantPermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "UserName", grantPermission.UserId);
            ViewBag.PermissionId = new SelectList(db.Permission, "PermissionId", "PermissionName", grantPermission.PermissionId);
            return View(grantPermission);
        }

        // POST: Admin/GrantPermissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PermissionId,UserId,Description")] GrantPermission grantPermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grantPermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "UserName", grantPermission.UserId);
            ViewBag.PermissionId = new SelectList(db.Permission, "PermissionId", "PermissionName", grantPermission.PermissionId);
            return View(grantPermission);
        }

        // GET: Admin/GrantPermissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantPermission grantPermission = db.GrantPermission.Find(id);
            if (grantPermission == null)
            {
                return HttpNotFound();
            }
            return View(grantPermission);
        }

        // POST: Admin/GrantPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrantPermission grantPermission = db.GrantPermission.Find(id);
            db.GrantPermission.Remove(grantPermission);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
