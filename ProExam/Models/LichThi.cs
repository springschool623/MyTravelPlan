//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProExam.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LichThi
    {
        public int MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public System.DateTime NgayThi { get; set; }
        public System.TimeSpan GioThi { get; set; }
        public string PhongThi { get; set; }
        public Nullable<int> SoLuongSV { get; set; }
    
        public virtual MonHoc MonHoc { get; set; }
    }
}
