using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFSecond.Models;

namespace EFSecond.Controllers
{
    public class KARYController : Controller
    {
        private ExtraLeagueEntities1 db = new ExtraLeagueEntities1();

        // GET: KARY
        public ActionResult Index()
        {
            return View(db.KARY.ToList());
        }

        // GET: KARY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KARY kARY = db.KARY.Find(id);
            if (kARY == null)
            {
                return HttpNotFound();
            }
            return View(kARY);
        }

        // GET: KARY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KARY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SPOTKANIA,ID_DRUZYNY,ID_PILKARZA,MINUTA_KARY,KARA")] KARY kARY)
        {
            if (ModelState.IsValid)
            {
                db.KARY.Add(kARY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kARY);
        }

        // GET: KARY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KARY kARY = db.KARY.Find(id);
            if (kARY == null)
            {
                return HttpNotFound();
            }
            return View(kARY);
        }

        // POST: KARY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SPOTKANIA,ID_DRUZYNY,ID_PILKARZA,MINUTA_KARY,KARA")] KARY kARY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kARY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kARY);
        }

        // GET: KARY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KARY kARY = db.KARY.Find(id);
            if (kARY == null)
            {
                return HttpNotFound();
            }
            return View(kARY);
        }

        // POST: KARY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KARY kARY = db.KARY.Find(id);
            db.KARY.Remove(kARY);
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
