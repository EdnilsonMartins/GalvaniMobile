using PortalGalvaniMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalGalvaniMobile.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            int idiomaId = Portal.GetIdiomaId();

            Portal model = new Portal(idiomaId);

            IntegracaoGruppo.IntegracaoPortalClient IG = new IntegracaoGruppo.IntegracaoPortalClient();
            var publicacao = IG.CarregarHome(Util.SiteId, idiomaId);
            if (publicacao.PublicacaoId != 0)
            {
                model.Conteudo = publicacao;
            }

            return View(model);
        }

        public ActionResult SessionCulture(string lang, string ReturnUrl = "")
        {
            var langCookie = new HttpCookie("langGalvaniMobile", lang) { HttpOnly = true };
            Response.AppendCookie(langCookie);

            ConfigurarDadosDeCultura(lang);

            if (string.IsNullOrWhiteSpace(ReturnUrl))
            {
                return RedirectToAction("Index", "Home", new { culture = lang });
            }
            else
            {
                return Redirect(ReturnUrl);
            }
        }

        private void ConfigurarDadosDeCultura(string lang)
        {
            var currentCulture = HttpContext.Request.Cookies["langGalvaniMobile"] != null
                ? HttpContext.Request.Cookies["langGalvaniMobile"].Value
                : "pt-BR";

            if (currentCulture != lang)
            {
                //ConfigurarUrlDeConsulta();
            }
        }

    }
}
