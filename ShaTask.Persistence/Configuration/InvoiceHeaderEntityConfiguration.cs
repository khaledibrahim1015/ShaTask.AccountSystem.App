using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShaTask.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Persistence.Configuration
{
    public class InvoiceHeaderEntityConfiguration :IEntityTypeConfiguration<InvoiceHeader>
    {
        public void Configure(EntityTypeBuilder<InvoiceHeader> builder)
        {
            builder
                    .HasOne(c => c.Cashier)
                    .WithMany(IH => IH.InvoiceHeaders)
                    .HasForeignKey(c => c.CashierId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder
                   .HasOne(i => i.Branch)
                   .WithMany(b => b.InvoiceHeaders)
                   .HasForeignKey(i => i.BranchId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
