using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cv2job.Models;
using PagedList;
using WebMatrix.WebData;
using cv2job.Filters;
namespace cv2job.Controllers
{
    public class AnunciosController : Controller
    {
        private Cv2jobContext db = new Cv2jobContext();

        //
        // GET: /Anuncios/

        [InitializeSimpleMembership]
        [Authorize]
        public ActionResult Index(int? page)
        {
            var user = db.Utilizadores.Find(WebSecurity.CurrentUserId);

            int pageSize = 20;
            int pageFinal = (page ?? 1);
            var dbCorp = user.AnunciosCriados;
            ViewBag.Anuncios = dbCorp.ToList().ToPagedList(pageFinal, pageSize);

            return View(dbCorp.ToList());

        }
        //
        // GET: /Anuncios/Details/5

        public ActionResult Details(int id = 0)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        //
        // GET: /Anuncios/Create
        [InitializeSimpleMembership]
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.WhoIam = db.Utilizadores.Find(WebSecurity.CurrentUserId);
           
            return View();
        }

        //
        // POST: /Anuncios/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [InitializeSimpleMembership]
        
        public ActionResult Create(Anuncio anuncio)
        {
            Utilizador user = db.Utilizadores.Find(WebSecurity.CurrentUserId);
            ViewBag.WhoIam = user;
            
            if (ModelState.IsValid)
            {
                anuncio.Corporacao = db.Corporacoes.Find(anuncio.CorporacaoID);
                anuncio.Corporacao.Anuncios.Add(anuncio);
                anuncio.Criador = user;
                user.AnunciosSeguidos.Add(anuncio);
                user.AnunciosCriados.Add(anuncio);
                Feed feed = new Feed();
                feed.AutorID = anuncio.CorporacaoID;
                feed.Imagem = "/Imagens/Corp/" + anuncio.Corporacao.PathLogo;
                feed.Identidade = anuncio.Corporacao.Nome;
                feed.Tipo = 3;
                feed.Descricao = "Criou Anúncio para o Cargo de "+anuncio.Cargo;
                db.Anuncios.Add(anuncio);
                db.Feeds.Add(feed);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = anuncio.AnuncioID});
            }

            return View(anuncio);
        }

        //
        // GET: /Anuncios/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        //
        // POST: /Anuncios/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anuncio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anuncio);
        }

        //
        // POST: /Anuncios/Delete/5

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            foreach (var user in anuncio.Seguidores)
            {
                user.AnunciosSeguidos.Remove(anuncio);
            }
            anuncio.Criador.AnunciosCriados.Remove(anuncio);
            db.Anuncios.Remove(anuncio);
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