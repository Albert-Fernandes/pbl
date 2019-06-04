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
    public class Time_PatrocinadoresController : Controller
    {
        private eGamesContext db = new eGamesContext();

        // GET: Time_Patrocinadores
        public ActionResult Index()
        {
            var time_Patrocinador = db.Time_Patrocinador.Include(t => t.Patrocinador).Include(t => t.Time);
            return View(time_Patrocinador.ToList());
        }

        // GET: Time_Patrocinadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time_Patrocinador time_Patrocinador = db.Time_Patrocinador.Find(id);
            if (time_Patrocinador == null)
            {
                return HttpNotFound();
            }
            return View(time_Patrocinador);
        }

        // GET: Time_Patrocinadores/Create
        public ActionResult Create()
        {
            ViewBag.PatrocinadorId = new SelectList(db.Patrocinadors, "PatrocinadorId", "Nome");
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome");
            return View();
        }

        // POST: Time_Patrocinadores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Time_PatrocinadorId,TimeId,PatrocinadorId")] Time_Patrocinador time_Patrocinador)
        {
            if (ModelState.IsValid)
            {
                db.Time_Patrocinador.Add(time_Patrocinador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatrocinadorId = new SelectList(db.Patrocinadors, "PatrocinadorId", "Nome", time_Patrocinador.PatrocinadorId);
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", time_Patrocinador.TimeId);
            return View(time_Patrocinador);
        }

        // GET: Time_Patrocinadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time_Patrocinador time_Patrocinador = db.Time_Patrocinador.Find(id);
            if (time_Patrocinador == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatrocinadorId = new SelectList(db.Patrocinadors, "PatrocinadorId", "Nome", time_Patrocinador.PatrocinadorId);
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", time_Patrocinador.TimeId);
            return View(time_Patrocinador);
        }

        // POST: Time_Patrocinadores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Time_PatrocinadorId,TimeId,PatrocinadorId")] Time_Patrocinador time_Patrocinador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(time_Patrocinador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatrocinadorId = new SelectList(db.Patrocinadors, "PatrocinadorId", "Nome", time_Patrocinador.PatrocinadorId);
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", time_Patrocinador.TimeId);
            return View(time_Patrocinador);
        }

        // GET: Time_Patrocinadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time_Patrocinador time_Patrocinador = db.Time_Patrocinador.Find(id);
            if (time_Patrocinador == null)
            {
                return HttpNotFound();
            }
            return View(time_Patrocinador);
        }

        // POST: Time_Patrocinadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Time_Patrocinador time_Patrocinador = db.Time_Patrocinador.Find(id);
            db.Time_Patrocinador.Remove(time_Patrocinador);
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
