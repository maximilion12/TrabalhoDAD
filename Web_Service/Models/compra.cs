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
    
    public partial class compra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public compra()
        {
            this.itenscompra = new HashSet<itenscompra>();
            this.parcelascompra = new HashSet<parcelascompra>();
        }
    
        public int com_cod { get; set; }
        public Nullable<System.DateTime> com_data { get; set; }
        public Nullable<int> com_nfiscal { get; set; }
        public Nullable<decimal> com_total { get; set; }
        public Nullable<int> com_nparcelas { get; set; }
        public Nullable<int> com_status { get; set; }
        public Nullable<int> for_cod { get; set; }
        public Nullable<int> tpa_cod { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<itenscompra> itenscompra { get; set; }
        public virtual fornecedor fornecedor { get; set; }
        public virtual tipopagamento tipopagamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<parcelascompra> parcelascompra { get; set; }
    }
}
