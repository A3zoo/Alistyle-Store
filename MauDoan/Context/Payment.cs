//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MauDoan.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public string id { get; set; }
        public string user_id { get; set; }
        public Nullable<System.DateTime> datepayment { get; set; }
        public string methodpayment { get; set; }
        public string order_detail_id { get; set; }
    
        public virtual Order_detail Order_detail { get; set; }
        public virtual Users Users { get; set; }
    }
}
