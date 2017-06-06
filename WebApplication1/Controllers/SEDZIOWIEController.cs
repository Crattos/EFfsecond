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
    public class SEDZIOWIEController : Controller
    {
        private ExtraLeagueEntities1 db = new ExtraLeagueEntities1();
        // GET: SEDZIOWIE
        public ViewResult Index(string sortOrder, string searchingString)
        {
          
            ViewData["IMIESEDZISortParm"] = sortOrder == "IMIE_SEDZI" ? "IMIE_SEDZI_desc" : "IMIE_SEDZI";
            ViewData["NAZWISKOSEDZISortParm"] = sortOrder == "NAZWISKO_SEDZI" ? "NAZWISKO_SEDZI_desc" : "NAZWISKO_SEDZI";
           
            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";

            var sedzia = from s in db.SEDZIOWIE
                           select s;
            if (!String.IsNullOrEmpty(searchingString))
            {
                sedzia = sedzia.Where(s => s.IMIE_SEDZI.Contains(searchingString) ||
                                            s.NAZWISKO_SEDZI.Contains(searchingString) ||
                                            SqlFunctions.StringConvert((decimal)s.ID_SEDZI).Contains(searchingString));
            }

            switch (sortOrder)
            {

              
                case "IMIE_SEDZI_desc":
                    sedzia = sedzia.OrderByDescending(s => s.IMIE_SEDZI);
                    break;
                case "IMIE_SEDZI":
                    sedzia = sedzia.OrderBy(s => s.IMIE_SEDZI);
                    break;
                case "NAZWISKO_SEDZI_desc":
                    sedzia = sedzia.OrderByDescending(s => s.NAZWISKO_SEDZI);
                    break;
                case "NAZWISKO_SEDZI":
                    sedzia = sedzia.OrderBy(s => s.NAZWISKO_SEDZI);
                    break;
                
                case "id_desc":
                    sedzia = sedzia.OrderByDescending(s => s.ID_SEDZI);
                    break;

                default:
                    sedzia = sedzia.OrderBy(s => s.ID_SEDZI);
                    break;
            }
            return View(sedzia.ToList());
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
