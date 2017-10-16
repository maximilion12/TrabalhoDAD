using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Service.Models;

namespace Web_Service.POCO
{
    [Serializable]
    public class TipoPagamento_POCO
    {
        public int id;
        public string nome;



        public static explicit operator tipopagamento(TipoPagamento_POCO e)
        {
            if (e == null) return null;
            tipopagamento cliente = new tipopagamento();

            cliente.tpa_nome = e.nome;

            return cliente;
        }

        public static explicit operator TipoPagamento_POCO(tipopagamento e)
        {
            if (e == null) return null;
            TipoPagamento_POCO Cliente_POCO = new TipoPagamento_POCO();

            Cliente_POCO.id = e.tpa_cod;
            Cliente_POCO.nome = e.tpa_nome;

            return Cliente_POCO;
        }
    }
}