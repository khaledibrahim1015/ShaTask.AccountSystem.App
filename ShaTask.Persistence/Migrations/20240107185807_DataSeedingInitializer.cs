using Microsoft.EntityFrameworkCore.Migrations;
using ShaTask.Persistence.Data;

#nullable disable

namespace ShaTask.Persistence.Migrations
{
    public partial class DataSeedingInitializer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            DataSeeding.SeedData(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            DataSeeding.RemoveData(migrationBuilder);

        }
    }
}
