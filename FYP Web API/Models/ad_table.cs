//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FYP_Web_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ad_table
    {
        public int advertisment_id { get; set; }
        public string Adstitle { get; set; }
        public string Adstext { get; set; }
        public string websitelink { get; set; }
        public string Adsimage { get; set; }
        public string Status { get; set; }
        public int User_id { get; set; }
        public System.DateTime Date { get; set; }
        public int Elapsed_Days { get; set; }
        public int Amount { get; set; }
    
        public virtual user_table user_table { get; set; }
    }
}
