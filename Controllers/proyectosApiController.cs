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
    public class proyectosApiController : ApiController
    {
        private Model db = new Model();

        // GET: api/proyectosApi
        public IQueryable<proyectos> Getproyectos()
        {
            return db.proyectos;
        }

        // GET: api/proyectosApi/5
        [ResponseType(typeof(proyectos))]
        public async Task<IHttpActionResult> Getproyectos(int id)
        {
            proyectos proyectos = await db.proyectos.FindAsync(id);
            if (proyectos == null)
            {
                return NotFound();
            }

            return Ok(proyectos);
        }

        // PUT: api/proyectosApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putproyectos(int id, proyectos proyectos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proyectos.id)
            {
                return BadRequest();
            }

            db.Entry(proyectos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!proyectosExists(id))
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

        // POST: api/proyectosApi
        [ResponseType(typeof(proyectos))]
        public async Task<IHttpActionResult> Postproyectos(proyectos proyectos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.proyectos.Add(proyectos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = proyectos.id }, proyectos);
        }

        // DELETE: api/proyectosApi/5
        [ResponseType(typeof(proyectos))]
        public async Task<IHttpActionResult> Deleteproyectos(int id)
        {
            proyectos proyectos = await db.proyectos.FindAsync(id);
            if (proyectos == null)
            {
                return NotFound();
            }

            db.proyectos.Remove(proyectos);
            await db.SaveChangesAsync();

            return Ok(proyectos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool proyectosExists(int id)
        {
            return db.proyectos.Count(e => e.id == id) > 0;
        }
    }
}