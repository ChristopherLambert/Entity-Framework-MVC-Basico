using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Expressos.Models;

namespace Expressos.Controllers
{
    public class LivroesController : Controller
    {
        private ExpressosContext db = new ExpressosContext();

        // GET: Livroes
        public ActionResult Index()
        {
            var livroes = db.livro.Include(l => l.Autor).Include(l => l.Editora);
            return View(livroes.ToList());
        }

        // GET: Livroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.livro.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // GET: Livroes/Create
        public ActionResult Create()
        {
            ViewBag.AutorId = new SelectList(db.autor, "AutorId", "Nome");
            ViewBag.EditoraId = new SelectList(db.editora, "EditoraId", "Nome");
            return View();
        }
        public ActionResult CreateGrid(string query, string tipo)
        {
            List<Livro> livrosf;
            if (tipo == "1")
            {
                livrosf = db.livro.Where(c => c.Autor.Nome.Contains(query)).Include(l => l.Autor).Include(l => l.Editora).ToList();
            }else if (tipo == "2")
            {
               livrosf = db.livro.Where(c => c.Editora.Nome.Contains(query)).Include(l => l.Autor).Include(l => l.Editora).ToList();
            }
            else
            {
               livrosf = db.livro.Where(c => c.Titulo.Contains(query)).Include(l => l.Autor).Include(l => l.Editora).ToList();
            }
            return PartialView("Grid",livrosf);
        }

        // POST: Livroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LivroId,AutorId,EditoraId,Titulo,AnoLancamento")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.livro.Add(livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutorId = new SelectList(db.autor, "AutorId", "Nome", livro.AutorId);
            ViewBag.EditoraId = new SelectList(db.editora, "EditoraId", "Nome", livro.EditoraId);
            return View(livro);
        }

        // GET: Livroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.livro.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutorId = new SelectList(db.autor, "AutorId", "Nome", livro.AutorId);
            ViewBag.EditoraId = new SelectList(db.editora, "EditoraId", "Nome", livro.EditoraId);
            return View(livro);
        }

        // POST: Livroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LivroId,AutorId,EditoraId,Titulo,AnoLancamento")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutorId = new SelectList(db.autor, "AutorId", "Nome", livro.AutorId);
            ViewBag.EditoraId = new SelectList(db.editora, "EditoraId", "Nome", livro.EditoraId);
            return View(livro);
        }

        // GET: Livroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.livro.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // POST: Livroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livro livro = db.livro.Find(id);
            db.livro.Remove(livro);
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
