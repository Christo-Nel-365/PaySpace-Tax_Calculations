//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


    using System;
    using System.Collections.Generic;
    
    public partial class Tax_Calculation_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tax_Calculation_Type()
        {
            this.Postal_Code_tbl = new HashSet<Postal_Code_tbl>();
        }
    
        public int TCT_ID { get; set; }
        public string Tax_Calc_Type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Postal_Code_tbl> Postal_Code_tbl { get; set; }
    }
