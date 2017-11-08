using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Web_Service.Models;
using Web_Service.POCO;

namespace Web_Service.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class ProdutoController : ApiController
    {
        private TrabalhoDADEntities contexto = new TrabalhoDADEntities();
        public List<Produto_POCO> Get()
        {
            List<Produto_POCO> retorno = new List<Produto_POCO>();
            contexto.produto.ToList().ForEach(prd => retorno.Add((Produto_POCO)prd));
            return retorno;
        }
        public Produto_POCO Get(int id)
        {
            return (Produto_POCO)contexto.produto.SingleOrDefault(p => p.pro_cod == id);
        }
        public IHttpActionResult Put(int id, Produto_POCO e)
        {
            try
            {
                produto cli = contexto.produto.SingleOrDefault(gen => gen.pro_cod == id);
                if (id == 0 || cli == null)
                {
                    throw new Exception("ID inválido.");

                }
                else
                {
                    cli.pro_nome = e.nome;
                    cli.pro_descricao = e.descricao;
                    cli.pro_valorpago = e.valorpago;
                    cli.pro_valorvenda = e.valorvenda;
                    cli.pro_qtde = e.qtde;
                    cli.umed_cod = e.id_unidmedida;
                    cli.cat_cod = e.id_categoria;
                    cli.scat_cod = e.id_subcategoria;

                    contexto.SaveChanges();
                    return RedirectToRoute("DefaultApi", new { controller = "produto", id = id });
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post(Produto_POCO produto)
        {
            try
            {
                produto newCat = (produto)produto;
                contexto.produto.Add(newCat);
                contexto.SaveChanges();
                return RedirectToRoute("DefaultApi", new { controller = "produto", id = newCat.pro_cod });

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
                    produto cat = contexto.produto.SingleOrDefault(c => c.pro_cod == id);
                    contexto.produto.Remove(cat);
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
