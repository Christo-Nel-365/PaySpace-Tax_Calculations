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
    
    public partial class Postal_Code_tbl
    {
        public int PC_ID { get; set; }
        public string Postal_Code { get; set; }
        public Nullable<int> TCT_ID { get; set; }
    
        public virtual Tax_Calculation_Type Tax_Calculation_Type { get; set; }
    }

