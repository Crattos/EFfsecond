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
    public class TRENERZYController : Controller
    {
        private ExtraLeagueEntities1 db = new ExtraLeagueEntities1();

        // GET: TRENERZY
        public ActionResult Index()
        {
            return View(db.TRENERZY.ToList());
        }

        // GET: TRENERZY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRENERZY tRENERZY = db.TRENERZY.Find(id);
            if (tRENERZY == null)
            {
                return HttpNotFound();
            }
            return View(tRENERZY);
        }

        // GET: TRENERZY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TRENERZY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TRENERA,ID_DRUZYNY,IMIE_TRENERA,NAZWISKO_TRENERA,WIEK_TRENERA,NARODOWOSC_TRENERA")] TRENERZY tRENERZY)
        {
            if (ModelState.IsValid)
            {
                db.TRENERZY.Add(tRENERZY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tRENERZY);
        }

        // GET: TRENERZY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRENERZY tRENERZY = db.TRENERZY.Find(id);
            if (tRENERZY == null)
            {
                return HttpNotFound();
            }
            return View(tRENERZY);
        }

        // POST: TRENERZY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TRENERA,ID_DRUZYNY,IMIE_TRENERA,NAZWISKO_TRENERA,WIEK_TRENERA,NARODOWOSC_TRENERA")] TRENERZY tRENERZY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRENERZY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tRENERZY);
        }

        // GET: TRENERZY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRENERZY tRENERZY = db.TRENERZY.Find(id);
            if (tRENERZY == null)
            {
                return HttpNotFound();
            }
            return View(tRENERZY);
        }

        // POST: TRENERZY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRENERZY tRENERZY = db.TRENERZY.Find(id);
            db.TRENERZY.Remove(tRENERZY);
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
