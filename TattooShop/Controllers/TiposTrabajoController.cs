using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TattooShop.Models;

namespace TattooShop.Controllers
{
    [Authorize]
    public class TiposTrabajoController : Controller
    {
        private Entities db = new Entities();

        // GET: TiposTrabajo
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoTrabajo.ToListAsync());
        }

        // GET: TiposTrabajo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTrabajo tipoTrabajo = await db.TipoTrabajo.FindAsync(id);
            if (tipoTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(tipoTrabajo);
        }

        // GET: TiposTrabajo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposTrabajo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Tipo")] TipoTrabajo tipoTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.TipoTrabajo.Add(tipoTrabajo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoTrabajo);
        }

        // GET: TiposTrabajo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTrabajo tipoTrabajo = await db.TipoTrabajo.FindAsync(id);
            if (tipoTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(tipoTrabajo);
        }

        // POST: TiposTrabajo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Tipo")] TipoTrabajo tipoTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoTrabajo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoTrabajo);
        }

        // GET: TiposTrabajo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTrabajo tipoTrabajo = await db.TipoTrabajo.FindAsync(id);
            if (tipoTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(tipoTrabajo);
        }

        // POST: TiposTrabajo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoTrabajo tipoTrabajo = await db.TipoTrabajo.FindAsync(id);
            db.TipoTrabajo.Remove(tipoTrabajo);
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
