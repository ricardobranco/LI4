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
using cv2job.Shuffle;
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

            int pageSize = 6;
            int pageFinal = (page ?? 1);
            var user = db.Utilizadores.Find(WebSecurity.CurrentUserId);
            var dbCorp = user.CorpColab;
            var dbSeg = user.CorpSeguidas;
            ViewBag.Corporacoes = dbCorp.ToList().ToPagedList(pageFinal, pageSize);
            ViewBag.CorpSeguidas = dbSeg.ToList().ToPagedList(pageFinal, pageSize);

            return View(dbCorp.ToList());

        }




        //
        // GET: /Corporacoes/Details/5

        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult Details(int id, int? panuncios, int? pseguidores)
        {
            Corporacao corporacao = db.Corporacoes.Find(id);
            if (corporacao == null)
            {
                return HttpNotFound();
            }
            int pageSize = 20;
            int pageFinal = (panuncios ?? 1);
            var anuncios = corporacao.Anuncios;
            ViewBag.AnunciosCriados = anuncios.ToList().ToPagedList(pageFinal, pageSize);

            int pageSizeAnuncios = 9;
            var seguidores = corporacao.Seguidores;
            ViewBag.Seguidores = seguidores.ToList().ToPagedList(pageFinal, pageSizeAnuncios);
            ViewBag.Seguir = corporacao.Seguidores.Contains(db.Utilizadores.Find(WebSecurity.CurrentUserId));
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
                    int dia, mes, ano, hora, min, segundo;
                    DateTime now = DateTime.Now;
                    dia = now.Day;
                    mes = now.Month;
                    ano = now.Year;
                    hora = now.Hour;
                    min = now.Minute;
                    segundo = now.Second;
                    string data = "" + ano + mes + dia + hora + min + segundo;


                    var filename = "Corp" + data + Path.GetExtension(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Imagens/Corp"), filename);
                    file.SaveAs(path);
                    corporacao.PathLogo = filename;
                }

                Utilizador user = db.Utilizadores.Find(WebSecurity.CurrentUserId);
                corporacao.Seguidores.Add(user);
                corporacao.Colaboradores.Add(user);
                user.CorpColab.Add(corporacao);
                user.CorpSeguidas.Add(corporacao);

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

            foreach (var user in corporacao.Colaboradores)
            {
                user.CorpColab.Remove(corporacao);

            }
            foreach (var user in corporacao.Colaboradores)
            {
                user.CorpSeguidas.Remove(corporacao);

            }
            corporacao.Colaboradores.Clear();
            db.SaveChanges();

            foreach (var anuncio in corporacao.Anuncios)
            {
                RedirectToAction("Delete", "Anuncios", new { id = anuncio.AnuncioID });
            }
            corporacao.Anuncios.Clear();
            db.SaveChanges();


            db.Corporacoes.Remove(corporacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult FollowUnfollow(int  id = 0)
        {
            var corporacao = db.Corporacoes.Find(id);
            if (corporacao == null)
                return HttpNotFound();
            Utilizador utilizador = db.Utilizadores.Find(WebSecurity.CurrentUserId);
            if (utilizador.CorpSeguidas.Contains(corporacao))
            {
                utilizador.CorpSeguidas.Remove(corporacao);
                corporacao.Seguidores.Remove(utilizador);
            }
            else
            {
                utilizador.CorpSeguidas.Add(corporacao);
                corporacao.Seguidores.Add(utilizador);
            }
            db.SaveChanges();
            return RedirectToAction("Details", new { id = corporacao.CorpID});
        }

        public ActionResult Pesquisa(String termo)
        {
            List<Corporacao> res = db.Corporacoes.Where(c => c.Nome.Contains(termo)).ToList();
            return View(res);
        }

    }
}