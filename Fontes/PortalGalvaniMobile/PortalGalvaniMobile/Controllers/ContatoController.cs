using PortalGalvaniMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

            #region --> Envio de E-mail
            if (!String.IsNullOrEmpty(Request.Form["btnEnviarCurriculum"]))
            {
                model.NrProtocoloContato = DateTime.Now.ToString("yyMMddHHmmssCfff");

                string nome = Request.Form["nome"];
                string email = Request.Form["email"];
                string telefone = Request.Form["telefone"];
                string enviaMensagem = Request.Form["mensagem"];

                string assunto = "Trabalhe Conosco";


                try
                {
                    var c = model.Configuracao;

                    var SiteNome = "Galvani Engenharia";

                    enviaMensagem = "<b>Contato via Portal " + SiteNome + "</b><br /><br />" +
                                    "Nome: " + nome + "<br />" +
                                    "Telefone: " + telefone + "<br />" +
                                    "E-mail: " + email + "<br />" +
                                    "Assunto: " + assunto + "<br />" +
                                    "Nr Controle: <b>" + model.NrProtocoloContato + "</b><br /><br />" +
                                    "Mensagem: <br>" +
                                    enviaMensagem;



                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                    client.Host = c.EmailHost;
                    //client.EnableSsl = true;
                    client.Port = c.EmailPorta;
                    client.Credentials = new System.Net.NetworkCredential(c.EmailUsername, c.EmailPassword);
                    MailMessage mail = new MailMessage();
                    mail.Sender = new System.Net.Mail.MailAddress(c.EmailUsername, c.EmailDisplayName);
                    mail.From = new MailAddress("no-reply@galvaniengenharia.com.br", c.EmailDisplayName);
                    mail.To.Add(new MailAddress(c.EmailDestino));
                    mail.ReplyToList.Add(new MailAddress(email));
                    mail.Subject = "Contato Portal";
                    mail.Body = enviaMensagem;
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;


                    #region --> Anexo
                    var Anexo = Request.Files["arquivo"];
                    if (Anexo != null && Anexo.ContentLength > 0)
                    {
                        Attachment anexo = new Attachment(Anexo.InputStream, Anexo.FileName);
                        mail.Attachments.Add(anexo);
                    }
                    #endregion


                    try
                    {
                        client.Send(mail);
                    }
                    catch (System.Exception erro)
                    {
                        //trata erro
                    }
                    finally
                    {
                        mail = null;
                    }
                }
                catch (Exception ex)
                {
                    string erro = ex.InnerException.ToString();
                    //return ex.Message.ToString() + erro;
                }
            }
            else if (!String.IsNullOrEmpty(Request.Form["email"]))
            {
                model.NrProtocoloContato = DateTime.Now.ToString("yyMMddHHmmssCfff");

                string nome = Request.Form["nome"];
                string email = Request.Form["email"];
                string telefone = Request.Form["telefone"];
                string assunto = Request.Form["assunto"];
                string areaAproximada = Request.Form["areaAproximada"];
                string cidade = Request.Form["cidade"];
                string enviaMensagem = Request.Form["mensagem"];


                try
                {
                    var c = model.Configuracao;

                    var SiteNome = "Galvani Engenharia";

                    enviaMensagem = "<b>Contato via Portal " + SiteNome + "</b><br /><br />" +
                                    "Nome: " + nome + "<br />" +
                                    "Telefone: " + telefone + "<br />" +
                                    "E-mail: " + email + "<br />" +
                                    "Assunto: " + assunto + "<br />" +
                                    "Área Aproximada: " + areaAproximada + "<br /><br />" +
                                    "Nr Controle: <b>" + model.NrProtocoloContato + "</b><br /><br />" +
                                    "Cidade: " + cidade + "<br /><br />" +
                                    "Mensagem: <br>" +
                                    enviaMensagem;



                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                    client.Host = c.EmailHost;
                    //client.EnableSsl = true;
                    client.Port = c.EmailPorta;
                    client.Credentials = new System.Net.NetworkCredential(c.EmailUsername, c.EmailPassword);
                    MailMessage mail = new MailMessage();
                    mail.Sender = new System.Net.Mail.MailAddress(c.EmailUsername, c.EmailDisplayName);
                    mail.From = new MailAddress("no-reply@galvaniengenharia.com.br", c.EmailDisplayName);
                    mail.To.Add(new MailAddress(c.EmailDestino));
                    mail.ReplyToList.Add(new MailAddress(email));
                    mail.Subject = "Contato Portal";
                    mail.Body = enviaMensagem;
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;

                    try
                    {
                        client.Send(mail);
                    }
                    catch (System.Exception erro)
                    {
                        //trata erro
                    }
                    finally
                    {
                        mail = null;
                    }
                }
                catch (Exception ex)
                {
                    string erro = ex.InnerException.ToString();
                    //return ex.Message.ToString() + erro;
                }
            }
            #endregion

            return View(model);
        }

    }
}
