//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Service.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class parcelasvenda
    {
        public int ven_cod { get; set; }
        public int pve_cod { get; set; }
        public Nullable<decimal> pve_valor { get; set; }
        public Nullable<System.DateTime> pve_datapagto { get; set; }
        public Nullable<System.DateTime> pve_datavecto { get; set; }
    
        public virtual venda venda { get; set; }
    }
}
