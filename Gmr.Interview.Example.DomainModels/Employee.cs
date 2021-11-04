using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gmr.Interview.Example.DomainModels
{
    [Table("Employees")]
    public class Employee : BaseEntity
    {
        [Key]
        public int EmployeeId { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string BusinessTitle { get; set; }

        public string PayGroup { get; set; }

        public string EmployeeStatus { get; set; }

        public string EmployeeType { get; set; }
    }
}