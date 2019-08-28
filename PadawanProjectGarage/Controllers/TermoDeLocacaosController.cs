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
using PadawanProjectGarage.Models.Sistema;
using PadawanProjectGarage.Models.Usuarios;

namespace PadawanProjectGarage.Controllers
{
    public class TermoDeLocacaosController : ApiController
    {
        private GaragemContext db = new GaragemContext();

        // GET: api/TermoDeLocacaos
        public IQueryable<TermoDeLocacao> GetTermoDeLocacaos()
        {
            return db.TermoDeLocacaos;
        }

        // GET: api/TermoDeLocacaos/5
        [ResponseType(typeof(TermoDeLocacao))]
        public async Task<IHttpActionResult> GetTermoDeLocacao(int id)
        {
            TermoDeLocacao termoDeLocacao = await db.TermoDeLocacaos.FindAsync(id);
            if (termoDeLocacao == null)
            {
                return NotFound();
            }

            return Ok(termoDeLocacao);
        }

        // PUT: api/TermoDeLocacaos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTermoDeLocacao(int id, TermoDeLocacao termoDeLocacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != termoDeLocacao.TermoID)
            {
                return BadRequest();
            }

            db.Entry(termoDeLocacao).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TermoDeLocacaoExists(id))
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

        // POST: api/TermoDeLocacaos
        [ResponseType(typeof(TermoDeLocacao))]
        public async Task<IHttpActionResult> PostTermoDeLocacao(TermoDeLocacao termoDeLocacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TermoDeLocacaos.Add(termoDeLocacao);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = termoDeLocacao.TermoID }, termoDeLocacao);
        }

        // DELETE: api/TermoDeLocacaos/5
        [ResponseType(typeof(TermoDeLocacao))]
        public async Task<IHttpActionResult> DeleteTermoDeLocacao(int id)
        {
            TermoDeLocacao termoDeLocacao = await db.TermoDeLocacaos.FindAsync(id);
            if (termoDeLocacao == null)
            {
                return NotFound();
            }

            db.TermoDeLocacaos.Remove(termoDeLocacao);
            await db.SaveChangesAsync();

            return Ok(termoDeLocacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TermoDeLocacaoExists(int id)
        {
            return db.TermoDeLocacaos.Count(e => e.TermoID == id) > 0;
        }
    }
}