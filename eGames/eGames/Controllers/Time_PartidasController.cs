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
    public class Time_PartidasController : Controller
    {
        private eGamesContext db = new eGamesContext();

        // GET: Time_Partidas
        public ActionResult Index()
        {
            var time_Partida = db.Time_Partida.Include(t => t.Partida).Include(t => t.Time);
            return View(time_Partida.ToList());
        }

        // GET: Time_Partidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time_Partida time_Partida = db.Time_Partida.Find(id);
            if (time_Partida == null)
            {
                return HttpNotFound();
            }
            return View(time_Partida);
        }

        // GET: Time_Partidas/Create
        public ActionResult Create()
        {
            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Premiacao");
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome");
            return View();
        }

        // POST: Time_Partidas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Time_PartidaId,TimeId,PartidaId")] Time_Partida time_Partida,List<int>TimeId,Partida Partida)
        {
            if (ModelState.IsValid)
            {
                foreach(var times in TimeId)
                {
                    Time_Partida tt = new Time_Partida();
                    tt.PartidaId = Partida.PartidaId;
                    tt.TimeId = times;
                    db.Time_Partida.Add(tt);

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Premiacao", time_Partida.PartidaId);
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", time_Partida.TimeId);
            return View(time_Partida);
        }

        // GET: Time_Partidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time_Partida time_Partida = db.Time_Partida.Find(id);
            if (time_Partida == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Premiacao", time_Partida.PartidaId);
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", time_Partida.TimeId);
            return View(time_Partida);
        }

        // POST: Time_Partidas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Time_PartidaId,TimeId,PartidaId")] Time_Partida time_Partida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(time_Partida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Premiacao", time_Partida.PartidaId);
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", time_Partida.TimeId);
            return View(time_Partida);
        }

        // GET: Time_Partidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time_Partida time_Partida = db.Time_Partida.Find(id);
            if (time_Partida == null)
            {
                return HttpNotFound();
            }
            return View(time_Partida);
        }

        // POST: Time_Partidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Time_Partida time_Partida = db.Time_Partida.Find(id);
            db.Time_Partida.Remove(time_Partida);
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
