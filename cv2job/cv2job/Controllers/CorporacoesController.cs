using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cv2job.Models;
using cv2job.Filters;
using PagedList;
using WebMatrix.WebData;
using System.IO;
namespace cv2job.Controllers
{
    public class CorporacoesController : Controller
    {
        private Cv2jobContext db = new Cv2jobContext();

        //
        // GET: /Corporacoes/
        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult Index(int? page)
        {

            Cv2jobContext db = new Cv2jobContext();
            int pageSize = 28;
            int pageFinal = (page ?? 1);
            var dbCorp = db.Corporacoes;
            ViewBag.Corporacoes = dbCorp.ToList().ToPagedList(pageFinal, pageSize);

            return View(dbCorp.ToList());

        }


        //
        // GET: /Corporacoes/Details/5

        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult Details(int id = 0)
        {
            Corporacao corporacao = db.Corporacoes.Find(id);
            if (corporacao == null)
            {
                return HttpNotFound();
            }
            return View(corporacao);
        }

        //
        // GET: /Corporacoes/Create
        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Corporacoes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Corporacao corporacao, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var filename = "Corp" + corporacao.CorpID+Path.GetExtension(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/App_Data/Imagens/"), filename);
                    

                    file.SaveAs(path);
                    corporacao.PathLogo = filename;
                }
                
               
                Utilizador user = db.Utilizadores.Find(WebSecurity.CurrentUserId);
                corporacao.Seguidores.Add(user);
                corporacao.Colaboradores.Add(user);
                
                db.Corporacoes.Add(corporacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(corporacao);
        }

        //
        // GET: /Corporacoes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Corporacao corporacao = db.Corporacoes.Find(id);
            if (corporacao == null)
            {
                return HttpNotFound();
            }
            return View(corporacao);
        }

        /*
        [HttpPost]
        public ActionResult adicionarColaborador(int id = 0)
        {
            Corporacao corporacao = db.Corporacoes.Find(id);
            Utilizador user = db.Utilizadores.Where(u => u.UserName.Equals(Request["user"])).FirstOrDefault();
            if (user != null && !corporacao.Colaboradores.Contains(user))
                corporacao.Colaboradores.Add(user);
            return View(corporacao);
        }*/
        
        
        
        //
        // POST: /Corporacoes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Corporacao corporacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(corporacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(corporacao);
        }

       

        //
        // POST: /Corporacoes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            
            Corporacao corporacao = db.Corporacoes.Find(id);
          /*  foreach (var user in corporacao.Colaboradores)
            {
                corporacao.Colaboradores.Remove(user);
                db.SaveChanges();
                
            }
            foreach (var user in corporacao.Seguidores)
            {
                corporacao.Seguidores.Remove(user);
                db.SaveChanges();
            }
            foreach (var anuncio in corporacao.Anuncios)
            {
                corporacao.Anuncios.Remove(anuncio);
                db.SaveChanges();
            }*/


            db.Corporacoes.Remove(corporacao);
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