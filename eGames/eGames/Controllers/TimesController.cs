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
    public class TimesController : Controller
    {
        private eGamesContext db = new eGamesContext();

        // GET: Times
        public ActionResult Index()
        {
            var times = db.Times.Include(t => t.Partida);
            return View(times.ToList());
        }

        // GET: Times/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        // GET: Times/Create
        public ActionResult Create()
        {
            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Premiacao");
            return View();
        }

        // POST: Times/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimeId,Nome,Vitoria,IsVencedor,PartidaId")] Time time,List<Jogador>Jogadores)
        {
            var quantidade = db.Jogadors.Count();
            if (quantidade <= 5)
            {
                if (ModelState.IsValid)
                {
                    foreach(var jogadoresid in Jogadores)
                    {

                    }
                    db.Times.Add(time);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Premiacao", time.PartidaId);
            return View(time);
        }

        // GET: Times/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Premiacao", time.PartidaId);
            return View(time);
        }

        // POST: Times/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimeId,Nome,Vitoria,IsVencedor,PartidaId")] Time time)
        {
            if (ModelState.IsValid)
            {
                db.Entry(time).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Premiacao", time.PartidaId);
            return View(time);
        }

        // GET: Times/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        // POST: Times/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Time time = db.Times.Find(id);
            db.Times.Remove(time);
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
