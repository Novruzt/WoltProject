using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WOLT.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ImagesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 26, 20, 41, 14, 887, DateTimeKind.Local).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 26, 20, 41, 14, 887, DateTimeKind.Local).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "Picture" },
                values: new object[] { new DateTime(2023, 8, 26, 16, 41, 14, 887, DateTimeKind.Utc).AddTicks(4706), "file:///C://Users//User//Desktop//WoltPics//arı-su.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationTime", "Picture" },
                values: new object[] { new DateTime(2023, 8, 26, 16, 41, 14, 887, DateTimeKind.Utc).AddTicks(4710), "file:///C://Users//User//Desktop//WoltPics//indir.jpg" });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "PromoEndTime", "PromoStartTime" },
                values: new object[] { new DateTime(2023, 8, 26, 20, 41, 14, 887, DateTimeKind.Local).AddTicks(4738), new DateTime(2023, 9, 5, 20, 41, 14, 887, DateTimeKind.Local).AddTicks(4738), new DateTime(2023, 8, 26, 20, 41, 14, 887, DateTimeKind.Local).AddTicks(4748) });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationTime", "PromoEndTime", "PromoStartTime" },
                values: new object[] { new DateTime(2023, 8, 26, 20, 41, 14, 887, DateTimeKind.Local).AddTicks(4752), new DateTime(2023, 9, 5, 20, 41, 14, 887, DateTimeKind.Local).AddTicks(4752), new DateTime(2023, 8, 26, 20, 41, 14, 887, DateTimeKind.Local).AddTicks(4753) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 26, 20, 41, 14, 887, DateTimeKind.Local).AddTicks(4178));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreationTime", "Picture" },
                values: new object[] { new DateTime(2023, 8, 26, 15, 55, 24, 427, DateTimeKind.Utc).AddTicks(500), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationTime", "Picture" },
                values: new object[] { new DateTime(2023, 8, 26, 15, 55, 24, 427, DateTimeKind.Utc).AddTicks(502), null });

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
        }
    }
}
