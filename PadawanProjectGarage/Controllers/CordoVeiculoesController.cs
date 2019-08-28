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
    public class CordoVeiculoesController : ApiController
    {
        private GaragemContext db = new GaragemContext();

        // GET: api/CordoVeiculoes
        public IQueryable<CordoVeiculo> GetCordoVeiculoes()
        {
            return db.CordoVeiculoes;
        }

        // GET: api/CordoVeiculoes/5
        [ResponseType(typeof(CordoVeiculo))]
        public async Task<IHttpActionResult> GetCordoVeiculo(int id)
        {
            CordoVeiculo cordoVeiculo = await db.CordoVeiculoes.FindAsync(id);
            if (cordoVeiculo == null)
            {
                return NotFound();
            }

            return Ok(cordoVeiculo);
        }

        // PUT: api/CordoVeiculoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCordoVeiculo(int id, CordoVeiculo cordoVeiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cordoVeiculo.CorId)
            {
                return BadRequest();
            }

            db.Entry(cordoVeiculo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CordoVeiculoExists(id))
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

        // POST: api/CordoVeiculoes
        [ResponseType(typeof(CordoVeiculo))]
        public async Task<IHttpActionResult> PostCordoVeiculo(CordoVeiculo cordoVeiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CordoVeiculoes.Add(cordoVeiculo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cordoVeiculo.CorId }, cordoVeiculo);
        }

        // DELETE: api/CordoVeiculoes/5
        [ResponseType(typeof(CordoVeiculo))]
        public async Task<IHttpActionResult> DeleteCordoVeiculo(int id)
        {
            CordoVeiculo cordoVeiculo = await db.CordoVeiculoes.FindAsync(id);
            if (cordoVeiculo == null)
            {
                return NotFound();
            }

            db.CordoVeiculoes.Remove(cordoVeiculo);
            await db.SaveChangesAsync();

            return Ok(cordoVeiculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CordoVeiculoExists(int id)
        {
            return db.CordoVeiculoes.Count(e => e.CorId == id) > 0;
        }
    }
}