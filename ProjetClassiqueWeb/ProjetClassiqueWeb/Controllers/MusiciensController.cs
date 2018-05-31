using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjetClassiqueWeb.Controllers
{
    public class MusiciensController : Controller
    {
        private Classique_Web_2017Entities1 db = new Classique_Web_2017Entities1();

        // GET: Musiciens
        public async Task<ActionResult> Index()
        {
            var musicien = db.Musicien.Include(m => m.Genre).Include(m => m.Instrument).Include(m => m.Pays);
            return View(await musicien.ToListAsync());
        }

        // GET: Musiciens/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicien musicien = await db.Musicien.FindAsync(id);
            if (musicien == null)
            {
                return HttpNotFound();
            }
            return View(musicien);
        }

        // GET: Musiciens/Create
        public ActionResult Create()
        {
            ViewBag.Code_Genre = new SelectList(db.Genre, "Code_Genre", "Libelle_Abrege");
            ViewBag.Code_Instrument = new SelectList(db.Instrument, "Code_Instrument", "Nom_Instrument");
            ViewBag.Code_Pays = new SelectList(db.Pays, "Code_Pays", "Nom_Pays");
            return View();
        }

        // POST: Musiciens/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Code_Musicien,Nom_Musicien,Prenom_Musicien,Annee_Naissance,Annee_Mort,Code_Pays,Code_Genre,Code_Instrument,Photo")] Musicien musicien)
        {
            if (ModelState.IsValid)
            {
                db.Musicien.Add(musicien);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Code_Genre = new SelectList(db.Genre, "Code_Genre", "Libelle_Abrege", musicien.Code_Genre);
            ViewBag.Code_Instrument = new SelectList(db.Instrument, "Code_Instrument", "Nom_Instrument", musicien.Code_Instrument);
            ViewBag.Code_Pays = new SelectList(db.Pays, "Code_Pays", "Nom_Pays", musicien.Code_Pays);
            return View(musicien);
        }

        // GET: Musiciens/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicien musicien = await db.Musicien.FindAsync(id);
            if (musicien == null)
            {
                return HttpNotFound();
            }
            ViewBag.Code_Genre = new SelectList(db.Genre, "Code_Genre", "Libelle_Abrege", musicien.Code_Genre);
            ViewBag.Code_Instrument = new SelectList(db.Instrument, "Code_Instrument", "Nom_Instrument", musicien.Code_Instrument);
            ViewBag.Code_Pays = new SelectList(db.Pays, "Code_Pays", "Nom_Pays", musicien.Code_Pays);
            return View(musicien);
        }

        // POST: Musiciens/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Code_Musicien,Nom_Musicien,Prenom_Musicien,Annee_Naissance,Annee_Mort,Code_Pays,Code_Genre,Code_Instrument,Photo")] Musicien musicien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicien).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Code_Genre = new SelectList(db.Genre, "Code_Genre", "Libelle_Abrege", musicien.Code_Genre);
            ViewBag.Code_Instrument = new SelectList(db.Instrument, "Code_Instrument", "Nom_Instrument", musicien.Code_Instrument);
            ViewBag.Code_Pays = new SelectList(db.Pays, "Code_Pays", "Nom_Pays", musicien.Code_Pays);
            return View(musicien);
        }

        // GET: Musiciens/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicien musicien = await db.Musicien.FindAsync(id);
            if (musicien == null)
            {
                return HttpNotFound();
            }
            return View(musicien);
        }

        // POST: Musiciens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Musicien musicien = await db.Musicien.FindAsync(id);
            db.Musicien.Remove(musicien);
            await db.SaveChangesAsync();
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
