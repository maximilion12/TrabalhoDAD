using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Service.Models;

namespace Web_Service.POCO
{
    [Serializable]
    public class Subcategoria_POCO
    {
        public int id;
        public string nome;
        public Nullable<int> id_categoria;

        public static explicit operator subcategoria(Subcategoria_POCO e)
        {
            if (e == null) return null;
            subcategoria cliente = new subcategoria();

            cliente.scat_nome = e.nome;
            cliente.cat_cod = e.id_categoria;

            return cliente;
        }

        public static explicit operator Subcategoria_POCO(subcategoria e)
        {
            if (e == null) return null;
            Subcategoria_POCO Cliente_POCO = new Subcategoria_POCO();

            Cliente_POCO.id = e.scat_cod;
            Cliente_POCO.nome = e.scat_nome;
            Cliente_POCO.id_categoria = e.cat_cod;
            
            return Cliente_POCO;
        }
    }
}