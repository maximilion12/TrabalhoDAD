using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Service.Models;

namespace Web_Service.POCO
{
    [Serializable]
    public class Venda_POCO
    {
        public int id;
        public Nullable<System.DateTime> data;
        public Nullable<decimal> vlr_total;
        public Nullable<int> status;
        public Nullable<int> id_cliente;
        public Nullable<int> id_tipopagamento;

        public static explicit operator venda(Venda_POCO e)
        {
            if (e == null) return null;
            venda cliente = new venda();

            cliente.ven_data = e.data;
            cliente.ven_total = e.vlr_total;
            cliente.ven_status = e.status;
            cliente.cli_cod = e.id_cliente;
            cliente.tpa_cod = e.id_tipopagamento;

            return cliente;
        }

        public static explicit operator Venda_POCO(venda e)
        {
            if (e == null) return null;
            Venda_POCO Cliente_POCO = new Venda_POCO();

            Cliente_POCO.id = e.ven_cod;
            Cliente_POCO.data = e.ven_data;
            Cliente_POCO.vlr_total = e.ven_total;
            Cliente_POCO.status = e.ven_status;
            Cliente_POCO.id_cliente = e.cli_cod;
            Cliente_POCO.id_tipopagamento = e.tpa_cod;

            return Cliente_POCO;
        }
    }
}