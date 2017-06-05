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
    public class SEDZIOWIEController : Controller
    {
        private ExtraLeagueEntities1 db = new ExtraLeagueEntities1();

        // GET: SEDZIOWIE
        public ActionResult Index()
        {
            return View(db.SEDZIOWIE.ToList());
        }

        // GET: SEDZIOWIE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEDZIOWIE sEDZIOWIE = db.SEDZIOWIE.Find(id);
            if (sEDZIOWIE == null)
            {
                return HttpNotFound();
            }
            return View(sEDZIOWIE);
        }

        // GET: SEDZIOWIE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SEDZIOWIE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SEDZI,IMIE_SEDZI,NAZWISKO_SEDZI")] SEDZIOWIE sEDZIOWIE)
        {
            if (ModelState.IsValid)
            {
                db.SEDZIOWIE.Add(sEDZIOWIE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sEDZIOWIE);
        }

        // GET: SEDZIOWIE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEDZIOWIE sEDZIOWIE = db.SEDZIOWIE.Find(id);
            if (sEDZIOWIE == null)
            {
                return HttpNotFound();
            }
            return View(sEDZIOWIE);
        }

        // POST: SEDZIOWIE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SEDZI,IMIE_SEDZI,NAZWISKO_SEDZI")] SEDZIOWIE sEDZIOWIE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEDZIOWIE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sEDZIOWIE);
        }

        // GET: SEDZIOWIE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEDZIOWIE sEDZIOWIE = db.SEDZIOWIE.Find(id);
            if (sEDZIOWIE == null)
            {
                return HttpNotFound();
            }
            return View(sEDZIOWIE);
        }

        // POST: SEDZIOWIE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SEDZIOWIE sEDZIOWIE = db.SEDZIOWIE.Find(id);
            db.SEDZIOWIE.Remove(sEDZIOWIE);
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
