//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Batch_Hashid
{
    using System;
    using System.Collections.Generic;
    
    public partial class BatchUploadData
    {
        public int PK_Batchid { get; set; }
        public string ReferenceNumber { get; set; }
        public string Longurl { get; set; }
        public string MobileNumber { get; set; }
        public string BatchName { get; set; }
        public Nullable<int> FK_RID { get; set; }
        public Nullable<int> FK_ClientID { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
