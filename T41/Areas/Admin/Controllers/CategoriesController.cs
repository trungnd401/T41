using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using T41.Areas.Admin.Model.BusinessModel;
using T41.Areas.Admin.Model.DataModel;
using Excel = Microsoft.Office.Interop.Excel;
namespace T41.Areas.Admin.Controllers
{
    [AuthorizeT41]
    public class CategoriesController : Controller
    {
        private DTPowerDBContext db = new DTPowerDBContext();

        // GET: Admin/Categories
        public ActionResult Index()
        {
            var category = db.Category.Include(c => c.Administrator);
            return View(category.ToList());
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "UserName");
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,OrderNo,Status,UserId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Category.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "UserName", category.UserId);
            return View(category);
        }
        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "UserName", category.UserId);
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,OrderNo,Status,UserId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "UserName", category.UserId);
            return View(category);
        }
        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Category.Find(id);
            db.Category.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ExportExcel()
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet worksheet = workbook.ActiveSheet;
           // Category category = new Category();
            var category = db.Category.Include(c => c.Administrator).ToList();
            worksheet.Cells[1, 1] = "CategoryName";
            worksheet.Cells[1, 2] = "OrderNo";
            worksheet.Cells[1, 3] = "Status";
            worksheet.Cells[1, 4] = "UserId";

            int row = 2;

            foreach (Category c in category)
            {
                worksheet.Cells[row, 1] = c.CategoryName;
                worksheet.Cells[row, 2] = c.OrderNo;
                worksheet.Cells[row, 3] = c.Status;
                worksheet.Cells[row, 4] = c.UserId;
                row ++;
            }
            workbook.SaveAs("D:\\Category.xls");
            workbook.Close();
            Marshal.ReleaseComObject(workbook);
            application.Quit();
            Marshal.FinalReleaseComObject(application);
            ViewBag.Success = "Export thành công.";
            return View();
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
