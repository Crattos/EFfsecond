using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFSecond.Models;
using System.Data.Entity.SqlServer;

namespace WebApplication1.Controllers
{
    public class MIASTAController : Controller
    {
        private ExtraLeagueEntities1 db = new ExtraLeagueEntities1();

        // GET: MIASTA
        public ViewResult Index(string sortOrder, string searchingString)
        {
            ViewData["NAZWAMIASTASortParm"] = sortOrder == "NAZWA_MIASTA" ? "nazwa_miasta_desc" : "NAZWA_MIASTA";
            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";

            var miasta = from s in db.MIASTA
                         select s;
            if (!String.IsNullOrEmpty(searchingString))
            {
                miasta = miasta.Where(s => s.NAZWA_MIASTA.Contains(searchingString) || SqlFunctions.StringConvert((decimal)s.ID_MIASTA).Contains(searchingString));
            }

            switch (sortOrder)
            {

                case "nazwa_miasta_desc":
                    miasta = miasta.OrderByDescending(s => s.NAZWA_MIASTA);
                    break;
                case "NAZWA_MIASTA":
                    miasta = miasta.OrderBy(s => s.NAZWA_MIASTA);
                    break;

                case "id_desc":
                    miasta = miasta.OrderByDescending(s => s.ID_MIASTA);
                    break;

                default:
                    miasta = miasta.OrderBy(s => s.ID_MIASTA);
                    break;
            }
            return View(miasta.ToList());
        }

        // GET: MIASTA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MIASTA mIASTA = db.MIASTA.Find(id);
            if (mIASTA == null)
            {
                return HttpNotFound();
            }
            return View(mIASTA);
        }

        // GET: MIASTA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MIASTA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MIASTA,NAZWA_MIASTA")] MIASTA mIASTA)
        {
            if (ModelState.IsValid)
            {
                db.MIASTA.Add(mIASTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mIASTA);
        }

        // GET: MIASTA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MIASTA mIASTA = db.MIASTA.Find(id);
            if (mIASTA == null)
            {
                return HttpNotFound();
            }
            return View(mIASTA);
        }

        // POST: MIASTA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MIASTA,NAZWA_MIASTA")] MIASTA mIASTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mIASTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mIASTA);
        }

        // GET: MIASTA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MIASTA mIASTA = db.MIASTA.Find(id);
            if (mIASTA == null)
            {
                return HttpNotFound();
            }
            return View(mIASTA);
        }

        // POST: MIASTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MIASTA mIASTA = db.MIASTA.Find(id);
            db.MIASTA.Remove(mIASTA);
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
