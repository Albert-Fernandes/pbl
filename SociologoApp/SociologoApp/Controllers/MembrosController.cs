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
    public class MembrosController : Controller
    {
        private dbSociologoAppEntities db = new dbSociologoAppEntities();

        // GET: Membros
        public ActionResult Index()
        {
            var membro = db.Membro.Include(m => m.Familia);
            return View(membro.ToList());
        }

        // GET: Membros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro membro = db.Membro.Find(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            return View(membro);
        }

        // GET: Membros/Create
        public ActionResult Create(int? id)
        {
            ViewBag.FamiliaId = new SelectList(db.Familia, "Id", "Nome");
            return View();
        }

        // POST: Membros/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cpf,IsEscolarizado,isEmpregado,FamiliaId")] Membro membro)
        {
            if (ModelState.IsValid)
            {
                db.Membro.Add(membro);
                db.SaveChanges();
                if (membro.isEmpregado == true)
                {
                    return RedirectToAction("Create" + "/" + membro.Id, "Empregos");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.FamiliaId = new SelectList(db.Familia, "Id", "Nome", membro.FamiliaId);
            return View(membro);
        }

        // GET: Membros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro membro = db.Membro.Find(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamiliaId = new SelectList(db.Familia, "Id", "Nome", membro.FamiliaId);
            return View(membro);
        }

        // POST: Membros/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cpf,IsEscolarizado,isEmpregado,FamiliaId")] Membro membro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FamiliaId = new SelectList(db.Familia, "Id", "Nome", membro.FamiliaId);
            return View(membro);
        }

        // GET: Membros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro membro = db.Membro.Find(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            return View(membro);
        }

        // POST: Membros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membro membro = db.Membro.Find(id);
            db.Membro.Remove(membro);
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
