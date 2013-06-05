using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cv2job.Models;
using PagedList;
using cv2job.Filters;
using WebMatrix.WebData;
namespace cv2job.Controllers
{
    public class MensagensController : Controller
    {
        private Cv2jobContext db = new Cv2jobContext();

        //
        // GET: /Mensagens/
        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult Index(int? page)
        {
            var user = db.Utilizadores.Find(WebSecurity.CurrentUserId);
            if (user.Mensagens == null)
            {
                user.Mensagens = new Dictionary<Utilizador, ICollection<Mensagem>>();
                db.SaveChanges();
            } 
            var mensagens = user.Mensagens;
            int pageSize = 20;
            int pageFinal = (page ?? 1);
            ViewBag.Mensagens = mensagens.Keys.ToPagedList(pageFinal, pageSize);

            return View(mensagens);
        }
        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult Details()
        {
            return View();
        }


    /*    //
        // GET: /Mensagens/Details/5
        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult Details(int id = 0)
        {
            Mensagem mensagem = db.Mensagens.Find(id);
            if (mensagem == null)
            {
                return HttpNotFound();
            }
            return View(mensagem);
        }*/


      
        //
        // GET: /Mensagens/Create
        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Mensagens/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                //DO LADO DO EMISSOR
                if (!mensagem.Emissor.Mensagens.ContainsKey(mensagem.Receptor))
                {
                    mensagem.Emissor.Mensagens.Add(mensagem.Receptor, new List<Mensagem>());
                }
                mensagem.Emissor.Mensagens.Add(mensagem.Receptor, new List<Mensagem>());

                //DO LADO DO RECEPTOR
                if (!mensagem.Receptor.Mensagens.ContainsKey(mensagem.Emissor))
                {
                    mensagem.Receptor.Mensagens.Add(mensagem.Emissor, new List<Mensagem>());
                }
                mensagem.Receptor.Mensagens.Add(mensagem.Emissor, new List<Mensagem>());



                db.Mensagens.Add(mensagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mensagem);
        }

        //
        // GET: /Mensagens/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Mensagem mensagem = db.Mensagens.Find(id);
            if (mensagem == null)
            {
                return HttpNotFound();
            }
            return View(mensagem);
        }

        //
        // POST: /Mensagens/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mensagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mensagem);
        }



        //
        // POST: /Mensagens/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Mensagem mensagem = db.Mensagens.Find(id);
            var user = db.Utilizadores.Find(WebSecurity.CurrentUserId);
            user.Mensagens.Remove(user.UserId == mensagem.Emissor.UserId ? mensagem.Receptor : mensagem.Emissor);
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