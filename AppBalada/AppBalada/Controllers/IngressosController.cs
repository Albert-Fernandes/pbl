using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppBalada.Models;

namespace AppBalada.Controllers
{
    public class IngressosController : Controller
    {
        private AppBaladaContext db = new AppBaladaContext();

        // GET: Ingressos
        public ActionResult Index(string pesquisa)
        {
            var ingressoes = db.Ingressoes.Include(i => i.Bilheteria).Include(i => i.Evento).Include(i => i.Pessoa);
            var pessoa = db.Pessoas.Include(p => p.Ingressos);
            var pessoas = from s in db.Ingressoes select s;
            int cont = db.Ingressoes.Count();
            ViewBag.Contador = cont;
            if (!String.IsNullOrEmpty(pesquisa))
            {
                pessoas = pessoas.Where(s => s.Pessoa.Nome.Contains(pesquisa));
                return View(ingressoes.ToList().Where(s=> s.Pessoa.Nome.Contains(pesquisa)));
            }
            else
            {
               
                return View(ingressoes.ToList());
            }
        }

        // GET: Ingressos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresso ingresso = db.Ingressoes.Find(id);
            if (ingresso == null)
            {
                return HttpNotFound();
            }
            return View(ingresso);
        }

        // GET: Ingressos/Create
        public ActionResult Create()
        {
            ViewBag.BilheteriaId = new SelectList(db.Bilheterias, "BilheteriaId", "Nome");
            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Nome");
            ViewBag.EventoId = new SelectList(db.Eventoes, "EventoId", "Nome");
            return View();
        }

        // POST: Ingressos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IngressoId,IsVip,PessoaId,EventoId,BilheteriaId")] Ingresso ingresso)
        {
            Pessoa pessoa = db.Pessoas.Find(ingresso.PessoaId);
            Evento evento = db.Eventoes.Find(ingresso.EventoId);
            if (pessoa.Idade<18 && evento.IsRestrito == true)
            {
                ModelState.AddModelError("Ingresso Id", "é menor de idade");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Ingressoes.Add(ingresso);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.EventoId = new SelectList(db.Eventoes, "EventoId", "Nome", ingresso.EventoId);
            ViewBag.BilheteriaId = new SelectList(db.Bilheterias, "BilheteriaId", "Nome", ingresso.BilheteriaId);
            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Nome", ingresso.PessoaId);
            return View(ingresso);
        }

        // GET: Ingressos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresso ingresso = db.Ingressoes.Find(id);
            if (ingresso == null)
            {
                return HttpNotFound();
            }
            ViewBag.BilheteriaId = new SelectList(db.Bilheterias, "BilheteriaId", "Nome", ingresso.BilheteriaId);
            ViewBag.EventoId = new SelectList(db.Eventoes, "EventoId", "Nome", ingresso.EventoId);
            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Nome", ingresso.PessoaId);
            return View(ingresso);
        }

        // POST: Ingressos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IngressoId,IsVip,PessoaId,EventoId,BilheteriaId")] Ingresso ingresso)
        {
            
                if (ModelState.IsValid)
                {
                    db.Entry(ingresso).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            
         
            ViewBag.BilheteriaId = new SelectList(db.Bilheterias, "BilheteriaId", "Nome", ingresso.BilheteriaId);
            ViewBag.EventoId = new SelectList(db.Eventoes, "EventoId", "Nome", ingresso.EventoId);
            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Nome", ingresso.PessoaId);
            return View(ingresso);
        }

        // GET: Ingressos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresso ingresso = db.Ingressoes.Find(id);
            if (ingresso == null)
            {
                return HttpNotFound();
            }
            return View(ingresso);
        }

        // POST: Ingressos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingresso ingresso = db.Ingressoes.Find(id);
            db.Ingressoes.Remove(ingresso);
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
