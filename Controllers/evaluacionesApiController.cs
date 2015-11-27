using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class evaluacionesApiController : ApiController
    {
        private Model db = new Model();

        // GET: api/evaluacionesApi
        public IQueryable<evaluaciones> Getevaluaciones()
        {
            return db.evaluaciones;
        }

        // GET: api/evaluacionesApi/5
        [ResponseType(typeof(evaluaciones))]
        public async Task<IHttpActionResult> Getevaluaciones(int id)
        {
            evaluaciones evaluaciones = await db.evaluaciones.FindAsync(id);
            if (evaluaciones == null)
            {
                return NotFound();
            }

            return Ok(evaluaciones);
        }

        // PUT: api/evaluacionesApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putevaluaciones(int id, evaluaciones evaluaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evaluaciones.id)
            {
                return BadRequest();
            }

            db.Entry(evaluaciones).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!evaluacionesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/evaluacionesApi
        [ResponseType(typeof(evaluaciones))]
        public async Task<IHttpActionResult> Postevaluaciones(evaluaciones evaluaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.evaluaciones.Add(evaluaciones);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (evaluacionesExists(evaluaciones.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = evaluaciones.id }, evaluaciones);
        }

        // DELETE: api/evaluacionesApi/5
        [ResponseType(typeof(evaluaciones))]
        public async Task<IHttpActionResult> Deleteevaluaciones(int id)
        {
            evaluaciones evaluaciones = await db.evaluaciones.FindAsync(id);
            if (evaluaciones == null)
            {
                return NotFound();
            }

            db.evaluaciones.Remove(evaluaciones);
            await db.SaveChangesAsync();

            return Ok(evaluaciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool evaluacionesExists(int id)
        {
            return db.evaluaciones.Count(e => e.id == id) > 0;
        }
    }
}