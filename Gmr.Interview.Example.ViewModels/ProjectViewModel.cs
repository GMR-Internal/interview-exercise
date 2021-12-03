using System;

namespace Gmr.Interview.Example.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        
        public string ProjectNumber { get; set; }

        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public string CustomerId { get; set; }

        public string ProjectManager { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsBillable { get; set; }

        public bool AllowCharges { get; set; }

        public bool IsActive { get; set; }
    }
}
