using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjMVCEntityFramework.Models;

namespace ProjMVCEntityFramework.Controllers
{
    public class TB_DISCIPLINAController : Controller
    {
        private DisciplinaDBEntities2 db = new DisciplinaDBEntities2();

        // GET: TB_DISCIPLINA
        public ActionResult Index()
        {
            return View(db.TB_DISCIPLINA.ToList());
        }

        // GET: TB_DISCIPLINA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_DISCIPLINA tB_DISCIPLINA = db.TB_DISCIPLINA.Find(id);
            if (tB_DISCIPLINA == null)
            {
                return HttpNotFound();
            }
            return View(tB_DISCIPLINA);
        }

        // GET: TB_DISCIPLINA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_DISCIPLINA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descricao,QtdAlunos,NomeProfessor")] TB_DISCIPLINA tB_DISCIPLINA)
        {
            if (ModelState.IsValid)
            {
                db.TB_DISCIPLINA.Add(tB_DISCIPLINA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_DISCIPLINA);
        }

        // GET: TB_DISCIPLINA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_DISCIPLINA tB_DISCIPLINA = db.TB_DISCIPLINA.Find(id);
            if (tB_DISCIPLINA == null)
            {
                return HttpNotFound();
            }
            return View(tB_DISCIPLINA);
        }

        // POST: TB_DISCIPLINA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descricao,QtdAlunos,NomeProfessor")] TB_DISCIPLINA tB_DISCIPLINA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_DISCIPLINA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_DISCIPLINA);
        }

        // GET: TB_DISCIPLINA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_DISCIPLINA tB_DISCIPLINA = db.TB_DISCIPLINA.Find(id);
            if (tB_DISCIPLINA == null)
            {
                return HttpNotFound();
            }
            return View(tB_DISCIPLINA);
        }

        // POST: TB_DISCIPLINA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_DISCIPLINA tB_DISCIPLINA = db.TB_DISCIPLINA.Find(id);
            db.TB_DISCIPLINA.Remove(tB_DISCIPLINA);
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
