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

namespace EFSecond.Controllers
{
    public class DRUZYNYController : Controller
    {
        private ExtraLeagueEntities1 db = new ExtraLeagueEntities1();

        // GET: DRUZYNY
        public async Task<ActionResult> Index(string sortOrder)
        {
            //ViewData["PUNKTYSortParm"] = sortOrder == "PUNKTY" ? "punkty_desc" : "PUNKTY";
            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";

            var druzyny = from s in db.DRUZYNY
                          select s;
            switch (sortOrder)
            {
                /*case "punkty_desc":
                    druzyny = druzyny.OrderByDescending(s => s.PUNKTY);
                    break;
                case "PUNKTY":
                    druzyny = druzyny.OrderBy(s => s.PUNKTY);
                    break;*/
                case "id_desc":
                    druzyny = druzyny.OrderByDescending(s => s.ID_DRUZYNY);
                    break;

                default:
                    druzyny = druzyny.OrderBy(s => s.ID_DRUZYNY);
                    break;
            }
            return View(await druzyny.AsNoTracking().ToListAsync());
        }

        // GET: DRUZYNY/Details/5
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
