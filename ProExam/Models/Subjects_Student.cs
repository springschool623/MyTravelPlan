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
    
    public partial class Subjects_Student
    {
        public int Subs_Stu_No { get; set; }
        public string StudentCode { get; set; }
        public string Subject_ID { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
