using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Service.Models;

namespace Web_Service.POCO
{
    [Serializable]
    public class Produto_POCO
    {
        public int id;
        public string nome;
        public string descricao;
        public Nullable<decimal> valorpago;
        public Nullable<decimal> valorvenda;
        public Nullable<double> qtde;
        public Nullable<int> id_unidmedida;
        public Nullable<int> id_categoria;
        public Nullable<int> id_subcategoria;

        public static explicit operator produto(Produto_POCO e)
        {
            if (e == null) return null;
            produto cliente = new produto();

            cliente.pro_nome = e.nome;
            cliente.pro_descricao = e.descricao;
            cliente.pro_valorpago = e.valorpago;
            cliente.pro_valorvenda = e.valorvenda;
            cliente.pro_qtde = e.qtde;
            cliente.umed_cod = e.id_unidmedida;
            cliente.cat_cod = e.id_categoria;
            cliente.scat_cod = e.id_subcategoria;

            return cliente;
        }

        public static explicit operator Produto_POCO(produto e)
        {
            if (e == null) return null;
            Produto_POCO Cliente_POCO = new Produto_POCO();

            Cliente_POCO.id = e.pro_cod;
            Cliente_POCO.nome = e.pro_nome;
            Cliente_POCO.descricao = e.pro_descricao;
            Cliente_POCO.valorpago = e.pro_valorpago;
            Cliente_POCO.valorvenda = e.pro_valorvenda;
            Cliente_POCO.qtde = e.pro_qtde;
            Cliente_POCO.id_unidmedida = e.umed_cod;
            Cliente_POCO.id_categoria = e.cat_cod;
            Cliente_POCO.id_subcategoria = e.scat_cod;

            return Cliente_POCO;
        }
    }
}