using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFSecond.Models;

namespace WebApplication1.Controllers
{
    public class WYNIKController : Controller
    {
        private ExtraLeagueEntities1 db = new ExtraLeagueEntities1();

        // GET: WYNIK
        public ActionResult Index()
        {
            return View(db.WYNIK.ToList());
        }

        // GET: WYNIK/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WYNIK wYNIK = db.WYNIK.Find(id);
            if (wYNIK == null)
            {
                return HttpNotFound();
            }
            return View(wYNIK);
        }

        // GET: WYNIK/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WYNIK/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SPOTKANIA,ID_DRUZYNY,ID_PILKARZA,MINUTA_WYNIKU")] WYNIK wYNIK)
        {
            if (ModelState.IsValid)
            {
                db.WYNIK.Add(wYNIK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wYNIK);
        }

        // GET: WYNIK/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WYNIK wYNIK = db.WYNIK.Find(id);
            if (wYNIK == null)
            {
                return HttpNotFound();
            }
            return View(wYNIK);
        }

        // POST: WYNIK/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SPOTKANIA,ID_DRUZYNY,ID_PILKARZA,MINUTA_WYNIKU")] WYNIK wYNIK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wYNIK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wYNIK);
        }

        // GET: WYNIK/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WYNIK wYNIK = db.WYNIK.Find(id);
            if (wYNIK == null)
            {
                return HttpNotFound();
            }
            return View(wYNIK);
        }

        // POST: WYNIK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WYNIK wYNIK = db.WYNIK.Find(id);
            db.WYNIK.Remove(wYNIK);
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
