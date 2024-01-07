using Microsoft.EntityFrameworkCore;
using ShaTask.Entities.Models;
using ShaTask.Persistence.Configuration;


namespace ShaTask.Persistence.Data
{
    public class ApplicationDbContext :DbContext
    {
        //public ApplicationDbContext()
        //{       
        //}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Cashier> Cashier { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<InvoiceDetail>InvoiceDetails { get; set; }
        public DbSet<InvoiceHeader>InvoiceHeader { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BranchEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CashierEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceDetailEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceHeaderEntityConfiguration());
        }




    }
}
