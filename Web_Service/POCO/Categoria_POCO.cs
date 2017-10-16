using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Service.Models;

namespace Web_Service.POCO
{
    [Serializable]
    public class Categoria_POCO
    {
        public int id;
        public string nome;
       

        public static explicit operator categoria(Categoria_POCO e)
        {
            if (e == null) return null;
            categoria cliente = new categoria();

            cliente.cat_nome = e.nome;
            

            return cliente;
        }

        public static explicit operator Categoria_POCO(categoria e)
        {
            if (e == null) return null;
            Categoria_POCO Cliente_POCO = new Categoria_POCO();

            Cliente_POCO.id = e.cat_cod;
            Cliente_POCO.nome = e.cat_nome;

            return Cliente_POCO;
        }
    }
}