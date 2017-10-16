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
    public class ItensVendaController : ApiController
    {
        private TrabalhoDADEntities contexto = new TrabalhoDADEntities();
        public List<ItensVenda_POCO> Get()
        {
            List<ItensVenda_POCO> retorno = new List<ItensVenda_POCO>();
            contexto.itensvenda.ToList().ForEach(prd => retorno.Add((ItensVenda_POCO)prd));
            return retorno;
        }
        public ItensVenda_POCO Get(int id)
        {
            return (ItensVenda_POCO)contexto.itensvenda.SingleOrDefault(p => p.itv_cod == id);
        }
        public IHttpActionResult Put(int id, ItensVenda_POCO e)
        {
            try
            {
                itensvenda cli = contexto.itensvenda.SingleOrDefault(gen => gen.itv_cod == id);
                if (id == 0 || cli == null)
                {
                    throw new Exception("ID inválido.");

                }
                else
                {
                    cli.itv_qtde = e.qnt_item;
                    cli.itv_valor = e.valor_item;
                    cli.ven_cod = e.id_compra;
                    cli.pro_cod = e.id_produto;

                    contexto.SaveChanges();
                    return RedirectToRoute("DefaultApi", new { controller = "itensvenda", id = id });
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post(ItensVenda_POCO produto)
        {
            try
            {
                itensvenda newCat = (itensvenda)produto;
                contexto.itensvenda.Add(newCat);
                contexto.SaveChanges();
                return RedirectToRoute("DefaultApi", new { controller = "itensvenda", id = newCat.itv_cod });

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
                    itensvenda cat = contexto.itensvenda.SingleOrDefault(c => c.itv_cod == id);
                    contexto.itensvenda.Remove(cat);
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
