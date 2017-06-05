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
    public class PILKARZEController : Controller
    {
        private ExtraLeagueEntities1 db = new ExtraLeagueEntities1();

        // GET: PILKARZE
        public ActionResult Index()
        {
            return View(db.PILKARZE.ToList());
        }

        // GET: PILKARZE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PILKARZE pILKARZE = db.PILKARZE.Find(id);
            if (pILKARZE == null)
            {
                return HttpNotFound();
            }
            return View(pILKARZE);
        }

        // GET: PILKARZE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PILKARZE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PILKARZA,ID_DRUZYNY,IMIE_PILKARZA,NAZWISKO_PILKARZA,WIEK_PILKARZA,POZYCJA,NARODOWOSC_PILKARZA")] PILKARZE pILKARZE)
        {
            if (ModelState.IsValid)
            {
                db.PILKARZE.Add(pILKARZE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pILKARZE);
        }

        // GET: PILKARZE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PILKARZE pILKARZE = db.PILKARZE.Find(id);
            if (pILKARZE == null)
            {
                return HttpNotFound();
            }
            return View(pILKARZE);
        }

        // POST: PILKARZE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PILKARZA,ID_DRUZYNY,IMIE_PILKARZA,NAZWISKO_PILKARZA,WIEK_PILKARZA,POZYCJA,NARODOWOSC_PILKARZA")] PILKARZE pILKARZE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pILKARZE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pILKARZE);
        }

        // GET: PILKARZE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PILKARZE pILKARZE = db.PILKARZE.Find(id);
            if (pILKARZE == null)
            {
                return HttpNotFound();
            }
            return View(pILKARZE);
        }

        // POST: PILKARZE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PILKARZE pILKARZE = db.PILKARZE.Find(id);
            db.PILKARZE.Remove(pILKARZE);
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
