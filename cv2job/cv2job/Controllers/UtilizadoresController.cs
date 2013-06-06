using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using cv2job.Filters;
using cv2job.Models;
using PagedList;
using System.IO;
using System.Diagnostics;
using System.Data;
namespace cv2job.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class UtilizadoresController : Controller
    {
        private Cv2jobContext db = new Cv2jobContext();
        public ActionResult Index(int? page)
        {

            int pageSize = 28;
            int pageFinal = (page ?? 1);
            ViewBag.Utilizadores = db.Utilizadores.ToList().ToPagedList(pageFinal, pageSize);
            ViewBag.Utilizador = db.Utilizadores.Find(WebSecurity.CurrentUserId);
            return View(db.Utilizadores.ToList());

        }


        //
        // GET: /Anuncios/Details/5


        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult Perfil(int id = 0)
        {
            Cv2jobContext db = new Cv2jobContext();
            Utilizador user = db.Utilizadores.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLocal(int id)
        {
            var utilizador = db.Utilizadores.Find(id);
            if (ModelState.IsValid)
            {
                utilizador.Morada = Request["Morada"];
                utilizador.Cidade = Request["Cidade"];
                utilizador.CodPostal = Request["CodPostal"];
                utilizador.Pais = Request["Pais"];
                db.Entry(utilizador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Perfil", new { id = utilizador.UserId });
            }
            return View(utilizador);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditContactos(int id)
        {
            var utilizador = db.Utilizadores.Find(id);
            if (ModelState.IsValid)
            {
                utilizador.Email = Request["Email"];
                utilizador.Fax = Request["Fax"];
                utilizador.WebSite = Request["WebSite"];
                utilizador.Contacto = Request["Contacto"];
                utilizador.Pais = Request["Pais"];
                db.Entry(utilizador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Perfil", new { id = utilizador.UserId });
            }
            return View(utilizador);
        }



        //
        // GET: /Account/Login





        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                int currentuserid = WebSecurity.GetUserId(model.UserName);

                ViewBag.logID = currentuserid;

                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "O username ou a password estão incorretos.");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {

                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { Email = model.Email, Nome = model.Nome, Apelido = model.Apelido, Avatar = "default.jpg", Criado = DateTime.Now, Sexo = model.Sexo });
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/Disassociate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Only disassociate the account if the currently logged in user is the owner
            if (ownerAccount == User.Identity.Name)
            {
                // Use a transaction to prevent the user from deleting their last login credential
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "A sua password foi alterada."
                : message == ManageMessageId.SetPasswordSuccess ? "A sua password foi definida."
                : message == ManageMessageId.RemoveLoginSuccess ? "O login externo foi removido."
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.HasLocalPassword = hasLocalAccount;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalAccount)
            {
                if (ModelState.IsValid)
                {
                    // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "A password atual está incorreta ou a nova password é inválida.");
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing
                // OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", String.Format("Não é possível criar a conta local. Uma conta com o nome \"{0}\" pode já existir.", User.Identity.Name));
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return RedirectToLocal(returnUrl);
            }

            if (User.Identity.IsAuthenticated)
            {
                // If the current user is logged in add the new account
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // User is new, ask for their desired membership name
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;
                return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            string provider = null;
            string providerUserId = null;

            if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Insert a new user into the database
                using (Cv2jobContext db = new Cv2jobContext())
                {
                    Utilizador user = db.Utilizadores.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
                    // Check if user already exists
                    if (user == null)
                    {
                        // Insert name into the profile table
                        db.Utilizadores.Add(new Utilizador { UserName = model.UserName });
                        db.SaveChanges();

                        OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
                        OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "O username já existe. Por favor, insira um username diferente.");
                    }
                }
            }

            ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // GET: /Account/ExternalLoginFailure

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(new ExternalLogin
                {
                    Provider = account.Provider,
                    ProviderDisplayName = clientData.DisplayName,
                    ProviderUserId = account.ProviderUserId,
                });
            }

            ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion



        //Para executar comandos do sitema

        [Authorize]
        [InitializeSimpleMembership]
        public FileResult GeraXML()
        {
            var utilizador = db.Utilizadores.Find(WebSecurity.CurrentUserId);
            InfoPessoal infoP = new InfoPessoal();
            InfoExtra infoE = new InfoExtra();
            infoP.FirstName = utilizador.Nome;
            infoP.LastName=utilizador.Apelido;
            infoP.Email = utilizador.Email;
            infoP.AddInfo=utilizador.Morada;
            infoP.PathFoto=utilizador.Avatar;
            infoP.Nacionalidade=utilizador.Nacionalidade;
 
      /*  public string CodPostal {get;set;}
        public string Cidade { get; set; }
        public string Nacionalidade { get; set; }
        public string Pais { get; set; }
        public string Sexo { get; set; }
        
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Contacto { get; set; }
        public string WebSite { get; set; }
            Candidato c = new Candidato(utilizador.UserName, infoP, infoE);
            */

            var path = Path.Combine(Server.MapPath("~/Europass/"), utilizador.UserName + ".xml");
            WriteXML xml = new WriteXML(path, c);
            xml.WritetoXml();




            //Corro bat do java .

            path = Path.Combine(Server.MapPath("~/Europass/"), utilizador.UserName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Server.MapPath("~/Europass/runComand2.bat");
            Process process = Process.Start(path, utilizador.UserName);
            while (!process.HasExited)
            { }

            //Verifica  se object ficheiro foi criado
            path = Path.Combine(Server.MapPath("~/Europass/"), utilizador.UserName, utilizador.UserName + ".pdf");
            bool existe = System.IO.File.Exists(path);


            //Abre o ficheiro
            Response.ContentType = "Application/pdf";
            // Response.TransmitFile(path);
            return File(path, Response.ContentType, utilizador.UserName + ".pdf");
        }
    }
}
