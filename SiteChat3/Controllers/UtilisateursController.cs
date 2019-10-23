using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SiteChat3.Models;

namespace SiteChat3.Controllers
{
    public class UtilisateursController : Controller
    {
        private Chat2Entities db = new Chat2Entities();

        // GET: Utilisateurs
        public async Task<ActionResult> Index()
        {
            var utilisateur = db.Utilisateur.Include(u => u.Acces).Include(u => u.Avatar);
            return View(await utilisateur.ToListAsync());
        }

        // GET: Utilisateurs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = await db.Utilisateur.FindAsync(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
            ViewBag.IdAcces = new SelectList(db.Acces, "IdAcces", "LibelleAcces");
            ViewBag.IdAvatar = new SelectList(db.Avatar, "IdAvatar", "CheminAvatar");
            return View();
        }

        // POST: Utilisateurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdUtilisateur,NomUtilisateur,PrenomUtilisateur,PseudoUtilisateur,EmailUtilisateur,DateDeNaissanceUtilisateur,NumeroUtilisateur,MotDePasseUtilisateur,DateCreationUtilisateur,IdAvatar,IdAcces,StatutUtilisateur")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Utilisateur.Add(utilisateur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdAcces = new SelectList(db.Acces, "IdAcces", "LibelleAcces", utilisateur.IdAcces);
            ViewBag.IdAvatar = new SelectList(db.Avatar, "IdAvatar", "CheminAvatar", utilisateur.IdAvatar);
            return View(utilisateur);
        }

        // GET: Utilisateurs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = await db.Utilisateur.FindAsync(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAcces = new SelectList(db.Acces, "IdAcces", "LibelleAcces", utilisateur.IdAcces);
            ViewBag.IdAvatar = new SelectList(db.Avatar, "IdAvatar", "CheminAvatar", utilisateur.IdAvatar);
            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdUtilisateur,NomUtilisateur,PrenomUtilisateur,PseudoUtilisateur,EmailUtilisateur,DateDeNaissanceUtilisateur,NumeroUtilisateur,MotDePasseUtilisateur,DateCreationUtilisateur,IdAvatar,IdAcces,StatutUtilisateur")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilisateur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdAcces = new SelectList(db.Acces, "IdAcces", "LibelleAcces", utilisateur.IdAcces);
            ViewBag.IdAvatar = new SelectList(db.Avatar, "IdAvatar", "CheminAvatar", utilisateur.IdAvatar);
            return View(utilisateur);
        }

        // GET: Utilisateurs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = await db.Utilisateur.FindAsync(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Utilisateur utilisateur = await db.Utilisateur.FindAsync(id);
            db.Utilisateur.Remove(utilisateur);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
