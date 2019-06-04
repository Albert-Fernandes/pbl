using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SociologoApp;

namespace SociologoApp.Controllers
{
    public class TipoMembrosController : Controller
    {
        private dbSociologoAppEntities db = new dbSociologoAppEntities();

        // GET: TipoMembros
        public ActionResult Index()
        {
            var tipoMembro = db.TipoMembro.Include(t => t.Membro);
            return View(tipoMembro.ToList());
        }

        // GET: TipoMembros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMembro tipoMembro = db.TipoMembro.Find(id);
            if (tipoMembro == null)
            {
                return HttpNotFound();
            }
            return View(tipoMembro);
        }

        // GET: TipoMembros/Create
        public ActionResult Create()
        {
            ViewBag.MembroId = new SelectList(db.Membro, "Id", "Nome");
            return View();
        }

        // POST: TipoMembros/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo,MembroId")] TipoMembro tipoMembro)
        {
            if (ModelState.IsValid)
            {
                db.TipoMembro.Add(tipoMembro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MembroId = new SelectList(db.Membro, "Id", "Nome", tipoMembro.MembroId);
            return View(tipoMembro);
        }

        // GET: TipoMembros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMembro tipoMembro = db.TipoMembro.Find(id);
            if (tipoMembro == null)
            {
                return HttpNotFound();
            }
            ViewBag.MembroId = new SelectList(db.Membro, "Id", "Nome", tipoMembro.MembroId);
            return View(tipoMembro);
        }

        // POST: TipoMembros/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,MembroId")] TipoMembro tipoMembro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoMembro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MembroId = new SelectList(db.Membro, "Id", "Nome", tipoMembro.MembroId);
            return View(tipoMembro);
        }

        // GET: TipoMembros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMembro tipoMembro = db.TipoMembro.Find(id);
            if (tipoMembro == null)
            {
                return HttpNotFound();
            }
            return View(tipoMembro);
        }

        // POST: TipoMembros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoMembro tipoMembro = db.TipoMembro.Find(id);
            db.TipoMembro.Remove(tipoMembro);
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
