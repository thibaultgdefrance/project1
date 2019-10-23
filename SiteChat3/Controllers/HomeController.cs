using SiteChat3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SiteChat3.Controllers
{
    public class HomeController : Controller
    {
        Chat2Entities db = new Chat2Entities();
        Workflow workflow = new Workflow();
        public ActionResult Index()
        {
            Utilisateur utilisateur = new Utilisateur();
           


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult Connexion(FormCollection collection)
        {
            ViewBag.messageErreure = "";
            var MailUtilisateur = collection["mail"];
            var MDPUtilisateur = collection["MDP"];
            int utilisateurExiste = (from u in db.Utilisateur where u.EmailUtilisateur == MailUtilisateur && u.MotDePasseUtilisateur == MDPUtilisateur select u).Count();
            if (utilisateurExiste > 0)
            {
                return RedirectToAction("MessagesApi", "Messages");
            }
            else
            {
                ViewBag.messageErreure = "email et/ou mot de passe incorrecte(s)";
                return RedirectToAction("Index", "Home");

            }


        }


        [HttpPost]
        public ActionResult Inscription(FormCollection collection)
        {
            ViewBag.messageErreure = "";
            var MailUtilisateur = collection["mail"];
            var MDPUtilisateur = collection["MDP"];
            int utilisateurExiste = (from u in db.Utilisateur where u.EmailUtilisateur == MailUtilisateur select u).Count();
            if (utilisateurExiste > 0)
            {
                ViewBag.MessageErreure = "un compte associé à cette adresse mail existe déjà";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.messageErreure = "";
                //Instanciation du client
                SmtpClient smtpClient = new SmtpClient("webmaster@cucarachat.com", 25);
                //On indique au client d'utiliser les informations qu'on va lui fournir
                smtpClient.UseDefaultCredentials = true;
                //Ajout des informations de connexion
                smtpClient.Credentials = new System.Net.NetworkCredential("webmaster@cucarachat.com", "hq2y5877hsb6");
                //On indique que l'on envoie le mail par le réseau
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //On active le protocole SSL
                smtpClient.EnableSsl = true;

                MailMessage mail = new MailMessage();
                //Expéditeur
                mail.From = new MailAddress("webmaster@cucarachat.com", "Cucarachat");
                //Destinataire
                mail.To.Add(new MailAddress("thibaustin@hotmail.fr"));

                mail.Subject = "lien de confirmation";
                mail.Body = "dxfb1d35hb4fd54h53t4d35ffh3h3";
                //Copie
                //mail.CC.Add(new MailAddress("toto@gmail.com"));

                smtpClient.Send(mail);
                return RedirectToAction("Index","Home");

            }


        }

        

    }
}