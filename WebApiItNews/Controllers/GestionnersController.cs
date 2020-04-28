using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiItNews.Data;

namespace WebApiItNews.Controllers
{
    public class GestionnersController : ApiController
    {
        private NewsEntities db = new NewsEntities();

        // GET: api/Gestionners
        public IQueryable<Gestionner> GetGestionner()
        {
            return db.Gestionner;
        }

        // GET: api/Gestionners/5
        [ResponseType(typeof(Gestionner))]
        public IHttpActionResult GetGestionner(int id)
        {
            Gestionner gestionner = db.Gestionner.Find(id);
            if (gestionner == null)
            {
                return NotFound();
            }

            return Ok(gestionner);
        }

        // PUT: api/Gestionners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGestionner(int id, Gestionner gestionner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gestionner.ID)
            {
                return BadRequest();
            }

            db.Entry(gestionner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GestionnerExists(id))
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

        // POST: api/Gestionners
        [ResponseType(typeof(Gestionner))]
        public IHttpActionResult PostGestionner(Gestionner gestionner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gestionner.Add(gestionner);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gestionner.ID }, gestionner);
        }

        // DELETE: api/Gestionners/5
        [ResponseType(typeof(Gestionner))]
        public IHttpActionResult DeleteGestionner(int id)
        {
            Gestionner gestionner = db.Gestionner.Find(id);
            if (gestionner == null)
            {
                return NotFound();
            }

            db.Gestionner.Remove(gestionner);
            db.SaveChanges();

            return Ok(gestionner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GestionnerExists(int id)
        {
            return db.Gestionner.Count(e => e.ID == id) > 0;
        }
    }
}