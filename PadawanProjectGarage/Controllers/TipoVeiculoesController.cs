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
    public class TipoVeiculoesController : ApiController
    {
        private GaragemContext db = new GaragemContext();

        // GET: api/TipoVeiculoes
        public IQueryable<TipoVeiculo> GetTipoVeiculos()
        {
            return db.TipoVeiculos;
        }

        // GET: api/TipoVeiculoes/5
        [ResponseType(typeof(TipoVeiculo))]
        public IHttpActionResult GetTipoVeiculo(int id)
        {
            TipoVeiculo tipoVeiculo = db.TipoVeiculos.Find(id);
            if (tipoVeiculo == null)
            {
                return NotFound();
            }

            return Ok(tipoVeiculo);
        }

        // PUT: api/TipoVeiculoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoVeiculo(int id, TipoVeiculo tipoVeiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoVeiculo.TipoVeiculoID)
            {
                return BadRequest();
            }

            db.Entry(tipoVeiculo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoVeiculoExists(id))
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

        // POST: api/TipoVeiculoes
        [ResponseType(typeof(TipoVeiculo))]
        public IHttpActionResult PostTipoVeiculo(TipoVeiculo tipoVeiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoVeiculos.Add(tipoVeiculo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoVeiculo.TipoVeiculoID }, tipoVeiculo);
        }

        // DELETE: api/TipoVeiculoes/5
        [ResponseType(typeof(TipoVeiculo))]
        public IHttpActionResult DeleteTipoVeiculo(int id)
        {
            TipoVeiculo tipoVeiculo = db.TipoVeiculos.Find(id);
            if (tipoVeiculo == null)
            {
                return NotFound();
            }

            db.TipoVeiculos.Remove(tipoVeiculo);
            db.SaveChanges();

            return Ok(tipoVeiculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoVeiculoExists(int id)
        {
            return db.TipoVeiculos.Count(e => e.TipoVeiculoID == id) > 0;
        }
    }
}