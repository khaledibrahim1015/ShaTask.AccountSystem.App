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
    public class InvoiceDetailEntityConfiguration :IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder
                     .HasOne(ID => ID.InvoiceHeader)
                     .WithMany(IH => IH.InvoiceDetails)
                     .HasForeignKey(ID => ID.InvoiceHeaderId);
        }

    }
}
