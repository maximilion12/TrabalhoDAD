using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Service.Models;

namespace Web_Service.POCO
{
    public class Cliente_POCO
    {
        public int id;
        public string nome;
        public string cpf_cnpj;
        public string rg_ie;
        public string tipo;
        public string cep;
        public string endereco;
        public string bairro;
        public string fone;
        public string cel;
        public string email;
        public string cidade;
        public string estado;

        public static explicit operator cliente(Cliente_POCO e)
        {
            if (e == null) return null;
            cliente cliente = new cliente();

            cliente.cli_nome = e.nome;
            cliente.cli_cpfcnpj = e.cpf_cnpj;
            cliente.cli_rgie = e.rg_ie;
            cliente.cli_rsocial = null;
            cliente.cli_tipo = e.tipo;
            cliente.cli_cep = e.cep;
            cliente.cli_endereco = e.endereco;
            cliente.cli_bairro = e.bairro;
            cliente.cli_fone = e.fone;
            cliente.cli_cel = e.cel;
            cliente.cli_email = e.email;
            cliente.cli_endnumero = null;
            cliente.cli_cidade = e.cidade;
            cliente.cli_estado = e.estado;

            return cliente;
        }

        public static explicit operator Cliente_POCO(cliente e)
        {
            if (e == null) return null;
            Cliente_POCO Cliente_POCO = new Cliente_POCO();

            Cliente_POCO.id = e.cli_cod;
            Cliente_POCO.nome = e.cli_nome;
            Cliente_POCO.cpf_cnpj = e.cli_cpfcnpj;
            Cliente_POCO.rg_ie = e.cli_rgie;
            Cliente_POCO.tipo = e.cli_tipo;
            Cliente_POCO.cep = e.cli_cep;
            Cliente_POCO.endereco = e.cli_endereco;
            Cliente_POCO.bairro = e.cli_bairro;
            Cliente_POCO.fone = e.cli_fone;
            Cliente_POCO.cel = e.cli_cel;
            Cliente_POCO.email = e.cli_email;
            Cliente_POCO.cidade = e.cli_cidade;
            Cliente_POCO.estado = e.cli_estado;

            return Cliente_POCO;
        }
    }
}