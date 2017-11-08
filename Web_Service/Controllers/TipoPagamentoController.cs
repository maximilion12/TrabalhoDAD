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
    public class TipoPagamentoController : ApiController
    {
        private TrabalhoDADEntities contexto = new TrabalhoDADEntities();
        public List<TipoPagamento_POCO> Get()
        {
            List<TipoPagamento_POCO> retorno = new List<TipoPagamento_POCO>();
            contexto.tipopagamento.ToList().ForEach(prd => retorno.Add((TipoPagamento_POCO)prd));
            return retorno;
        }
        public TipoPagamento_POCO Get(int id)
        {
            return (TipoPagamento_POCO)contexto.tipopagamento.SingleOrDefault(p => p.tpa_cod == id);
        }
        public IHttpActionResult Put(int id, TipoPagamento_POCO e)
        {
            try
            {
                tipopagamento cli = contexto.tipopagamento.SingleOrDefault(gen => gen.tpa_cod == id);
                if (id == 0 || cli == null)
                {
                    throw new Exception("ID inválido.");

                }
                else
                {
                    cli.tpa_nome = e.nome;

                    contexto.SaveChanges();
                    return RedirectToRoute("DefaultApi", new { controller = "tipopagamento", id = id });
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post(TipoPagamento_POCO produto)
        {
            try
            {
                tipopagamento newCat = (tipopagamento)produto;
                contexto.tipopagamento.Add(newCat);
                contexto.SaveChanges();
                return RedirectToRoute("DefaultApi", new { controller = "tipopagamento", id = newCat.tpa_cod });

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
                    tipopagamento cat = contexto.tipopagamento.SingleOrDefault(c => c.tpa_cod == id);
                    contexto.tipopagamento.Remove(cat);
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
