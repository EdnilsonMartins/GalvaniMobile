using PortalGalvaniMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalGalvaniMobile.Controllers
{
    public class ConteudoController : Controller
    {
        //
        // GET: /Conteudo/

        public ActionResult Index(int? Id, string titulo = "")
        {
            int idiomaId = Portal.GetIdiomaId();

            Portal model = new Portal(idiomaId);

            int PublicacaoId = Id ?? 0;

            IntegracaoGruppo.IntegracaoPortalClient IG = new IntegracaoGruppo.IntegracaoPortalClient();
            var publicacao = IG.CarregarPublicacao(Util.SiteId, PublicacaoId, idiomaId);

            if (publicacao.PublicacaoId != 0)
            {
                model.Conteudo = publicacao;
            }

            var bannerSuperiorInterna = IG.CarregarBanner(Util.SiteId, PublicacaoId, 7, idiomaId);
            if (bannerSuperiorInterna.ArquivoId_Primaria != 0)
            {
                model.BannerSuperiorInterna = bannerSuperiorInterna;
            }

            model.FotosGaleria = IG.ListarArquivos(PublicacaoId, 2, 1).ToList();

            var listaFotoDestaque = IG.ListarArquivos(PublicacaoId, 1, 1).ToList();
            if (listaFotoDestaque.Any())
            {
                model.FotoDestaque = listaFotoDestaque[0];
            }


            model.SubMenus = IG.ListarMenu(Util.SiteId, 1, idiomaId, Id).Menus.ToList();


            ViewBag.PublicacaoId = Id;

            return View(model);
        }

    }
}
