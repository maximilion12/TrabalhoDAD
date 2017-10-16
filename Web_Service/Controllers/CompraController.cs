using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Service.POCO;
using Web_Service.Models;

namespace Web_Service.Controllers
{
    public class CompraController : ApiController
    {
        private TrabalhoDADEntities contexto = new TrabalhoDADEntities();
        public List<Compra_POCO> Get()
        {
            List<Compra_POCO> retorno = new List<Compra_POCO>();
            contexto.compra.ToList().ForEach(prd => retorno.Add((Compra_POCO)prd));
            return retorno;
        }
        public Compra_POCO Get(int id)
        {
            return (Compra_POCO)contexto.compra.SingleOrDefault(p => p.com_cod == id);
        }
        public IHttpActionResult Put(int id, Compra_POCO e)
        {
            try
            {
                compra cli = contexto.compra.SingleOrDefault(gen => gen.com_cod == id);
                if (id == 0 || cli == null)
                {
                    throw new Exception("ID inválido.");

                }
                else
                {
                    cli.com_data = e.data;
                    cli.com_nfiscal = null;
                    cli.com_total = e.total;
                    cli.com_nparcelas = null;
                    cli.com_status = e.status;
                    cli.for_cod = e.id_fornecedor;
                    cli.tpa_cod = e.id_tipopagamento;

                    contexto.SaveChanges();
                    return RedirectToRoute("DefaultApi", new { controller = "cliente", id = id });
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post(Compra_POCO produto)
        {
            try
            {
                compra newCat = (compra)produto;
                contexto.compra.Add(newCat);
                contexto.SaveChanges();
                return RedirectToRoute("DefaultApi", new { controller = "compra", id = newCat.com_cod });

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
                    compra cat = contexto.compra.SingleOrDefault(c => c.com_cod == id);
                    contexto.compra.Remove(cat);
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
