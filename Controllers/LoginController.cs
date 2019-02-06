using FloriculturaBeta.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FloriculturaBeta.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Aplicacao userApp = new Aplicacao();
        Session context = new Session();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            var authenticatedUser = userApp.GetByUsernameAndPassword(usuario);
            if (authenticatedUser != null)
            {
                context.SetAuthenticationToken(authenticatedUser.UsuarioId.ToString(), false, authenticatedUser);
                Session["idUsuario"] = usuario.UsuarioLogin;
                return RedirectToAction("Index", "Vendas");
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}