using PortalGalvaniMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalGalvaniMobile.Controllers
{
    public class ContatoController : Controller
    {
        //
        // GET: /Contato/

        public ActionResult Index()
        {
            int idiomaId = Portal.GetIdiomaId();

            Portal model = new Portal(idiomaId);

            model.ExibeContato = true;

            return View(model);
        }

    }
}
