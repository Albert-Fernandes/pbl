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
    public class VencedoresController : Controller
    {
        private eGamesContext db = new eGamesContext();

        // GET: Vencedores
        public ActionResult Index()
        {
            var vencedors = db.Vencedors.Include(v => v.Partida).Include(v => v.Time);
            return View(vencedors.ToList());
        }

        // GET: Vencedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vencedor vencedor = db.Vencedors.Find(id);
            if (vencedor == null)
            {
                return HttpNotFound();
            }
            return View(vencedor);
        }

        // GET: Vencedores/Create
        public ActionResult Create()
        {
            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Premiacao");
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome");
            return View();
        }

        // POST: Vencedores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VencedorId,PartidaId,TimeId")] Vencedor vencedor,List<int>TimeId)
        {
            if (ModelState.IsValid)
            {
                //foreach(var times in TimeId)
                //{
                //    Time tt = db.Times.Find(times);
                //    tt.TimeId = vencedor.TimeId;
                //}
                db.Vencedors.Add(vencedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Premiacao", vencedor.PartidaId);
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", vencedor.TimeId);
            return View(vencedor);
        }

        // GET: Vencedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vencedor vencedor = db.Vencedors.Find(id);
            if (vencedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Premiacao", vencedor.PartidaId);
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", vencedor.TimeId);
            return View(vencedor);
        }

        // POST: Vencedores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VencedorId,PartidaId,TimeId")] Vencedor vencedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vencedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Premiacao", vencedor.PartidaId);
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", vencedor.TimeId);
            return View(vencedor);
        }

        // GET: Vencedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vencedor vencedor = db.Vencedors.Find(id);
            if (vencedor == null)
            {
                return HttpNotFound();
            }
            return View(vencedor);
        }

        // POST: Vencedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vencedor vencedor = db.Vencedors.Find(id);
            db.Vencedors.Remove(vencedor);
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
