using PortalGalvaniMobile.IntegracaoGruppo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalGalvaniMobile.Models
{
    public class Portal
    {
        public bool ExibeContato { get; set; }
        public string NrProtocoloContato { get; set; }


        public string TagsSite { get; set; }
        public Publicacao Conteudo { get; set; }
        public List<Menu> Menus { get; set; }
        public List<Menu> SubMenus { get; set; }
        public List<Arquivo> FotosGaleria { get; set; }
        public Arquivo FotoDestaque { get; set; }


        public Banner BannerSuperiorInterna { get; set; }
        public Configuracao Configuracao { get; set; }

        public Portal(int idiomaId)
        {

            IntegracaoGruppo.IntegracaoPortalClient IG = new IntegracaoGruppo.IntegracaoPortalClient();
            Menus = IG.ListarMenu(1, 1, idiomaId, null).Menus.ToList();

            TagsSite = IG.CarregarTagSite(1);
            Configuracao = IG.CarregarConfiguracao(1);
            
        }

        public static int GetIdiomaId()
        {
            var lang = HttpContext.Current.Request.Cookies["langGalvaniMobile"] != null ? HttpContext.Current.Request.Cookies["langGalvaniMobile"].Value : "pt-BR";
            if (string.IsNullOrEmpty(lang)) lang = "pt-BR";

            int IdiomaId = 0;

            if (lang == "pt-BR") IdiomaId = (int)PortalGalvaniMobile.Models.Util.IDIOMA.PORTUGUES;
            else if (lang == "es-ES") IdiomaId = (int)PortalGalvaniMobile.Models.Util.IDIOMA.ESPANHOL;
            else if (lang == "en-US") IdiomaId = (int)PortalGalvaniMobile.Models.Util.IDIOMA.ENGLISH;
            else if (lang == "fr-CA") IdiomaId = (int)PortalGalvaniMobile.Models.Util.IDIOMA.FRANCES;
            return IdiomaId;
        }
    }
}