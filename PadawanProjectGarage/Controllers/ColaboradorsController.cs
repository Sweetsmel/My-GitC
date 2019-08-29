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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using PadawanProjectGarage.Models;
using PadawanProjectGarage.Models.Sistema;

namespace PadawanProjectGarage.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ColaboradorsController : ApiController
    {
        private readonly GaragemContext db = new GaragemContext();

        // GET: api/Colaboradors
        public IQueryable<Colaborador> GetColaboradors()
        {
            return db.Colaboradors;//.Where(x => x.Ativo == true);
        }

        // GET: api/Colaboradors/5
        [ResponseType(typeof(Colaborador))]
        public IHttpActionResult GetColaborador(int id)
        {
            Colaborador colaborador = db.Colaboradors.Find(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return Ok(colaborador);
        }

        // PUT: api/Colaboradors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutColaborador(int id, Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colaborador.ColaboradorId)
            {
                return BadRequest();
            }

            db.Entry(colaborador).State = EntityState.Modified;

            try
            {
                db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaboradorExists(id))
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

        // POST: api/Colaboradors
        [ResponseType(typeof(Colaborador))]
        public IHttpActionResult PostColaborador(Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                if (ModelState.Keys.First().ToString() != "colaborador.Id")
                    return BadRequest(ModelState);
            }

            db.Colaboradors.Add(colaborador);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = colaborador.ColaboradorId }, colaborador);
        }

        // DELETE: api/Colaboradors/5
        [ResponseType(typeof(Colaborador))]
        public IHttpActionResult DeleteColaborador(int id)
        {
            Colaborador colaborador = db.Colaboradors.Find(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            colaborador.Ativo = false;
            db.SaveChanges();

            return Ok(colaborador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColaboradorExists(int id)
        {
            return db.Colaboradors.Count(e => e.ColaboradorId == id) > 0;
        }
    }
}