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
    public class RemedioDoencasController : Controller
    {
        private TomaRemedioContext db = new TomaRemedioContext();

        // GET: RemedioDoencas
        public ActionResult Index()
        {
            var remedioDoencas = db.RemedioDoencas.Include(r => r.Doenca).Include(r => r.Remedio);
            return View(remedioDoencas.ToList());
        }
        // GET: RemedioDoencas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RemedioDoenca remedioDoenca = db.RemedioDoencas.Find(id);
            if (remedioDoenca == null)
            {
                return HttpNotFound();
            }
            return View(remedioDoenca);
        }

        // GET: RemedioDoencas/Create
        public ActionResult Create(int? id)
        {
            ViewBag.RemedioId = new SelectList(db.Remedios, "Id", "Nome");
            ViewBag.Doenca = db.Doencas.Find(id);
            return View();
        }

        // POST: RemedioDoencas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RemediosId,DoencaId,RemedioId")] RemedioDoenca remedioDoenca , List<int> RemedioId , Doenca Doenca)
        {
            if (ModelState.IsValid)
            {
                foreach(var remediosId in RemedioId)
                {
                    RemedioDoenca rr = new RemedioDoenca();
                    rr.DoencaId = Doenca.Id;
                    rr.RemedioId = remediosId;
                    db.RemedioDoencas.Add(rr);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: RemedioDoencas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RemedioDoenca remedioDoenca = db.RemedioDoencas.Find(id);
            if (remedioDoenca == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoencaId = new SelectList(db.Doencas, "Id", "Nome", remedioDoenca.DoencaId);
            ViewBag.RemedioId = new SelectList(db.Remedios, "Id", "Nome", remedioDoenca.RemedioId);
            return View(remedioDoenca);
        }

        // POST: RemedioDoencas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RemediosId,DoencaId,RemedioId")] RemedioDoenca remedioDoenca,List<int>RemedioId,Doenca Doenca)
        {
            if (ModelState.IsValid)
            {
                foreach(var remedios in RemedioId)
                {
                    RemedioDoenca rr = new RemedioDoenca();
                    rr.DoencaId = Doenca.Id;
                    rr.RemedioId = remedios;
                    db.Entry(remedioDoenca).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoencaId = new SelectList(db.Doencas, "Id", "Nome", remedioDoenca.DoencaId);
            ViewBag.RemedioId = new SelectList(db.Remedios, "Id", "Nome", remedioDoenca.RemedioId);
            return View();
        }

        // GET: RemedioDoencas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RemedioDoenca remedioDoenca = db.RemedioDoencas.Find(id);
            if (remedioDoenca == null)
            {
                return HttpNotFound();
            }
            return View(remedioDoenca);
        }

        // POST: RemedioDoencas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RemedioDoenca remedioDoenca = db.RemedioDoencas.Find(id);
            db.RemedioDoencas.Remove(remedioDoenca);
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
