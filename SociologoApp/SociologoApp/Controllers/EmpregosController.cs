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
    public class EmpregosController : Controller
    {
        private dbSociologoAppEntities db = new dbSociologoAppEntities();

        // GET: Empregos
        public ActionResult Index(string nomeMenbro)
        {
            var emprego = db.Emprego.Include(e => e.Membro);
            return View(emprego.ToList());
        }

        // GET: Empregos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprego emprego = db.Emprego.Find(id);
            if (emprego == null)
            {
                return HttpNotFound();
            }
            return View(emprego);
        }

        // GET: Empregos/Create
        public ActionResult Create(int? id)
        {
            ViewBag.MembroId = new SelectList(db.Membro, "Id", "Nome");
            ViewBag.MembroId=db.Membro.Find(id);
            return View();
        }

        // POST: Empregos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Salario,MembroId")] Emprego emprego)
        {
            if (ModelState.IsValid)
            {
                db.Emprego.Add(emprego);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MembroId = new SelectList(db.Membro, "Id", "Nome", emprego.MembroId);
            return View(emprego);
        }

        // GET: Empregos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprego emprego = db.Emprego.Find(id);
            if (emprego == null)
            {
                return HttpNotFound();
            }
            ViewBag.MembroId = new SelectList(db.Membro, "Id", "Nome", emprego.MembroId);
            return View(emprego);
        }

        // POST: Empregos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Salario,MembroId")] Emprego emprego)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emprego).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MembroId = new SelectList(db.Membro, "Id", "Nome", emprego.MembroId);
            return View(emprego);
        }

        // GET: Empregos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprego emprego = db.Emprego.Find(id);
            if (emprego == null)
            {
                return HttpNotFound();
            }
            return View(emprego);
        }

        // POST: Empregos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emprego emprego = db.Emprego.Find(id);
            db.Emprego.Remove(emprego);
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
