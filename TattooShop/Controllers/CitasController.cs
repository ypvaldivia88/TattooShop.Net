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
    public class CitasController : Controller
    {
        private Entities db = new Entities();

        // GET: Citas
        public async Task<ActionResult> Index()
        {
            var cita = db.Cita.Include(c => c.Artista).Include(c => c.Cliente).Include(c => c.TipoTrabajo);
            return View(await cita.ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = await db.Cita.FindAsync(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.artista_id = new SelectList(db.Artista, "id", "nombre");
            ViewBag.cliente_id = new SelectList(db.Cliente, "id", "nombre");
            ViewBag.tipo_trabajo_id = new SelectList(db.TipoTrabajo, "id", "Tipo");
            return View();
        }

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,fecha,deposito,cliente_id,tipo_trabajo_id,artista_id")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Cita.Add(cita);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.artista_id = new SelectList(db.Artista, "id", "nombre", cita.artista_id);
            ViewBag.cliente_id = new SelectList(db.Cliente, "id", "nombre", cita.cliente_id);
            ViewBag.tipo_trabajo_id = new SelectList(db.TipoTrabajo, "id", "Tipo", cita.tipo_trabajo_id);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = await db.Cita.FindAsync(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.artista_id = new SelectList(db.Artista, "id", "nombre", cita.artista_id);
            ViewBag.cliente_id = new SelectList(db.Cliente, "id", "nombre", cita.cliente_id);
            ViewBag.tipo_trabajo_id = new SelectList(db.TipoTrabajo, "id", "Tipo", cita.tipo_trabajo_id);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,fecha,deposito,cliente_id,tipo_trabajo_id,artista_id")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.artista_id = new SelectList(db.Artista, "id", "nombre", cita.artista_id);
            ViewBag.cliente_id = new SelectList(db.Cliente, "id", "nombre", cita.cliente_id);
            ViewBag.tipo_trabajo_id = new SelectList(db.TipoTrabajo, "id", "Tipo", cita.tipo_trabajo_id);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = await db.Cita.FindAsync(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cita cita = await db.Cita.FindAsync(id);
            db.Cita.Remove(cita);
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
