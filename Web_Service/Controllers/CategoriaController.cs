using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Service.POCO;
using Web_Service.Models;
using System.Data.Entity;

namespace Web_Service.Controllers
{
    public class CategoriaController : ApiController
    {
        private TrabalhoDADEntities contexto = new TrabalhoDADEntities();
        public List<Categoria_POCO> Get()
        {
            List<Categoria_POCO> retorno = new List<Categoria_POCO>();
            contexto.categoria.ToList().ForEach(prd => retorno.Add((Categoria_POCO)prd));
            return retorno;
        }
        public Categoria_POCO Get(int id)
        {
            return (Categoria_POCO)contexto.categoria.SingleOrDefault(p => p.cat_cod == id);
        }
        public IHttpActionResult Put(int id, Categoria_POCO produto)
        {       
            try
            {
                categoria cat = contexto.categoria.SingleOrDefault(gen => gen.cat_cod == id);
                cat.cat_nome = produto.nome;
                contexto.SaveChanges();
                return RedirectToRoute("DefaultApi", new { controller = "Categoria", id = id });
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Post(Produto_POCO produto)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(produto.nome))
                {
                    throw new Exception("Nome inválido.");
                }
                else
                {
                    categoria newCat = new categoria();
                    newCat.cat_nome = produto.nome;
                    contexto.categoria.Add(newCat);
                    contexto.SaveChanges();
                    return RedirectToRoute("DefaultApi",new {controller = "Categoria", id= newCat.cat_cod});

                }
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
                    categoria cat = contexto.categoria.SingleOrDefault(c => c.cat_cod == id);
                    contexto.categoria.Remove(cat);
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
