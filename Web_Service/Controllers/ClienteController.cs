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
    public class ClienteController : ApiController
    {
        private TrabalhoDADEntities contexto = new TrabalhoDADEntities();
        public List<Cliente_POCO> Get()
        {
            List<Cliente_POCO> retorno = new List<Cliente_POCO>();
            contexto.cliente.ToList().ForEach(prd => retorno.Add((Cliente_POCO)prd));
            return retorno;
        }
        public Cliente_POCO Get(int id)
        {
            return (Cliente_POCO)contexto.cliente.SingleOrDefault(p => p.cli_cod == id);
        }
        public IHttpActionResult Put(int id, Cliente_POCO produto)
        {
            try
            {
                cliente cli = contexto.cliente.SingleOrDefault(gen => gen.cli_cod == id);
                if (id == 0 || cli == null)
                    {
                        throw new Exception("ID inválido.");

                    }
                    else
                    {                        
                        cli.cli_nome = produto.nome;
                        cli.cli_cpfcnpj = produto.cpf_cnpj;
                        cli.cli_rgie = produto.rg_ie;
                        cli.cli_rsocial = null;
                        cli.cli_tipo = produto.tipo;
                        cli.cli_cep = produto.cep;
                        cli.cli_endereco = produto.endereco;
                        cli.cli_bairro = produto.bairro;
                        cli.cli_fone = produto.fone;
                        cli.cli_cel = produto.cel;
                        cli.cli_email = produto.email;
                        cli.cli_endnumero = null;
                        cli.cli_cidade = produto.cidade;
                        cli.cli_estado = produto.estado;
                        contexto.SaveChanges();
                        return RedirectToRoute("DefaultApi", new { controller = "cliente", id = id });
                    }                
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post(Cliente_POCO produto)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(produto.nome))
                {
                    throw new Exception("Nome inválido.");
                }
                else
                {
                    cliente newCat = (cliente)produto;
                    contexto.cliente.Add(newCat);
                    contexto.SaveChanges();
                    return RedirectToRoute("DefaultApi", new { controller = "cliente", id = newCat.cli_cod });

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
                    cliente cat = contexto.cliente.SingleOrDefault(c => c.cli_cod == id);
                    contexto.cliente.Remove(cat);
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
