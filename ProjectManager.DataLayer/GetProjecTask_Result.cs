//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManager.DataLayer
{
    using System;
    
    public partial class GetProjecTask_Result
    {
        public int Project_ID { get; set; }
        public string ProjectName { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<int> NoofTasks { get; set; }
        public Nullable<int> completedtask { get; set; }
    }
}