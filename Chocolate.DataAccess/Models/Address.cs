namespace Chocolate.DataAccess.Models
{
    public class Address : Entity
    {
        public string Location { get; set; }
        public string Country { get; set; }
        public short PostCode { get; set; }
        public short AddressNumber { get; set; }
        public string Comments { get; set; }
        public int? WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int? CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
