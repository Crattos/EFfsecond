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
    public class SPOTKANIAController : Controller
    {
        private ExtraLeagueEntities1 db = new ExtraLeagueEntities1();

        // GET: SPOTKANIA
        public ActionResult Index()
        {
            return View(db.SPOTKANIA.ToList());
        }

        // GET: SPOTKANIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPOTKANIA sPOTKANIA = db.SPOTKANIA.Find(id);
            if (sPOTKANIA == null)
            {
                return HttpNotFound();
            }
            return View(sPOTKANIA);
        }

        // GET: SPOTKANIA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SPOTKANIA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SPOTKANIA,ID_SEDZI,ID_DRUZYNY,ID_MIASTA,DRU_ID_DRUZYNY,BRAMKI_D1,BRAMKI_D2,DATA_SPOTKANIA")] SPOTKANIA sPOTKANIA)
        {
            if (ModelState.IsValid)
            {
                db.SPOTKANIA.Add(sPOTKANIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sPOTKANIA);
        }

        // GET: SPOTKANIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPOTKANIA sPOTKANIA = db.SPOTKANIA.Find(id);
            if (sPOTKANIA == null)
            {
                return HttpNotFound();
            }
            return View(sPOTKANIA);
        }

        // POST: SPOTKANIA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SPOTKANIA,ID_SEDZI,ID_DRUZYNY,ID_MIASTA,DRU_ID_DRUZYNY,BRAMKI_D1,BRAMKI_D2,DATA_SPOTKANIA")] SPOTKANIA sPOTKANIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPOTKANIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sPOTKANIA);
        }

        // GET: SPOTKANIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPOTKANIA sPOTKANIA = db.SPOTKANIA.Find(id);
            if (sPOTKANIA == null)
            {
                return HttpNotFound();
            }
            return View(sPOTKANIA);
        }

        // POST: SPOTKANIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SPOTKANIA sPOTKANIA = db.SPOTKANIA.Find(id);
            db.SPOTKANIA.Remove(sPOTKANIA);
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
