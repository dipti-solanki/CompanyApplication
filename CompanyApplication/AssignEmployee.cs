//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompanyApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssignEmployee
    {
        public int AssignEmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public string AssignDesignation { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
