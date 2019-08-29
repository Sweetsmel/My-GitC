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
    public class PeriodoLocacaosController : ApiController
    {
        private GaragemContext db = new GaragemContext();

        // GET: api/PeriodoLocacaos
        public IQueryable<PeriodoLocacao> GetPeriodoLocacaos()
        {
            return db.PeriodoLocacaos;
        }

        // GET: api/PeriodoLocacaos/5
        [ResponseType(typeof(PeriodoLocacao))]
        public IHttpActionResult GetPeriodoLocacao(int id)
        {
            PeriodoLocacao periodoLocacao = db.PeriodoLocacaos.Find(id);
            if (periodoLocacao == null)
            {
                return NotFound();
            }

            return Ok(periodoLocacao);
        }

        // PUT: api/PeriodoLocacaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPeriodoLocacao(int id, PeriodoLocacao periodoLocacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != periodoLocacao.PeriodoID)
            {
                return BadRequest();
            }

            db.Entry(periodoLocacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodoLocacaoExists(id))
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

        // POST: api/PeriodoLocacaos
        [ResponseType(typeof(PeriodoLocacao))]
        public IHttpActionResult PostPeriodoLocacao(PeriodoLocacao periodoLocacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PeriodoLocacaos.Add(periodoLocacao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = periodoLocacao.PeriodoID }, periodoLocacao);
        }

        // DELETE: api/PeriodoLocacaos/5
        [ResponseType(typeof(PeriodoLocacao))]
        public IHttpActionResult DeletePeriodoLocacao(int id)
        {
            PeriodoLocacao periodoLocacao = db.PeriodoLocacaos.Find(id);
            if (periodoLocacao == null)
            {
                return NotFound();
            }

            db.PeriodoLocacaos.Remove(periodoLocacao);
            db.SaveChanges();

            return Ok(periodoLocacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeriodoLocacaoExists(int id)
        {
            return db.PeriodoLocacaos.Count(e => e.PeriodoID == id) > 0;
        }
    }
}