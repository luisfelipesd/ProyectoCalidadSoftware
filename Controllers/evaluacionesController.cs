using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class evaluacionesController : Controller
    {
        private Model db = new Model();

        // GET: evaluaciones
        public async Task<ActionResult> Index()
        {
            var evaluaciones = db.evaluaciones.Include(e => e.categorias).Include(e => e.proyectos);
            return View(await evaluaciones.ToListAsync());
        }

        // GET: evaluaciones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evaluaciones evaluaciones = await db.evaluaciones.FindAsync(id);
            if (evaluaciones == null)
            {
                return HttpNotFound();
            }
            return View(evaluaciones);
        }

        // GET: evaluaciones/Create
        public ActionResult Create()
        {
            ViewBag.categorias_id = new SelectList(db.categorias, "id", "nombre");
            ViewBag.proyectos_id = new SelectList(db.proyectos, "id", "nombre");
            return View();
        }
        public async Task<ActionResult> CreateForm(int? id, int? proyecto,string formula)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.formula = formula;
            evaluaciones evaluaciones = db.evaluaciones.Where(c => c.proyectos_id == proyecto).Where(c => c.categorias_id == id).FirstOrDefault();                     
            if (evaluaciones == null)
            {
                ViewBag.categorias_id = new SelectList(db.categorias, "id", "nombre",id);
                ViewBag.proyectos_id = new SelectList(db.proyectos, "id", "nombre",proyecto);                
                return PartialView("_Create");
            }
            else {
                ViewBag.categorias_id = new SelectList(db.categorias, "id", "nombre", evaluaciones.categorias_id);
                ViewBag.proyectos_id = new SelectList(db.proyectos, "id", "nombre", evaluaciones.proyectos_id);
            }
            return PartialView("_Create", evaluaciones);
        }

        // POST: evaluaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,proyectos_id,categorias_id,a,b,c,resultado,fecha")] evaluaciones evaluaciones)
        {
            if (ModelState.IsValid)
            {
                if (db.evaluaciones.Any(c => c.proyectos_id == evaluaciones.proyectos_id && c.categorias_id == evaluaciones.categorias_id))
                {
                    var id = db.evaluaciones.Where(x => x.categorias_id == evaluaciones.categorias_id && x.proyectos_id == evaluaciones.proyectos_id).Select(x => x.id).FirstOrDefault();
                    evaluaciones.id = id;
                    db.Entry(evaluaciones).State = EntityState.Modified;
                }else
                db.evaluaciones.Add(evaluaciones);                                    
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.categorias_id = new SelectList(db.categorias, "id", "nombre", evaluaciones.categorias_id);
            ViewBag.proyectos_id = new SelectList(db.proyectos, "id", "nombre", evaluaciones.proyectos_id);
            return View(evaluaciones);
        }

        // GET: evaluaciones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evaluaciones evaluaciones = await db.evaluaciones.FindAsync(id);
            if (evaluaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.categorias_id = new SelectList(db.categorias, "id", "nombre", evaluaciones.categorias_id);
            ViewBag.proyectos_id = new SelectList(db.proyectos, "id", "nombre", evaluaciones.proyectos_id);
            return View(evaluaciones);
        }

        // POST: evaluaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,proyectos_id,categorias_id,a,b,c,resultado,fecha")] evaluaciones evaluaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluaciones).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.categorias_id = new SelectList(db.categorias, "id", "nombre", evaluaciones.categorias_id);
            ViewBag.proyectos_id = new SelectList(db.proyectos, "id", "nombre", evaluaciones.proyectos_id);
            return View(evaluaciones);
        }

        // GET: evaluaciones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evaluaciones evaluaciones = await db.evaluaciones.FindAsync(id);
            if (evaluaciones == null)
            {
                return HttpNotFound();
            }
            return View(evaluaciones);
        }

        // POST: evaluaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            evaluaciones evaluaciones = await db.evaluaciones.FindAsync(id);
            db.evaluaciones.Remove(evaluaciones);
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
