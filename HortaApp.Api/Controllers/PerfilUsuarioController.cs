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
using HortaApp.Api.Models;
using HortaApp.Domain;

namespace HortaApp.Api.Controllers
{
    public class PerfilUsuarioController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PerfilUsuario
        public IQueryable<PerfilUsuario> GetPerfilUsuario()
        {
            return db.PerfilUsuario;
        }

        // GET: api/PerfilUsuario/5
        [ResponseType(typeof(PerfilUsuario))]
        public IHttpActionResult GetPerfilUsuario(int id)
        {
            PerfilUsuario perfilUsuario = db.PerfilUsuario.Find(id);
            if (perfilUsuario == null)
            {
                return NotFound();
            }

            return Ok(perfilUsuario);
        }

        // PUT: api/PerfilUsuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerfilUsuario(int id, PerfilUsuario perfilUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfilUsuario.PerfilUsuarioId)
            {
                return BadRequest();
            }

            db.Entry(perfilUsuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilUsuarioExists(id))
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

        // POST: api/PerfilUsuario
        [ResponseType(typeof(PerfilUsuario))]
        public IHttpActionResult PostPerfilUsuario(PerfilUsuario perfilUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PerfilUsuario.Add(perfilUsuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = perfilUsuario.PerfilUsuarioId }, perfilUsuario);
        }

        // DELETE: api/PerfilUsuario/5
        [ResponseType(typeof(PerfilUsuario))]
        public IHttpActionResult DeletePerfilUsuario(int id)
        {
            PerfilUsuario perfilUsuario = db.PerfilUsuario.Find(id);
            if (perfilUsuario == null)
            {
                return NotFound();
            }

            db.PerfilUsuario.Remove(perfilUsuario);
            db.SaveChanges();

            return Ok(perfilUsuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerfilUsuarioExists(int id)
        {
            return db.PerfilUsuario.Count(e => e.PerfilUsuarioId == id) > 0;
        }
    }
}