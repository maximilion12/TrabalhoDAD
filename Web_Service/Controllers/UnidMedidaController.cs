using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Service.POCO;
using Web_Service.Models;
using System.Web.Http.Cors;

namespace Web_Service.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class UnidMedidaController : ApiController
    {
        private TrabalhoDADEntities contexto = new TrabalhoDADEntities();
        public List<UndMedida_POCO> Get()
        {
            List<UndMedida_POCO> retorno = new List<UndMedida_POCO>();
            contexto.undmedida.ToList().ForEach(prd => retorno.Add((UndMedida_POCO)prd));
            return retorno;
        }
        public UndMedida_POCO Get(int id)
        {
            return (UndMedida_POCO)contexto.undmedida.SingleOrDefault(p => p.umed_cod == id);
        }
        public IHttpActionResult Put(int id, UndMedida_POCO e)
        {
            try
            {
                undmedida cli = contexto.undmedida.SingleOrDefault(gen => gen.umed_cod == id);
                if (id == 0 || cli == null)
                {
                    throw new Exception("ID inválido.");
                }
                else
                {
                    cli.umed_nome = e.nome;

                    contexto.SaveChanges();
                    return RedirectToRoute("DefaultApi", new { controller = "unidmedida", id = id });
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post(UndMedida_POCO produto)
        {
            try
            {
                undmedida newCat = (undmedida)produto;
                contexto.undmedida.Add(newCat);
                contexto.SaveChanges();
                return RedirectToRoute("DefaultApi", new { controller = "undmedida", id = newCat.umed_cod });

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("ID INVÁLIDO");
                }
                else
                {
                    undmedida cat = contexto.undmedida.SingleOrDefault(c => c.umed_cod == id);
                    contexto.undmedida.Remove(cat);
                    contexto.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}
