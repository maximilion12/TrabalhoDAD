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
    public class ItensCompraController : ApiController
    {
        private TrabalhoDADEntities contexto = new TrabalhoDADEntities();
        public List<ItensCompra_POCO> Get()
        {
            List<ItensCompra_POCO> retorno = new List<ItensCompra_POCO>();
            contexto.itenscompra.ToList().ForEach(prd => retorno.Add((ItensCompra_POCO)prd));
            return retorno;
        }
        public ItensCompra_POCO Get(int id)
        {
            return (ItensCompra_POCO)contexto.itenscompra.SingleOrDefault(p => p.itc_cod == id);
        }
        public IHttpActionResult Put(int id, ItensCompra_POCO e)
        {
            try
            {
                itenscompra cli = contexto.itenscompra.SingleOrDefault(gen => gen.itc_cod == id);
                if (id == 0 || cli == null)
                {
                    throw new Exception("ID inválido.");

                }
                else
                {
                    cli.itc_qtde = e.qnt_item;
                    cli.itc_valor = e.valor_item;
                    cli.com_cod = e.id_compra;
                    cli.pro_cod = e.id_produto;

                    contexto.SaveChanges();
                    return RedirectToRoute("DefaultApi", new { controller = "itenscompra", id = id });
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post(ItensCompra_POCO produto)
        {
            try
            {
                itenscompra newCat = (itenscompra)produto;
                contexto.itenscompra.Add(newCat);
                contexto.SaveChanges();
                return RedirectToRoute("DefaultApi", new { controller = "itenscompra", id = newCat.itc_cod });

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
                    itenscompra cat = contexto.itenscompra.SingleOrDefault(c => c.itc_cod == id);
                    contexto.itenscompra.Remove(cat);
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
