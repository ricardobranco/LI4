using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cv2job.Models;

namespace cv2job.Controllers
{
    public class EducacoesController : Controller
    {
        private Cv2jobContext db = new Cv2jobContext();

        //
        // GET: /Educacoes/

        public ActionResult Index()
        {
            return View(db.Educacaos.ToList());
        }

        //
        // GET: /Educacoes/Details/5

        public ActionResult Details(int id = 0)
        {
            Educacao educacao = db.Educacaos.Find(id);
            if (educacao == null)
            {
                return HttpNotFound();
            }
            return View(educacao);
        }

        //
        // GET: /Educacoes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Educacoes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Educacao educacao)
        {
            if (ModelState.IsValid)
            {
                db.Educacaos.Add(educacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(educacao);
        }

        //
        // GET: /Educacoes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Educacao educacao = db.Educacaos.Find(id);
            if (educacao == null)
            {
                return HttpNotFound();
            }
            return View(educacao);
        }

        //
        // POST: /Educacoes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Educacao educacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(educacao);
        }

        //
        // GET: /Educacoes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Educacao educacao = db.Educacaos.Find(id);
            if (educacao == null)
            {
                return HttpNotFound();
            }
            return View(educacao);
        }

        //
        // POST: /Educacoes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Educacao educacao = db.Educacaos.Find(id);
            db.Educacaos.Remove(educacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}