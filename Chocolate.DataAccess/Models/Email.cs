﻿using Chocolate.DataAccess.Models.Enums;

namespace Chocolate.DataAccess.Models
{
    public class Email : Entity
    {
        public string Mail { get; set; }
        public MailType MailType { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public int? WarehouseId { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
        public Supplier Supplier { get; set; }
        public int? CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
