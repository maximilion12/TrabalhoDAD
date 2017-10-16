using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Service.Models;

namespace Web_Service.POCO
{
    [Serializable]
    public class ItensVenda_POCO
    {
        public int id;
        public Nullable<double> qnt_item;
        public Nullable<decimal> valor_item;
        public int id_compra;
        public int id_produto;

        public static explicit operator itensvenda(ItensVenda_POCO e)
        {
            if (e == null) return null;
            itensvenda cliente = new itensvenda();

            cliente.itv_qtde = e.qnt_item;
            cliente.itv_valor = e.valor_item;
            cliente.ven_cod = e.id_compra;
            cliente.pro_cod = e.id_produto;

            return cliente;
        }

        public static explicit operator ItensVenda_POCO(itensvenda e)
        {
            if (e == null) return null;
            ItensVenda_POCO Cliente_POCO = new ItensVenda_POCO();

            Cliente_POCO.id = e.itv_cod;
            Cliente_POCO.qnt_item = e.itv_qtde;
            Cliente_POCO.valor_item = e.itv_valor;
            Cliente_POCO.id_compra = e.ven_cod;
            Cliente_POCO.id_produto = e.pro_cod;

            return Cliente_POCO;
        }
    }
}