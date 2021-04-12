using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.DataAccess.Configurations
{
    class RawMaterialSupplierConfiguration : IEntityTypeConfiguration<RawMaterialSupplier>
    {
        public void Configure(EntityTypeBuilder<RawMaterialSupplier> builder)
        {
            builder.HasKey(rs => new { rs.RawMaterialId, rs.SupplierId });

            builder.HasOne(rs => rs.RawMaterial)
                .WithMany(s => s.Suppliers)
                .HasForeignKey(rs => rs.RawMaterialId);

            builder.HasOne(rs => rs.Supplier)
                .WithMany(r => r.RawMaterials)
                .HasForeignKey(rs => rs.SupplierId);
        }
    }
}
