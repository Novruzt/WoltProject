using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WOLT.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FirstDataSeedForRestaurantAnd2BranchesCreatedForThis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "BaseAddress", "CreationTime", "DeleteTime", "Description", "FavoriteRestaurantId", "IsDeleted", "Name", "Phone", "UpdateTime" },
                values: new object[] { 1, "Mehelle 765", new DateTime(2023, 8, 4, 19, 36, 37, 432, DateTimeKind.Local).AddTicks(3189), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sumgayitin 1nomreli parki", null, false, "GoyercinPark", "051 123 00 12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "CreationTime", "DeleteTime", "IsDeleted", "Phone", "RestaurantId", "UpdateTime", "WorkHourdsId" },
                values: new object[,]
                {
                    { 1, "Goyercin", new DateTime(2023, 8, 4, 19, 36, 37, 432, DateTimeKind.Local).AddTicks(3390), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "123 123 123", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, "Qayali", new DateTime(2023, 8, 4, 19, 36, 37, 432, DateTimeKind.Local).AddTicks(3393), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "123 123 11", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
