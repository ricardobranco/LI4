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
    public class TrabalhosController : Controller
    {
        private Cv2jobContext db = new Cv2jobContext();

        //
        // GET: /Trabalhos/

        public ActionResult Index()
        {
            return View(db.Trabalhos.ToList());
        }

        //
        // GET: /Trabalhos/Details/5

        public ActionResult Details(int id = 0)
        {
            Trabalho trabalho = db.Trabalhos.Find(id);
            if (trabalho == null)
            {
                return HttpNotFound();
            }
            return View(trabalho);
        }

        //
        // GET: /Trabalhos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Trabalhos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trabalho trabalho)
        {
            if (ModelState.IsValid)
            {
                db.Trabalhos.Add(trabalho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trabalho);
        }

        //
        // GET: /Trabalhos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Trabalho trabalho = db.Trabalhos.Find(id);
            if (trabalho == null)
            {
                return HttpNotFound();
            }
            return View(trabalho);
        }

        //
        // POST: /Trabalhos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trabalho trabalho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabalho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trabalho);
        }

        //
        // GET: /Trabalhos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Trabalho trabalho = db.Trabalhos.Find(id);
            if (trabalho == null)
            {
                return HttpNotFound();
            }
            return View(trabalho);
        }

        //
        // POST: /Trabalhos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trabalho trabalho = db.Trabalhos.Find(id);
            db.Trabalhos.Remove(trabalho);
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