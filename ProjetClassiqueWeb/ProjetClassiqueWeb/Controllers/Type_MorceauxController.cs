﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjetClassiqueWeb.Controllers
{
    public class Type_MorceauxController : Controller
    {
        private Classique_Web_2017Entities1 db = new Classique_Web_2017Entities1();

        // GET: Type_Morceaux
        public ActionResult Index()
        {
            return View(db.Type_Morceaux.ToList());
        }

        // GET: Type_Morceaux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_Morceaux type_Morceaux = db.Type_Morceaux.Find(id);
            if (type_Morceaux == null)
            {
                return HttpNotFound();
            }
            return View(type_Morceaux);
        }

        // GET: Type_Morceaux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Type_Morceaux/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code_Type,Libelle_Type,Description")] Type_Morceaux type_Morceaux)
        {
            if (ModelState.IsValid)
            {
                db.Type_Morceaux.Add(type_Morceaux);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type_Morceaux);
        }

        // GET: Type_Morceaux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_Morceaux type_Morceaux = db.Type_Morceaux.Find(id);
            if (type_Morceaux == null)
            {
                return HttpNotFound();
            }
            return View(type_Morceaux);
        }

        // POST: Type_Morceaux/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code_Type,Libelle_Type,Description")] Type_Morceaux type_Morceaux)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type_Morceaux).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type_Morceaux);
        }

        // GET: Type_Morceaux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_Morceaux type_Morceaux = db.Type_Morceaux.Find(id);
            if (type_Morceaux == null)
            {
                return HttpNotFound();
            }
            return View(type_Morceaux);
        }

        // POST: Type_Morceaux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Type_Morceaux type_Morceaux = db.Type_Morceaux.Find(id);
            db.Type_Morceaux.Remove(type_Morceaux);
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
