using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Service.Models;

namespace Web_Service.POCO
{
    [Serializable]
    public class ItensCompra_POCO
    {
        public int id;
        public Nullable<double> qnt_item;
        public Nullable<decimal> valor_item;
        public int id_compra;
        public int id_produto;

        public static explicit operator itenscompra(ItensCompra_POCO e)
        {
            if (e == null) return null;
            itenscompra cliente = new itenscompra();

            cliente.itc_qtde = e.qnt_item;
            cliente.itc_valor = e.valor_item;
            cliente.com_cod = e.id_compra;
            cliente.pro_cod = e.id_produto;

            return cliente;
        }

        public static explicit operator ItensCompra_POCO(itenscompra e)
        {
            if (e == null) return null;
            ItensCompra_POCO Cliente_POCO = new ItensCompra_POCO();

            Cliente_POCO.id = e.itc_cod;
            Cliente_POCO.qnt_item = e.itc_qtde;
            Cliente_POCO.valor_item = e.itc_valor;
            Cliente_POCO.id_compra = e.com_cod;
            Cliente_POCO.id_produto = e.pro_cod;

            return Cliente_POCO;
        }
    }
}