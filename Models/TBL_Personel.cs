//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace onMuhasebeApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_Personel
    {
        public int personel_ID { get; set; }
        public Nullable<int> company_ID { get; set; }
        public string personel_TC { get; set; }
        public string personel_AD { get; set; }
        public string personel_SAD { get; set; }
        public string personel_TELNO { get; set; }
        public string personel_ADRES { get; set; }
        public string personel_UNVAN { get; set; }
        public string personel_DEPARTMAN { get; set; }
        public Nullable<System.DateTime> personel_GIRISTAR { get; set; }
        public Nullable<int> personel_MAAS { get; set; }
    
        public virtual TBL_Companies TBL_Companies { get; set; }
    }
}