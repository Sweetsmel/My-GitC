using PadawanProjectGarage.Models;
using PadawanProjectGarage.Models.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PadawanProjectGarage.Controllers
{
    public class ValuesController : ApiController
    {


        private GaragemContext db = new GaragemContext();

        [Route("Api/Values/{TipoVeiculo}/contendo")]
        [HttpGet]
        public IQueryable<Marca> ObtemContendo(int filter)
        {
            return db.Marcas.Where(x => x.tipoVeiculo.TipoVeiculoID == filter);
        }
               
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
