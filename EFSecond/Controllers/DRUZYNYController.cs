using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFSecond.Models;
using System.Threading.Tasks;
using System.Data.Entity.SqlServer;

namespace EFSecond.Controllers
{
    public class DRUZYNYController : Controller
    {
        private ExtraLeagueEntities1 db = new ExtraLeagueEntities1();

        // GET: DRUZYNY
   
        public ViewResult Index(string sortOrder, string searchingString)
        {
            ViewData["PUNKTYSortParm"] = sortOrder == "PUNKTY" ? "punkty_desc" : "PUNKTY";
            ViewData["IDMiastaSortParm"] = sortOrder == "ID_MIASTA" ? "miasta_desc" : "ID_MIASTA";
            ViewData["NAZWADRUZYNYSortParm"] = sortOrder == "NAZWA_DRUZYNY" ? "nazwa_druzyny_desc" : "NAZWA_DRUZYNY";
            ViewData["BRAMKISortParm"] = sortOrder == "BRAMKI" ? "bramki_desc" : "BRAMKI";
            ViewData["ILOSCSPOTKANSortParm"] = sortOrder == "ILOSC_SPOTKAN" ? "ilosc_spotkan_desc" : "ILOSC_SPOTKAN";
            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";

            var druzyny = from s in db.DRUZYNY
                          select s;
            if (!String.IsNullOrEmpty(searchingString))
            {
                druzyny = druzyny.Where(s => s.NAZWA_DRUZYNY.Contains(searchingString) || SqlFunctions.StringConvert((decimal)s.ID_DRUZYNY).Contains(searchingString));
                System.Console.WriteLine("Hello World");
            }

            switch (sortOrder)
            {
                case "punkty_desc":
                    druzyny = druzyny.OrderByDescending(s => s.PUNKTY);
                    break;
                case "PUNKTY":
                    druzyny = druzyny.OrderBy(s => s.PUNKTY);
                    break;
                case "miasta_desc":
                    druzyny = druzyny.OrderByDescending(s => s.ID_MIASTA);
                    break;
                case "ID_MIASTA":
                    druzyny = druzyny.OrderBy(s => s.ID_MIASTA);
                    break;
                case "nazwa_druzyny_desc":
                    druzyny = druzyny.OrderByDescending(s => s.NAZWA_DRUZYNY);
                    break;
                case "NAZWA_DRUZYNY":
                    druzyny = druzyny.OrderBy(s => s.NAZWA_DRUZYNY);
                    break;
                case "bramki_desc":
                    druzyny = druzyny.OrderByDescending(s => s.BRAMKI);
                    break;
                case "BRAMKI":
                    druzyny = druzyny.OrderBy(s => s.BRAMKI);
                    break;
                case "ilosc_spotkan_desc":
                    druzyny = druzyny.OrderByDescending(s => s.ILOSC_SPOTKAN);
                    break;
                case "ILOSC_SPOTKAN":
                    druzyny = druzyny.OrderBy(s => s.ILOSC_SPOTKAN);
                    break;
                case "id_desc":
                    druzyny = druzyny.OrderByDescending(s => s.ID_DRUZYNY);
                    break;

                default:
                    druzyny = druzyny.OrderBy(s => s.ID_DRUZYNY);
                    break;
            }
            return View(druzyny.ToList());
        }
        // GET: DRUZYNY/Details/5
        [Authorize]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DRUZYNY dRUZYNY = db.DRUZYNY.Find(id);
            if (dRUZYNY == null)
            {
                return HttpNotFound();
            }
            return View(dRUZYNY);
        }

        // GET: DRUZYNY/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DRUZYNY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Create([Bind(Include = "ID_DRUZYNY,ID_MIASTA,NAZWA_DRUZYNY,PUNKTY,BRAMKI,ILOSC_SPOTKAN")] DRUZYNY dRUZYNY)
        {
            if (ModelState.IsValid)
            {
                db.DRUZYNY.Add(dRUZYNY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dRUZYNY);
        }

        // GET: DRUZYNY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DRUZYNY dRUZYNY = db.DRUZYNY.Find(id);
            if (dRUZYNY == null)
            {
                return HttpNotFound();
            }
            return View(dRUZYNY);
        }

        // POST: DRUZYNY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DRUZYNY,ID_MIASTA,NAZWA_DRUZYNY,PUNKTY,BRAMKI,ILOSC_SPOTKAN")] DRUZYNY dRUZYNY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dRUZYNY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dRUZYNY);
        }

        // GET: DRUZYNY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DRUZYNY dRUZYNY = db.DRUZYNY.Find(id);
            if (dRUZYNY == null)
            {
                return HttpNotFound();
            }
            return View(dRUZYNY);
        }

        // POST: DRUZYNY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DRUZYNY dRUZYNY = db.DRUZYNY.Find(id);
            db.DRUZYNY.Remove(dRUZYNY);
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
