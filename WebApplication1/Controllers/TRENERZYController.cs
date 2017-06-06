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
    public class TRENERZYController : Controller
    {
        private ExtraLeagueEntities1 db = new ExtraLeagueEntities1();

        // GET: TRENERZY
        public ViewResult Index(string sortOrder, string searchingString)
        {
            ViewData["IDDRUZYNYSortParm"] = sortOrder == "ID_DRUZYNY" ? "ID_DRUZYNY_desc" : "ID_DRUZYNY";
            ViewData["IMIETRENERASortParm"] = sortOrder == "IMIE_TRENERA" ? "IMIE_TRENERA_desc" : "IMIE_TRENERA";
            ViewData["NAZWISKOTRENERASortParm"] = sortOrder == "NAZWISKO_TRENERA" ? "NAZWISKO_TRENERA_desc" : "NAZWISKO_TRENERA";
            ViewData["WIEKTRENERASortParm"] = sortOrder == "WIEK_TRENERA" ? "WIEK_TRENERA_desc" : "WIEK_TRENERA";
            ViewData["NARODOWOSCTRENERASortParm"] = sortOrder == "NARODOWOSC_TRENERA" ? "NARODOWOSC_TRENERA_desc" : "NARODOWOSC_TRENERA";

            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";

            var trenerzy = from s in db.TRENERZY
                           select s;
            if (!String.IsNullOrEmpty(searchingString))
            {
                trenerzy = trenerzy.Where(s => s.IMIE_TRENERA.Contains(searchingString) ||
                                            s.NAZWISKO_TRENERA.Contains(searchingString) ||
                                            s.NARODOWOSC_TRENERA.Contains(searchingString) ||
                                            SqlFunctions.StringConvert((decimal)s.ID_DRUZYNY).Contains(searchingString));
            }

            switch (sortOrder)
            {

                case "ID_DRUZYNY_desc":
                    trenerzy = trenerzy.OrderByDescending(s => s.ID_DRUZYNY);
                    break;
                case "ID_DRUZYNY":
                    trenerzy = trenerzy.OrderBy(s => s.ID_DRUZYNY);
                    break;
                case "IMIE_TRENERA_desc":
                    trenerzy = trenerzy.OrderByDescending(s => s.IMIE_TRENERA);
                    break;
                case "IMIE_TRENERA":
                    trenerzy = trenerzy.OrderBy(s => s.IMIE_TRENERA);
                    break;
                case "NAZWISKO_TRENERA_desc":
                    trenerzy = trenerzy.OrderByDescending(s => s.NAZWISKO_TRENERA);
                    break;
                case "NAZWISKO_TRENERA":
                    trenerzy = trenerzy.OrderBy(s => s.NAZWISKO_TRENERA);
                    break;
                case "wiek_pilkarza_desc":
                    trenerzy = trenerzy.OrderByDescending(s => s.WIEK_TRENERA);
                    break;
                case "WIEK_PILKARZA":
                    trenerzy = trenerzy.OrderBy(s => s.WIEK_TRENERA);
                    break;
                
                case "WIEK_TRENERA_desc":
                    trenerzy = trenerzy.OrderByDescending(s => s.NAZWISKO_TRENERA);
                    break;
                case "WIEK_TRENERA":
                    trenerzy = trenerzy.OrderBy(s => s.NAZWISKO_TRENERA);
                    break;

                case "id_desc":
                    trenerzy = trenerzy.OrderByDescending(s => s.ID_TRENERA);
                    break;

                default:
                    trenerzy = trenerzy.OrderBy(s => s.ID_TRENERA);
                    break;
            }
            return View(trenerzy.ToList()); 
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
