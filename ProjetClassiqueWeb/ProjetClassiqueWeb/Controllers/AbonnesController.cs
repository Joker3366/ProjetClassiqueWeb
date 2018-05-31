using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ProjetClassiqueWeb.Models;
namespace ProjetClassiqueWeb.Controllers
{
    public class AbonnesController : Controller
    {
        private Classique_Web_2017Entities1 db = new Classique_Web_2017Entities1();

        // GET: Abonnes
        public ActionResult Index()
        {
            var abonne = db.Abonne.Include(a => a.Pays);
            return View(abonne.ToList());
        }

        // GET: Abonnes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonne abonne = db.Abonne.Find(id);
            if (abonne == null)
            {
                return HttpNotFound();
            }
            return View(abonne);
        }

        // GET: Abonnes/Create
        public ActionResult Create()
        {
            ViewBag.Code_Pays = new SelectList(db.Pays, "Code_Pays", "Nom_Pays");
            return View();
        }
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        AccountController a = new AccountController();
        // POST: Abonnes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code_Abonne,Nom_Abonne,Login,Password,Adresse,Ville,Code_Postal,Code_Pays,Email,UserId,Credit,Prenom_Abonne")] Abonne abonne)
        {
            //  var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            //var result = await Microsoft.AspNet.Identity.UserManager.CreateAsync(user, model.Password);
            if (ModelState.IsValid)
            {
                db.Abonne.Add(abonne);
                db.SaveChanges();
                //  await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                var user = new ApplicationUser { UserName = abonne.Email, Email = abonne.Email };
                var result = UserManager.Create(user, abonne.Password);
             
                if (result.Succeeded)
                {
                    ViewBag.Code_Pays = new SelectList(db.Pays, "Code_Pays", "Nom_Pays", abonne.Code_Pays);


                };
                return RedirectToAction("Index");
            }

            
            return View(abonne);
        }
        public async Task<ActionResult> singin(ApplicationUser user ) {
            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            return RedirectToAction("Index", "Home");


        }

        // GET: Abonnes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonne abonne = db.Abonne.Find(id);
            if (abonne == null)
            {
                return HttpNotFound();
            }
            ViewBag.Code_Pays = new SelectList(db.Pays, "Code_Pays", "Nom_Pays", abonne.Code_Pays);
            return View(abonne);
        }

        // POST: Abonnes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code_Abonne,Nom_Abonne,Login,Password,Adresse,Ville,Code_Postal,Code_Pays,Email,UserId,Credit,Prenom_Abonne")] Abonne abonne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abonne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Code_Pays = new SelectList(db.Pays, "Code_Pays", "Nom_Pays", abonne.Code_Pays);
            return View(abonne);
        }

        // GET: Abonnes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonne abonne = db.Abonne.Find(id);
            if (abonne == null)
            {
                return HttpNotFound();
            }
            return View(abonne);
        }

        // POST: Abonnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abonne abonne = db.Abonne.Find(id);
            db.Abonne.Remove(abonne);
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
