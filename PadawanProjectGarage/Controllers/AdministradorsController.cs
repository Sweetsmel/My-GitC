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
using PadawanProjectGarage.Models;
using PadawanProjectGarage.Models.Sistema;

namespace PadawanProjectGarage.Controllers
{
    public class AdministradorsController : ApiController
    {
        private readonly GaragemContext db = new GaragemContext();

        // GET: api/Administradors
        public IQueryable<Administrador> GetAdministradors()
        {
            return db.Administradors;
        }

        // GET: api/Administradors/5
        [ResponseType(typeof(Administrador))]
        public IHttpActionResult GetAdministrador(int id)
        {
            Administrador administrador = db.Administradors.Find(id);
            if (administrador == null)
            {
                return NotFound();
            }

            return Ok(administrador);
        }

        // PUT: api/Administradors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdministrador(int id, Administrador administrador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administrador.AdministradorId)
            {
                return BadRequest();
            }

            db.Entry(administrador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
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

        // POST: api/Administradors
        [ResponseType(typeof(Administrador))]
        public IHttpActionResult PostAdministrador(Administrador administrador)
        {
            if (!ModelState.IsValid)
            {
                if (ModelState.Keys.First().ToString() != "administrador.Id")
                    return BadRequest(ModelState);
            }

            db.Administradors.Add(administrador);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = administrador.AdministradorId }, administrador);
        }

        // DELETE: api/Administradors/5
        [ResponseType(typeof(Administrador))]
        public IHttpActionResult DeleteAdministrador(int id)
        {
            Administrador administrador = db.Administradors.Find(id);
            if (administrador == null)
            {
                return NotFound();
            }

            administrador.Ativo = false;
            db.SaveChanges();

            return Ok(administrador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministradorExists(int id)
        {
            return db.Administradors.Count(e => e.AdministradorId == id) > 0;
        }
    }
}