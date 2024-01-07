using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Persistence.Data
{
    public class DataSeeding
    {
        public static void SeedData(MigrationBuilder migrationBuilder)
        {

            // Insert data into Cities table
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Cities] ON");
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName" },
                values: new object[,]
                {
                    { 1, "القاهرة - مدينة نصر" },
                    { 2, "القاهرة - القاهرة الجديدة" },
                    { 3, "القاهرة - الشروق" },
                    { 4, "القاهرة - العبور" },
                    { 5, "الاسكندرية - سموحة" }
                });
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Cities] OFF");

            // Insert data into Branches table
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Branches] ON");
            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CityId" },
                values: new object[,]
                {
                    { 2, "فرع الحي السابع", 1 },
                    { 3, "فرع عباس العقاد", 1 },
                    { 4, "فرع التجمع الاول", 2 },
                    { 5, "فرع سموحة", 5 },
                    { 6, "فرع الشروق", 3 },
                    { 7, "فرع العبور", 4 }
                });
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Branches] OFF");

            // Insert data into Cashier table
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Cashier] ON");
            migrationBuilder.InsertData(
                table: "Cashier",
                columns: new[] { "Id", "CashierName", "BranchId" },
                values: new object[,]
                {
                    { 1, "محمد احمد", 2 },
                    { 2, "محمود احمد محمد", 3 },
                    { 3, "مصطفي عبد السميع", 2 },
                    { 4, "احمد عبد الرحمن", 6 },
                    { 5, "ساره عبد الله", 4 }
                });
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Cashier] OFF");


            

            // Insert data into InvoiceHeader table
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[InvoiceHeader] ON");
            migrationBuilder.InsertData(
                table: "InvoiceHeader",
                columns: new[] { "Id", "CustomerName", "InvoiceDate", "CashierId", "BranchId" },
                values: new object[,]
                {
                    { 2, "محمد عبد الله", new DateTime(2022, 2, 22), 1, 2 },
                    { 3, "محمود احمد", new DateTime(2022, 2, 23), 2, 3 }
                });
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[InvoiceHeader] OFF");

            // Insert data into InvoiceDetails table
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[InvoiceDetails] ON");
            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "Id", "InvoiceHeaderId", "ItemName", "ItemCount", "ItemPrice" },
                values: new object[,]
                {
                    { 2, 2, "بيبسي 1 لتر", 2, 20.0 },
                    { 3, 2, "ساندوتش برجر", 2, 50.0 },
                    { 4, 2, "ايس كريم", 1, 10.0 },
                    { 6, 3, "سفن اب كانز", 1, 5.0 }
                });
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[InvoiceDetails] OFF");

        }


        public static void RemoveData (MigrationBuilder migrationBuilder)
        {
            // Delete data from InvoiceDetails table
            migrationBuilder.DeleteData("InvoiceDetails", "Id", 2);
            migrationBuilder.DeleteData("InvoiceDetails", "Id", 3);
            migrationBuilder.DeleteData("InvoiceDetails", "Id", 4);
            migrationBuilder.DeleteData("InvoiceDetails", "Id", 6);

            // Delete data from InvoiceHeader table
            migrationBuilder.DeleteData("InvoiceHeader", "Id", 2);
            migrationBuilder.DeleteData("InvoiceHeader", "Id", 3);

            // Delete data from Cashier table
            migrationBuilder.DeleteData("Cashier", "Id", 1);
            migrationBuilder.DeleteData("Cashier", "Id", 2);
            migrationBuilder.DeleteData("Cashier", "Id", 3);
            migrationBuilder.DeleteData("Cashier", "Id", 4);
            migrationBuilder.DeleteData("Cashier", "Id", 5);

            // Delete data from Branches table
            migrationBuilder.DeleteData("Branches", "Id", 2);
            migrationBuilder.DeleteData("Branches", "Id", 3);
            migrationBuilder.DeleteData("Branches", "Id", 4);
            migrationBuilder.DeleteData("Branches", "Id", 5);
            migrationBuilder.DeleteData("Branches", "Id", 6);
            migrationBuilder.DeleteData("Branches", "Id", 7);

            // Delete data from Cities table
            migrationBuilder.DeleteData("Cities", "Id", 1);
            migrationBuilder.DeleteData("Cities", "Id", 2);
            migrationBuilder.DeleteData("Cities", "Id", 3);
            migrationBuilder.DeleteData("Cities", "Id", 4);
            migrationBuilder.DeleteData("Cities", "Id", 5);


        }





    }
}
