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
    public class TrabajosController : Controller
    {
        private Entities db = new Entities();

        // GET: Trabajos
        public async Task<ActionResult> Index()
        {
            var trabajo = db.Trabajo.Include(t => t.Artista).Include(t => t.Cita).Include(t => t.Pago);
            return View(await trabajo.ToListAsync());
        }

        // GET: Trabajos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajo trabajo = await db.Trabajo.FindAsync(id);
            if (trabajo == null)
            {
                return HttpNotFound();
            }
            return View(trabajo);
        }

        // GET: Trabajos/Create
        public ActionResult Create()
        {
            ViewBag.artista_id = new SelectList(db.Artista, "id", "nombre");
            ViewBag.cita_id = new SelectList(db.Cita, "id", "id");
            ViewBag.pago_id = new SelectList(db.Pago, "id", "id");
            return View();
        }

        // POST: Trabajos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,fecha,precio,descripcion,cita_id,artista_id,pago_id")] Trabajo trabajo)
        {
            if (ModelState.IsValid)
            {
                db.Trabajo.Add(trabajo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.artista_id = new SelectList(db.Artista, "id", "nombre", trabajo.artista_id);
            ViewBag.cita_id = new SelectList(db.Cita, "id", "id", trabajo.cita_id);
            ViewBag.pago_id = new SelectList(db.Pago, "id", "id", trabajo.pago_id);
            return View(trabajo);
        }

        // GET: Trabajos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajo trabajo = await db.Trabajo.FindAsync(id);
            if (trabajo == null)
            {
                return HttpNotFound();
            }
            ViewBag.artista_id = new SelectList(db.Artista, "id", "nombre", trabajo.artista_id);
            ViewBag.cita_id = new SelectList(db.Cita, "id", "id", trabajo.cita_id);
            ViewBag.pago_id = new SelectList(db.Pago, "id", "id", trabajo.pago_id);
            return View(trabajo);
        }

        // POST: Trabajos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,fecha,precio,descripcion,cita_id,artista_id,pago_id")] Trabajo trabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.artista_id = new SelectList(db.Artista, "id", "nombre", trabajo.artista_id);
            ViewBag.cita_id = new SelectList(db.Cita, "id", "id", trabajo.cita_id);
            ViewBag.pago_id = new SelectList(db.Pago, "id", "id", trabajo.pago_id);
            return View(trabajo);
        }

        // GET: Trabajos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajo trabajo = await db.Trabajo.FindAsync(id);
            if (trabajo == null)
            {
                return HttpNotFound();
            }
            return View(trabajo);
        }

        // POST: Trabajos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Trabajo trabajo = await db.Trabajo.FindAsync(id);
            db.Trabajo.Remove(trabajo);
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
