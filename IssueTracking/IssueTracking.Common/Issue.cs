//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IssueTracking.Common
{
    using System;
    using System.Collections.Generic;
    
    public partial class Issue
    {
        public Issue()
        {
            this.Comments = new HashSet<Comment>();
            this.AssocIssues = new HashSet<Issue>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public State State { get; set; }
    
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Issue> AssocIssues { get; set; }
    }
}
