using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using HortaApp.Api.Models;
using HortaApp.Domain;

namespace HortaApp.Api.Controllers
{
    public class PostagemController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Postagem
        public IQueryable<Postagem> GetPostagem()
        {
            return db.Postagem.OrderByDescending(p=>p.PostagemId);
        }

        // GET: api/Postagem/5
        [ResponseType(typeof(Postagem))]
        public IHttpActionResult GetPostagem(int id)
        {
            Postagem postagem = db.Postagem.Find(id);
            if (postagem == null)
            {
                return NotFound();
            }

            return Ok(postagem);
        }

        // PUT: api/Postagem/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPostagem(int id, Postagem postagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postagem.PostagemId)
            {
                return BadRequest();
            }

            db.Entry(postagem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostagemExists(id))
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

        // POST: api/Postagem
        [ResponseType(typeof(Postagem))]
        public IHttpActionResult PostPostagem(Postagem postagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Postagem.Add(postagem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = postagem.PostagemId }, postagem);
        }

        // DELETE: api/Postagem/5
        [ResponseType(typeof(Postagem))]
        public IHttpActionResult DeletePostagem(int id)
        {
            Postagem postagem = db.Postagem.Find(id);
            if (postagem == null)
            {
                return NotFound();
            }

            db.Postagem.Remove(postagem);
            db.SaveChanges();

            return Ok(postagem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostagemExists(int id)
        {
            return db.Postagem.Count(e => e.PostagemId == id) > 0;
        }
    }
}