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
    public class PagosController : Controller
    {
        private Entities db = new Entities();

        // GET: Pagos
        public async Task<ActionResult> Index()
        {
            var pago = db.Pago.Include(p => p.Artista);
            return View(await pago.ToListAsync());
        }

        // GET: Pagos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = await db.Pago.FindAsync(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // GET: Pagos/Create
        public ActionResult Create()
        {
            ViewBag.artista_id = new SelectList(db.Artista, "id", "nombre");
            return View();
        }

        // POST: Pagos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,desde,hasta,efectivo,artista_id")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Pago.Add(pago);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.artista_id = new SelectList(db.Artista, "id", "nombre", pago.artista_id);
            return View(pago);
        }

        // GET: Pagos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = await db.Pago.FindAsync(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            ViewBag.artista_id = new SelectList(db.Artista, "id", "nombre", pago.artista_id);
            return View(pago);
        }

        // POST: Pagos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,desde,hasta,efectivo,artista_id")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pago).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.artista_id = new SelectList(db.Artista, "id", "nombre", pago.artista_id);
            return View(pago);
        }

        // GET: Pagos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = await db.Pago.FindAsync(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pago pago = await db.Pago.FindAsync(id);
            db.Pago.Remove(pago);
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
