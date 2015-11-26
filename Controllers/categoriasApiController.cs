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
    public class categoriasApiController : ApiController
    {
        private Model db = new Model();

        // GET: api/categoriasApi
        public IQueryable<categorias> Getcategorias()
        {
            return db.categorias;
        }

        // GET: api/categoriasApi/5
        [ResponseType(typeof(categorias))]
        public async Task<IHttpActionResult> Getcategorias(int id)
        {
            categorias categorias = await db.categorias.FindAsync(id);
            if (categorias == null)
            {
                return NotFound();
            }

            return Ok(categorias);
        }

        // PUT: api/categoriasApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcategorias(int id, categorias categorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categorias.id)
            {
                return BadRequest();
            }

            db.Entry(categorias).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoriasExists(id))
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

        // POST: api/categoriasApi
        [ResponseType(typeof(categorias))]
        public async Task<IHttpActionResult> Postcategorias(categorias categorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.categorias.Add(categorias);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categorias.id }, categorias);
        }

        // DELETE: api/categoriasApi/5
        [ResponseType(typeof(categorias))]
        public async Task<IHttpActionResult> Deletecategorias(int id)
        {
            categorias categorias = await db.categorias.FindAsync(id);
            if (categorias == null)
            {
                return NotFound();
            }

            db.categorias.Remove(categorias);
            await db.SaveChangesAsync();

            return Ok(categorias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool categoriasExists(int id)
        {
            return db.categorias.Count(e => e.id == id) > 0;
        }
    }
}