using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Service.Models;

namespace Web_Service.POCO
{
    [Serializable]
    public class Fornecedor_POCO
    {
        public int id;
        public string nome;
        public string cnpj;
        public string ie;        
        public string cep;
        public string endereco;
        public string bairro;
        public string fone;
        public string cel;
        public string email;
        public string cidade;
        public string estado;

        public static explicit operator fornecedor(Fornecedor_POCO e)
        {
            if (e == null) return null;
            fornecedor cliente = new fornecedor();

            cliente.for_nome = e.nome;
            cliente.for_cnpj = e.cnpj;
            cliente.for_ie = e.ie;
            cliente.for_rsocial = null;
            cliente.for_cep = e.cep;
            cliente.for_endereco = e.endereco;
            cliente.for_bairro = e.bairro;
            cliente.for_fone = e.fone;
            cliente.for_cel = e.cel;
            cliente.for_email = e.email;
            cliente.for_endnumero = null;
            cliente.for_cidade = e.cidade;
            cliente.for_estado = e.estado;

            return cliente;
        }

        public static explicit operator Fornecedor_POCO(fornecedor e)
        {
            if (e == null) return null;
            Fornecedor_POCO Cliente_POCO = new Fornecedor_POCO();

            Cliente_POCO.id = e.for_cod;
            Cliente_POCO.nome = e.for_nome;
            Cliente_POCO.cnpj = e.for_cnpj;
            Cliente_POCO.ie = e.for_ie;
            Cliente_POCO.cep = e.for_cep;
            Cliente_POCO.endereco = e.for_endereco;
            Cliente_POCO.bairro = e.for_bairro;
            Cliente_POCO.fone = e.for_fone;
            Cliente_POCO.cel = e.for_cel;
            Cliente_POCO.email = e.for_email;
            Cliente_POCO.cidade = e.for_cidade;
            Cliente_POCO.estado = e.for_estado;

            return Cliente_POCO;
        }
    }
}