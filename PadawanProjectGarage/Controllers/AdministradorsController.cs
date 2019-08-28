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
        private GaragemContext db = new GaragemContext();

        // GET: api/Administradors
        public IQueryable<Administrador> GetAdministradors()
        {
            return db.Administradors;
        }

        // GET: api/Administradors/5
        [ResponseType(typeof(Administrador))]
        public async Task<IHttpActionResult> GetAdministrador(int id)
        {
            Administrador administrador = await db.Administradors.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }

            return Ok(administrador);
        }

        // PUT: api/Administradors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdministrador(int id, Administrador administrador)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostAdministrador(Administrador administrador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Administradors.Add(administrador);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = administrador.AdministradorId }, administrador);
        }

        // DELETE: api/Administradors/5
        [ResponseType(typeof(Administrador))]
        public async Task<IHttpActionResult> DeleteAdministrador(int id)
        {
            Administrador administrador = await db.Administradors.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }

            db.Administradors.Remove(administrador);
            await db.SaveChangesAsync();

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