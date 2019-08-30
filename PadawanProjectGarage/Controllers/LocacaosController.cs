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
    public class LocacaosController : ApiController
    {
        private GaragemContext db = new GaragemContext();

        // GET: api/Locacaos
        public IQueryable<Locacao> GetLocacaos()
        {
            return db.Locacaos;     //.Where(x => x.Ativo == true);
        }

        // GET: api/Locacaos/5
        [ResponseType(typeof(Locacao))]
        public IHttpActionResult GetLocacao(int id)
        {
            Locacao locacao = db.Locacaos.Find(id);
            if (locacao == null)
            {
                return NotFound();
            }

            return Ok(locacao);
        }

        // PUT: api/Locacaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLocacao(int id, Locacao locacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locacao.LocacaoID)
            {
                return BadRequest();
            }

            db.Entry(locacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocacaoExists(id))
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

        // POST: api/Locacaos
        [ResponseType(typeof(Locacao))]
        public IHttpActionResult PostLocacao(Locacao locacao)
        {
            if (!ModelState.IsValid)
            {
                if (ModelState.Keys.First().ToString() != "locacao.Id")
                    return BadRequest(ModelState);
            }

            var veiculo = db.TipoVeiculos.FirstOrDefault(x => x.TipoVeiculoID == locacao.Veiculofk);
            var innerTipoVeiculo = from TipoVeiculoTemp in db.TipoVeiculos
                                   join MarcaTemp in db.Marcas on TipoVeiculoTemp.TipoVeiculoID equals MarcaTemp.VeiculoFK
                                   join ModeloTemp in db.Modelos on MarcaTemp.MarcaID equals ModeloTemp.MarcaFK
                                   join VeiculoTemp in db.Locacaos on ModeloTemp.ModeloID equals VeiculoTemp.ModeloFK
                                   where VeiculoTemp.LocacaoID == locacao.Veiculofk
                                   select TipoVeiculoTemp;


            var placaVerify = locacao.Placa;
            var marcaVerify = locacao.marca;
            var ConfirmarTermo = locacao.AceitaTermo;

            if (ConfirmarTermo != true)
            {
                return BadRequest("Certifique de aceitar os termos ");
            }


            if (innerTipoVeiculo.First().Descricao == "Automovel" || innerTipoVeiculo.First().Descricao == "Moto")
            {
                if (marcaVerify == null || placaVerify == null)
                {
                    return BadRequest("A placa ou o modelo são campos obrigatórios para a locação de veículos do tipo CARRO e MOTO.");
                }
            };

            Ok("Sua intenção de locação foi realizada com sucesso! Entraremos em contato para confirmar e seguir com as orientações de acesso");


            db.Locacaos.Add(locacao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = locacao.LocacaoID }, locacao);
        }

        // DELETE: api/Locacaos/5
        [ResponseType(typeof(Locacao))]
        public IHttpActionResult DeleteLocacao(int id)
        {
            Locacao locacao = db.Locacaos.Find(id);
            if (locacao == null)
            {
                return NotFound();
            }

            db.Locacaos.Find(id).Ativo = false;         //(remove).locacao
            db.SaveChanges();

            return Ok(locacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocacaoExists(int id)
        {
            return db.Locacaos.Count(e => e.LocacaoID == id) > 0;
        }
    }
}