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
    public class SkillsController : Controller
    {
        private Cv2jobContext db = new Cv2jobContext();

        //
        // GET: /Skills/

        public ActionResult Index()
        {
            return View(db.Skills.ToList());
        }

        //
        // GET: /Skills/Details/5

        public ActionResult Details(int id = 0)
        {
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        //
        // GET: /Skills/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Skills/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Skills.Add(skill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skill);
        }

        //
        // GET: /Skills/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        //
        // POST: /Skills/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skill);
        }

        //
        // GET: /Skills/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        //
        // POST: /Skills/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skill skill = db.Skills.Find(id);
            db.Skills.Remove(skill);
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