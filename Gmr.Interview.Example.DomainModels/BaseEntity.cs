using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gmr.Interview.Example.DomainModels
{
    public class BaseEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}