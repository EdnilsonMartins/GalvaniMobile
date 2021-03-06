﻿using PortalGalvaniMobile.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace PortalGalvaniMobile
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            if (System.Configuration.ConfigurationManager.AppSettings["SiteId"] != null)
                Util.SiteId = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["SiteId"]);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var languageCookie = HttpContext.Current.Request.Cookies["langGalvaniMobile"];

            if (languageCookie == null)
            {
                var langCookie = new HttpCookie("langGalvaniMobile", "pt-BR") { HttpOnly = true };
                Response.AppendCookie(langCookie);
                languageCookie = HttpContext.Current.Request.Cookies["langGalvaniMobile"];
            }

            CultureInfo cultureInfo = CultureInfo.GetCultureInfo(languageCookie.Value);

            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
        }
    }
}