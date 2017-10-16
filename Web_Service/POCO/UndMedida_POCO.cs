using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Service.Models;

namespace Web_Service.POCO
{
    [Serializable]
    public class UndMedida_POCO
    {
        public int id;
        public string nome;

        public static explicit operator undmedida(UndMedida_POCO e)
        {
            if (e == null) return null;
            undmedida cliente = new undmedida();

            cliente.umed_nome = e.nome;

            return cliente;
        }

        public static explicit operator UndMedida_POCO(undmedida e)
        {
            if (e == null) return null;
            UndMedida_POCO Cliente_POCO = new UndMedida_POCO();

            Cliente_POCO.id = e.umed_cod;
            Cliente_POCO.nome = e.umed_nome;

            return Cliente_POCO;
        }
    }
}