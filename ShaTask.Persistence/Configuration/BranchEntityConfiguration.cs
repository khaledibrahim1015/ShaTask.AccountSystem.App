using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShaTask.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Persistence.Configuration
{
    public class BranchEntityConfiguration :IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            // Configure relationships
            builder
                .HasOne(b => b.City)          
                .WithMany(c => c.Branches)    
                .HasForeignKey(b => b.CityId); 
        }
    }
}
