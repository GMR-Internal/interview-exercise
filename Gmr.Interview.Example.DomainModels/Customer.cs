using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gmr.Interview.Example.DomainModels
{
    [Table("Customers")]
    public class Customer : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string CustomerType { get; set; }

        public string SalesContactName { get; set; }

        public string MainOfficePhone { get; set; }

        public string MainOfficeEmail { get; set; }

        public string CreditStatus { get; set; }
    }
}
