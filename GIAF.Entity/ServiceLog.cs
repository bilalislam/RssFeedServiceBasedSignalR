//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GIAF.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceLog
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string DeviceType { get; set; }
        public string MachineName { get; set; }
        public string MethodName { get; set; }
        public string MethodType { get; set; }
        public string Data { get; set; }
        public string DataType { get; set; }
        public string UniqueKey { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
