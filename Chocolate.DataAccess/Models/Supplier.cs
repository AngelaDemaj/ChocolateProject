using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Chocolate.DataAccess.Models.AbstractEntities;

namespace Chocolate.DataAccess.Models
{
    public class Supplier : Corporation
    {
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<RawMaterialSupplier> RawMaterials { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public ICollection<Email> Emails { get; set; }
    }
}
