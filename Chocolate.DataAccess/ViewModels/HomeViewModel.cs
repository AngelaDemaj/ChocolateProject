using System;
using System.ComponentModel.DataAnnotations;

namespace Chocolate.DataAccess.ViewModels
{
    public class HomeViewModel
    {
        public int Departments { get; set; }
        public int Employees { get; set; }
        public int Positions { get; set; }
        public int Candidates { get; set; }
        public int Customers { get; set; }
        public int Orders { get; set; }
        public int Purchases { get; set; }
        public int Products { get; set; }
        public int RawMaterials { get; set; }
        public int Suppliers { get; set; }
        public int Warehouses { get; set; }
        public int StorageUnits { get; set; }
        public string Title { get; set; }
        public DateTime When { get; set; }
        public int EmployeeId { get; set; }
    }
}