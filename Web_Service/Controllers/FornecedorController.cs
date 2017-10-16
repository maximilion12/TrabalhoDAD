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
    public class FornecedorController : ApiController
    {
        private TrabalhoDADEntities contexto = new TrabalhoDADEntities();
        public List<Fornecedor_POCO> Get()
        {
            List<Fornecedor_POCO> retorno = new List<Fornecedor_POCO>();
            contexto.fornecedor.ToList().ForEach(prd => retorno.Add((Fornecedor_POCO)prd));
            return retorno;
        }
        public Fornecedor_POCO Get(int id)
        {
            return (Fornecedor_POCO)contexto.fornecedor.SingleOrDefault(p => p.for_cod == id);
        }
        public IHttpActionResult Put(int id, Fornecedor_POCO e)
        {
            try
            {
                fornecedor cli = contexto.fornecedor.SingleOrDefault(gen => gen.for_cod == id);
                if (id == 0 || cli == null)
                {
                    throw new Exception("ID inválido.");

                }
                else
                {
                    cli.for_nome = e.nome;
                    cli.for_cnpj = e.cnpj;
                    cli.for_ie = e.ie;
                    cli.for_rsocial = null;
                    cli.for_cep = e.cep;
                    cli.for_endereco = e.endereco;
                    cli.for_bairro = e.bairro;
                    cli.for_fone = e.fone;
                    cli.for_cel = e.cel;
                    cli.for_email = e.email;
                    cli.for_endnumero = null;
                    cli.for_cidade = e.cidade;
                    cli.for_estado = e.estado;

                    contexto.SaveChanges();
                    return RedirectToRoute("DefaultApi", new { controller = "fornecedor", id = id });
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post(Fornecedor_POCO produto)
        {
            try
            {
                fornecedor newCat = (fornecedor)produto;
                contexto.fornecedor.Add(newCat);
                contexto.SaveChanges();
                return RedirectToRoute("DefaultApi", new { controller = "fornecedor", id = newCat.for_cod });

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
                    fornecedor cat = contexto.fornecedor.SingleOrDefault(c => c.for_cod == id);
                    contexto.fornecedor.Remove(cat);
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
