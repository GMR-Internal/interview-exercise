using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gmr.Interview.Example.DomainModels
{
    [Table("Projects")]
    public class Project : BaseEntity
    {
        [Key]
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
