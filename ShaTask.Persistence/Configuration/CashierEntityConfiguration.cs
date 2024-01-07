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
    public class CashierEntityConfiguration : IEntityTypeConfiguration<Cashier>
    {

       public  void Configure(EntityTypeBuilder<Cashier> builder)
        {
            builder
                .HasOne(c => c.Branch)
                .WithMany(b => b.Cashiers)
                .HasForeignKey(c => c.BranchId)
                .OnDelete(DeleteBehavior.NoAction);
        }


    }
}
