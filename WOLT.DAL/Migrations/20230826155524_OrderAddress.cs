using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WOLT.DAL.Migrations
{
    /// <inheritdoc />
    public partial class OrderAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_UserAddressId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 26, 19, 55, 24, 427, DateTimeKind.Local).AddTicks(466));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 26, 19, 55, 24, 427, DateTimeKind.Local).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 26, 15, 55, 24, 427, DateTimeKind.Utc).AddTicks(500));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 26, 15, 55, 24, 427, DateTimeKind.Utc).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "PromoEndTime", "PromoStartTime" },
                values: new object[] { new DateTime(2023, 8, 26, 19, 55, 24, 427, DateTimeKind.Local).AddTicks(528), new DateTime(2023, 9, 5, 19, 55, 24, 427, DateTimeKind.Local).AddTicks(529), new DateTime(2023, 8, 26, 19, 55, 24, 427, DateTimeKind.Local).AddTicks(536) });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationTime", "PromoEndTime", "PromoStartTime" },
                values: new object[] { new DateTime(2023, 8, 26, 19, 55, 24, 427, DateTimeKind.Local).AddTicks(539), new DateTime(2023, 9, 5, 19, 55, 24, 427, DateTimeKind.Local).AddTicks(540), new DateTime(2023, 8, 26, 19, 55, 24, 427, DateTimeKind.Local).AddTicks(541) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 26, 19, 55, 24, 426, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserAddressId",
                table: "Orders",
                column: "UserAddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_UserAddressId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 26, 19, 29, 39, 889, DateTimeKind.Local).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 26, 19, 29, 39, 889, DateTimeKind.Local).AddTicks(3971));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 26, 15, 29, 39, 889, DateTimeKind.Utc).AddTicks(3989));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 26, 15, 29, 39, 889, DateTimeKind.Utc).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "PromoEndTime", "PromoStartTime" },
                values: new object[] { new DateTime(2023, 8, 26, 19, 29, 39, 889, DateTimeKind.Local).AddTicks(4009), new DateTime(2023, 9, 5, 19, 29, 39, 889, DateTimeKind.Local).AddTicks(4009), new DateTime(2023, 8, 26, 19, 29, 39, 889, DateTimeKind.Local).AddTicks(4016) });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationTime", "PromoEndTime", "PromoStartTime" },
                values: new object[] { new DateTime(2023, 8, 26, 19, 29, 39, 889, DateTimeKind.Local).AddTicks(4019), new DateTime(2023, 9, 5, 19, 29, 39, 889, DateTimeKind.Local).AddTicks(4019), new DateTime(2023, 8, 26, 19, 29, 39, 889, DateTimeKind.Local).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 26, 19, 29, 39, 889, DateTimeKind.Local).AddTicks(3728));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserAddressId",
                table: "Orders",
                column: "UserAddressId",
                unique: true,
                filter: "[UserAddressId] IS NOT NULL");
        }
    }
}
