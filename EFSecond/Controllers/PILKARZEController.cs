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

namespace EFSecond.Controllers
{
    public class PILKARZEController : Controller
    {
        private ExtraLeagueEntities1 db = new ExtraLeagueEntities1();

        // GET: PILKARZE
        public ViewResult Index(string sortOrder, string searchingString)
        {
            ViewData["IDDRUZYNYSortParm"] = sortOrder == "ID_DRUZYNY" ? "ID_DRUZYNY_desc" : "ID_DRUZYNY";
            ViewData["IMIEPILKARZASortParm"] = sortOrder == "IMIE_PILKARZA" ? "imie_pilkarza_desc" : "IMIE_PILKARZA";
            ViewData["NAZWISKOPILKARZASortParm"] = sortOrder == "NAZWISKO_PILKARZA" ? "nazwisko_pilkarza_desc" : "NAZWISKO_PILKARZA";
            ViewData["WIEKPILKARZASortParm"] = sortOrder == "WIEK_PILKARZA" ? "wiek_pilkarza_desc" : "WIEK_PILKARZA";
            ViewData["POZYCJASortParm"] = sortOrder == "POZYCJA" ? "pozycja_desc" : "POZYCJA";
            ViewData["NARODOWOSCPILKARZASortParm"] = sortOrder == "NARODOWOSC_PILKARZA" ? "narodowosc_pilkarza_desc" : "NARODOWOSC_PILKARZA";

            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";

            var pilkarze = from s in db.PILKARZE
                         select s;
            if (!String.IsNullOrEmpty(searchingString))
            {
                pilkarze = pilkarze.Where(s => s.IMIE_PILKARZA.Contains(searchingString) ||
                                            s.NAZWISKO_PILKARZA.Contains(searchingString) ||
                                            s.NARODOWOSC_PILKARZA.Contains(searchingString) ||
                                            SqlFunctions.StringConvert((decimal)s.ID_DRUZYNY).Contains(searchingString));
            }

            switch (sortOrder)
            {

                case "ID_DRUZYNY_desc":
                    pilkarze = pilkarze.OrderByDescending(s => s.ID_DRUZYNY);
                    break;
                case "ID_DRUZYNY":
                    pilkarze = pilkarze.OrderBy(s => s.ID_DRUZYNY);
                    break;
                case "imie_pilkarza_desc":
                    pilkarze = pilkarze.OrderByDescending(s => s.IMIE_PILKARZA);
                    break;
                case "IMIE_PILKARZA":
                    pilkarze = pilkarze.OrderBy(s => s.IMIE_PILKARZA);
                    break;
                case "nazwisko_pilkarza_desc":
                    pilkarze = pilkarze.OrderByDescending(s => s.NAZWISKO_PILKARZA);
                    break;
                case "NAZWISKO_PILKARZA":
                    pilkarze = pilkarze.OrderBy(s => s.NAZWISKO_PILKARZA);
                    break;
                case "wiek_pilkarza_desc":
                    pilkarze = pilkarze.OrderByDescending(s => s.WIEK_PILKARZA);
                    break;
                case "WIEK_PILKARZA":
                    pilkarze = pilkarze.OrderBy(s => s.WIEK_PILKARZA);
                    break;
                case "pozycja_desc":
                    pilkarze = pilkarze.OrderByDescending(s => s.POZYCJA);
                    break;
                case "POZYCJA":
                    pilkarze = pilkarze.OrderBy(s => s.POZYCJA);
                    break;
                case "narodowosc_pilkarza_desc":
                    pilkarze = pilkarze.OrderByDescending(s => s.NARODOWOSC_PILKARZA);
                    break;
                case "NARODOWOSC_PILKARZA":
                    pilkarze = pilkarze.OrderBy(s => s.NARODOWOSC_PILKARZA);
                    break;

                case "id_desc":
                    pilkarze = pilkarze.OrderByDescending(s => s.ID_PILKARZA);
                    break;

                default:
                    pilkarze = pilkarze.OrderBy(s => s.ID_PILKARZA);
                    break;
            }
            return View(pilkarze.ToList());
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
