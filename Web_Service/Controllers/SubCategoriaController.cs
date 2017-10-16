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
    public class SubcategoriaController : ApiController
    {
        private TrabalhoDADEntities contexto = new TrabalhoDADEntities();
        public List<Subcategoria_POCO> Get()
        {
            List<Subcategoria_POCO> retorno = new List<Subcategoria_POCO>();
            contexto.subcategoria.ToList().ForEach(prd => retorno.Add((Subcategoria_POCO)prd));
            return retorno;
        }
        public Subcategoria_POCO Get(int id)
        {
            return (Subcategoria_POCO)contexto.subcategoria.SingleOrDefault(p => p.scat_cod == id);
        }
        public IHttpActionResult Put(int id, Subcategoria_POCO e)
        {
            try
            {
                subcategoria cli = contexto.subcategoria.SingleOrDefault(gen => gen.scat_cod == id);
                if (id == 0 || cli == null)
                {
                    throw new Exception("ID inválido.");

                }
                else
                {
                    cli.scat_nome = e.nome;
                    cli.cat_cod = e.id_categoria;

                    contexto.SaveChanges();
                    return RedirectToRoute("DefaultApi", new { controller = "subcategoria", id = id });
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post(Subcategoria_POCO produto)
        {
            try
            {
                subcategoria newCat = (subcategoria)produto;
                contexto.subcategoria.Add(newCat);
                contexto.SaveChanges();
                return RedirectToRoute("DefaultApi", new { controller = "subcategoria", id = newCat.scat_cod });

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
                    subcategoria cat = contexto.subcategoria.SingleOrDefault(c => c.scat_cod == id);
                    contexto.subcategoria.Remove(cat);
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
