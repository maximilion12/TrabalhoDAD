using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Web_Service.Models;

namespace Web_Service.Controllers
{
    public class clientesTesteController : ApiController
    {
        private TrabalhoDADEntities db = new TrabalhoDADEntities();

        // GET: api/clientesTeste
        public IQueryable<cliente> Getcliente()
        {
            return db.cliente;
        }

        // GET: api/clientesTeste/5
        [ResponseType(typeof(cliente))]
        public IHttpActionResult Getcliente(int id)
        {
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/clientesTeste/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcliente(int id, cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.cli_cod)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/clientesTeste
        [ResponseType(typeof(cliente))]
        public IHttpActionResult Postcliente(cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cliente.Add(cliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cliente.cli_cod }, cliente);
        }

        // DELETE: api/clientesTeste/5
        [ResponseType(typeof(cliente))]
        public IHttpActionResult Deletecliente(int id)
        {
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            db.cliente.Remove(cliente);
            db.SaveChanges();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool clienteExists(int id)
        {
            return db.cliente.Count(e => e.cli_cod == id) > 0;
        }
    }
}