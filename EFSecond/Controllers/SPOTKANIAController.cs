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
    public class SPOTKANIAController : Controller
    {
        private ExtraLeagueEntities1 db = new ExtraLeagueEntities1();

        // GET: SPOTKANIA
        public ViewResult Index(string sortOrder, string searchingString)
        {
            ViewData["IDSEDZISortParm"] = sortOrder == "ID_SEDZI" ? "ID_SEDZI_desc" : "ID_SEDZI";
            ViewData["IDDRUZYNYSortParm"] = sortOrder == "ID_DRUZYNY" ? "ID_DRUZYNY_desc" : "ID_DRUZYNY";
            ViewData["IDMIASTASortParm"] = sortOrder == "ID_MIASTA" ? "ID_MIASTA_desc" : "ID_MIASTA";
            ViewData["DRUIDDRUZYNYSortParm"] = sortOrder == "DRU_ID_DRUZYNY" ? "DRU_ID_DRUZYNY_desc" : "DRU_ID_DRUZYNY";
            ViewData["BRAMKID1SortParm"] = sortOrder == "BRAMKI_D1" ? "BRAMKI_D1_desc" : "BRAMKI_D1";
            ViewData["BRAMKID2SortParm"] = sortOrder == "BRAMKI_D2" ? "BRAMKI_D2_desc" : "BRAMKI_D2";
            ViewData["DATASPOTKANIASortParm"] = sortOrder == "DATA_SPOTKANIA" ? "DATA_SPOTKANIA_desc" : "DATA_SPOTKANIA";

            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";

            var spotkania = from s in db.SPOTKANIA
                           select s;
            if (!String.IsNullOrEmpty(searchingString))
            {
                spotkania = spotkania.Where(s => 
                                            SqlFunctions.StringConvert((decimal)s.ID_DRUZYNY).Contains(searchingString) ||
                                            SqlFunctions.StringConvert((decimal)s.DRU_ID_DRUZYNY).Contains(searchingString));
            }

            switch (sortOrder)
            {

                case "ID_DRUZYNY_desc":
                    spotkania = spotkania.OrderByDescending(s => s.ID_DRUZYNY);
                    break;
                case "ID_DRUZYNY":
                    spotkania = spotkania.OrderBy(s => s.ID_DRUZYNY);
                    break;
                case "ID_SEDZI_desc":
                    spotkania = spotkania.OrderByDescending(s => s.ID_SEDZI);
                    break;
                case "ID_SEDZI":
                    spotkania = spotkania.OrderBy(s => s.ID_SEDZI);
                    break;
                case "ID_MIASTA_desc":
                    spotkania = spotkania.OrderByDescending(s => s.ID_MIASTA);
                    break;
                case "ID_MIASTA":
                    spotkania = spotkania.OrderBy(s => s.ID_MIASTA);
                    break;
                case "DRU_ID_DRUZYNY_desc":
                    spotkania = spotkania.OrderByDescending(s => s.DRU_ID_DRUZYNY);
                    break;
                case "DRU_ID_DRUZYNY":
                    spotkania = spotkania.OrderBy(s => s.DRU_ID_DRUZYNY);
                    break;
                case "BRAMKI_D1_desc":
                    spotkania = spotkania.OrderByDescending(s => s.BRAMKI_D1);
                    break;
                case "BRAMKI_D1":
                    spotkania = spotkania.OrderBy(s => s.BRAMKI_D1);
                    break;
                case "BRAMKI_D2_desc":
                    spotkania = spotkania.OrderByDescending(s => s.BRAMKI_D2);
                    break;
                case "BRAMKI_D2":
                    spotkania = spotkania.OrderBy(s => s.BRAMKI_D2);
                    break;
                case "DATA_SPOTKANIA_desc":
                    spotkania = spotkania.OrderByDescending(s => s.DATA_SPOTKANIA);
                    break;
                case "DATA_SPOTKANIA":
                    spotkania = spotkania.OrderBy(s => s.DATA_SPOTKANIA);
                    break;

                case "id_desc":
                    spotkania = spotkania.OrderByDescending(s => s.ID_SPOTKANIA);
                    break;

                default:
                    spotkania = spotkania.OrderBy(s => s.ID_SPOTKANIA);
                    break;
            }
            return View(spotkania.ToList());
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
