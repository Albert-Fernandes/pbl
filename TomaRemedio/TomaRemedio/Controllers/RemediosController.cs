using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TomaRemedio;
using TomaRemedio.Models;

namespace TomaRemedio.Controllers
{
    public class RemediosController : Controller
    {
        private TomaRemedioContext db = new TomaRemedioContext();

        // GET: Remedios
        public ActionResult Index()
        {
            var remedios = db.Remedios.Include(r => r.Receita);
            return View(remedios.ToList());
        }

        // GET: Remedios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remedio remedio = db.Remedios.Find(id);
            if (remedio == null)
            {
                return HttpNotFound();
            }
            return View(remedio);
        }

        // GET: Remedios/Create
        public ActionResult Create()
        {
            ViewBag.ReceitaId = new SelectList(db.Receitas, "Id", "Data");
            return View();
        }

        // POST: Remedios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,IsReceita,Intervalo,Dosagem,ReceitaId,Tipo")] Remedio remedio)
        {
            if (ModelState.IsValid)
            {
                if(remedio.Tipo==Tipo.SemTarja || remedio.Tipo==Tipo.Amarela || remedio.Tipo == Tipo.Vermelha)
                {
                    remedio.IsReceita = false;
                }
                else 
                {
                    remedio.IsReceita = true;
                }
                db.Remedios.Add(remedio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReceitaId = new SelectList(db.Receitas, "Id", "Data", remedio.ReceitaId);
            return View(remedio);
        }

        // GET: Remedios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remedio remedio = db.Remedios.Find(id);
            if (remedio == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReceitaId = new SelectList(db.Receitas, "Id", "Data", remedio.ReceitaId);
            return View(remedio);
        }

        // POST: Remedios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,IsReceita,Intervalo,Dosagem,ReceitaId,Tipo")] Remedio remedio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(remedio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReceitaId = new SelectList(db.Receitas, "Id", "Data", remedio.ReceitaId);
            return View(remedio);
        }

        // GET: Remedios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remedio remedio = db.Remedios.Find(id);
            if (remedio == null)
            {
                return HttpNotFound();
            }
            return View(remedio);
        }

        // POST: Remedios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Remedio remedio = db.Remedios.Find(id);
            db.Remedios.Remove(remedio);
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
