using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Service.Models;

namespace Web_Service.POCO
{
    [Serializable]
    public class Compra_POCO
    {
        public int id;
        public Nullable<System.DateTime> data;
        public Nullable<decimal> total { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> id_fornecedor { get; set; }
        public Nullable<int> id_tipopagamento { get; set; }

        public static explicit operator compra(Compra_POCO e)
        {
            if (e == null) return null;
            compra compra = new compra();

            compra.com_data = e.data;
            compra.com_nfiscal = null;
            compra.com_total = e.total;
            compra.com_nparcelas = null;
            compra.com_status = e.status;
            compra.for_cod = e.id_fornecedor;
            compra.tpa_cod = e.id_tipopagamento;

            return compra;
        }

        public static explicit operator Compra_POCO(compra e)
        {
            if (e == null) return null;
            Compra_POCO Cliente_POCO = new Compra_POCO();

            Cliente_POCO.id = e.com_cod;
            Cliente_POCO.data = e.com_data;
            Cliente_POCO.total = e.com_total;
            Cliente_POCO.status = e.com_status;
            Cliente_POCO.id_fornecedor = e.for_cod;
            Cliente_POCO.id_tipopagamento = e.tpa_cod;

            return Cliente_POCO;
        }
    }
}