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
    public class PermissionsController : Controller
    {
        private DTPowerDBContext db = new DTPowerDBContext();

        // GET: Admin/Permissions
        public ActionResult Index(string id)
        {
            var permission = db.Permission.Where(x => x.BusinessId == id);
            return View(permission.ToList());


        }
        // GET: Admin/Permissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permission.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // GET: Admin/Permissions/Create
        public ActionResult Create()
        {
            ViewBag.BusinessId = new SelectList(db.Business, "BusinessId", "BusinessName");
            return View();
        }

        // POST: Admin/Permissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PermissionId,PermissionName,Description,BusinessId")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                db.Permission.Add(permission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessId = new SelectList(db.Business, "BusinessId", "BusinessName", permission.BusinessId);
            return View(permission);
        }

        // GET: Admin/Permissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permission.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessId = new SelectList(db.Business, "BusinessId", "BusinessName", permission.BusinessId);
            return View(permission);
        }

        // POST: Admin/Permissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PermissionId,PermissionName,Description,BusinessId")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id=permission.BusinessId});
            }
            ViewBag.BusinessId = new SelectList(db.Business, "BusinessId", "BusinessName", permission.BusinessId);
            return View(permission);
        }

        // GET: Admin/Permissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permission.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // POST: Admin/Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Permission permission = db.Permission.Find(id);
            db.Permission.Remove(permission);
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
