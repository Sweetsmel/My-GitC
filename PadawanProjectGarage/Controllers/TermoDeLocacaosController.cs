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
using PadawanProjectGarage.Models.Sistema;
using PadawanProjectGarage.Models.Usuarios;

namespace PadawanProjectGarage.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        public IHttpActionResult GetTermoDeLocacao(int id)  //ALTERADO
        {
            TermoDeLocacao termoDeLocacao = db.TermoDeLocacaos.Find(id);
            if (termoDeLocacao == null)
            {
                return NotFound();
            }

            return Ok(termoDeLocacao);
        }

        // PUT: api/TermoDeLocacaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTermoDeLocacao(int id, TermoDeLocacao termoDeLocacao)   //ALTERADO. Pega
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
                db.SaveChanges();          //ALTERADO
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
        public IHttpActionResult PostTermoDeLocacao(TermoDeLocacao termoDeLocacao)    //ALTERADO. Insere
        {
            if (!ModelState.IsValid)
            {
                if (ModelState.Keys.First().ToString() != "termoDeLocacao.Id")      //ADICIONADO
                    return BadRequest(ModelState);
            }

            var termo = db.TermoDeLocacaos.FirstOrDefault(x => x.Vigente == true);
            if (termo != null)
                termo.Vigente = false;

            db.TermoDeLocacaos.Add(termoDeLocacao);
            db.SaveChanges();                      //ALTERADO

            return CreatedAtRoute("DefaultApi", new { id = termoDeLocacao.TermoID }, termoDeLocacao);
        }

        // DELETE: api/TermoDeLocacaos/5
        [ResponseType(typeof(TermoDeLocacao))]
        public IHttpActionResult DeleteTermoDeLocacao(int id)   //ALTERADO
        {
            TermoDeLocacao termoDeLocacao = db.TermoDeLocacaos.Find(id); //ALTERADO
            if (termoDeLocacao == null)
            {
                return NotFound();
            }

            db.TermoDeLocacaos.Remove(termoDeLocacao);
            db.SaveChanges();      //ALTERADO

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