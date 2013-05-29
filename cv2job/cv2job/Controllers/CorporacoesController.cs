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
    public class CorporacoesController : Controller
    {
        private Cv2jobContext db = new Cv2jobContext();

        //
        // GET: /Corporacoes/

        public ActionResult Index()
        {
            return View(db.Corporacoes.ToList());
        }

        //
        // GET: /Corporacoes/Details/5

        public ActionResult Details(int id = 0)
        {
            Corporcao corporcao = db.Corporacoes.Find(id);
            if (corporcao == null)
            {
                return HttpNotFound();
            }
            return View(corporcao);
        }

        //
        // GET: /Corporacoes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Corporacoes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Corporcao corporcao)
        {
            if (ModelState.IsValid)
            {
                db.Corporacoes.Add(corporcao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(corporcao);
        }

        //
        // GET: /Corporacoes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Corporcao corporcao = db.Corporacoes.Find(id);
            if (corporcao == null)
            {
                return HttpNotFound();
            }
            return View(corporcao);
        }

        //
        // POST: /Corporacoes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Corporcao corporcao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(corporcao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(corporcao);
        }

        //
        // GET: /Corporacoes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Corporcao corporcao = db.Corporacoes.Find(id);
            if (corporcao == null)
            {
                return HttpNotFound();
            }
            return View(corporcao);
        }

        //
        // POST: /Corporacoes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Corporcao corporcao = db.Corporacoes.Find(id);
            db.Corporacoes.Remove(corporcao);
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