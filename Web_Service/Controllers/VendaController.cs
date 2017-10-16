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
    public class VendaController : ApiController
    {
        private TrabalhoDADEntities contexto = new TrabalhoDADEntities();
        public List<Venda_POCO> Get()
        {
            List<Venda_POCO> retorno = new List<Venda_POCO>();
            contexto.venda.ToList().ForEach(prd => retorno.Add((Venda_POCO)prd));
            return retorno;
        }
        public Venda_POCO Get(int id)
        {
            return (Venda_POCO)contexto.venda.SingleOrDefault(p => p.ven_cod == id);
        }
        public IHttpActionResult Put(int id, Venda_POCO e)
        {
            try
            {
                venda cli = contexto.venda.SingleOrDefault(gen => gen.ven_cod == id);
                if (id == 0 || cli == null)
                {
                    throw new Exception("ID inválido.");

                }
                else
                {
                    cli.ven_data = e.data;
                    cli.ven_total = e.vlr_total;
                    cli.ven_status = e.status;
                    cli.cli_cod = e.id_cliente;
                    cli.tpa_cod = e.id_tipopagamento;

                    contexto.SaveChanges();
                    return RedirectToRoute("DefaultApi", new { controller = "venda", id = id });
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post(Venda_POCO produto)
        {
            try
            {
                venda newCat = (venda)produto;
                contexto.venda.Add(newCat);
                contexto.SaveChanges();
                return RedirectToRoute("DefaultApi", new { controller = "venda", id = newCat.ven_cod });

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
                    venda cat = contexto.venda.SingleOrDefault(c => c.ven_cod == id);
                    contexto.venda.Remove(cat);
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
