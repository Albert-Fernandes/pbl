using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eGames.Models;

namespace eGames.Controllers
{
    public class PatrocinadoresController : Controller
    {
        private eGamesContext db = new eGamesContext();

        // GET: Patrocinadores
        public ActionResult Index()
        {
            return View(db.Patrocinadors.ToList());
        }

        // GET: Patrocinadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patrocinador patrocinador = db.Patrocinadors.Find(id);
            if (patrocinador == null)
            {
                return HttpNotFound();
            }
            return View(patrocinador);
        }

        // GET: Patrocinadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patrocinadores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatrocinadorId,Nome,Especialidade")] Patrocinador patrocinador)
        {
            if (ModelState.IsValid)
            {
                db.Patrocinadors.Add(patrocinador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patrocinador);
        }

        // GET: Patrocinadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patrocinador patrocinador = db.Patrocinadors.Find(id);
            if (patrocinador == null)
            {
                return HttpNotFound();
            }
            return View(patrocinador);
        }

        // POST: Patrocinadores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatrocinadorId,Nome,Especialidade")] Patrocinador patrocinador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patrocinador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patrocinador);
        }

        // GET: Patrocinadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patrocinador patrocinador = db.Patrocinadors.Find(id);
            if (patrocinador == null)
            {
                return HttpNotFound();
            }
            return View(patrocinador);
        }

        // POST: Patrocinadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patrocinador patrocinador = db.Patrocinadors.Find(id);
            db.Patrocinadors.Remove(patrocinador);
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
