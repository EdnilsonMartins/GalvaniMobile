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
            var publicacao = IG.CarregarPublicacao(1, PublicacaoId, idiomaId);

            if (publicacao.PublicacaoId != 0)
            {
                model.Conteudo = publicacao;
            }

            var bannerSuperiorInterna = IG.CarregarBanner(1, PublicacaoId, 7, idiomaId);
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


            model.SubMenus = IG.ListarMenu(1, 1, idiomaId, Id).Menus.ToList();


            ViewBag.PublicacaoId = Id;

            return View(model);
        }

    }
}
