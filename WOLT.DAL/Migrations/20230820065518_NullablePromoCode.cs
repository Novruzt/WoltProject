using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WOLT.DAL.Migrations
{
    /// <inheritdoc />
    public partial class NullablePromoCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 10, 55, 18, 385, DateTimeKind.Local).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 10, 55, 18, 385, DateTimeKind.Local).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 6, 55, 18, 385, DateTimeKind.Utc).AddTicks(3680));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 6, 55, 18, 385, DateTimeKind.Utc).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 10, 55, 18, 385, DateTimeKind.Local).AddTicks(3556));

            migrationBuilder.UpdateData(
                table: "UserComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 10, 55, 18, 385, DateTimeKind.Local).AddTicks(3598));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 10, 55, 18, 385, DateTimeKind.Local).AddTicks(3731));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 10, 55, 18, 385, DateTimeKind.Local).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 10, 55, 18, 385, DateTimeKind.Local).AddTicks(3737));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "VerifiedAt" },
                values: new object[] { new DateTime(2023, 8, 20, 10, 55, 18, 385, DateTimeKind.Local).AddTicks(3101), new DateTime(2023, 8, 20, 10, 55, 18, 385, DateTimeKind.Local).AddTicks(3124) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 7, 49, 12, 191, DateTimeKind.Local).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 7, 49, 12, 191, DateTimeKind.Local).AddTicks(5832));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 3, 49, 12, 191, DateTimeKind.Utc).AddTicks(5849));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 3, 49, 12, 191, DateTimeKind.Utc).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 7, 49, 12, 191, DateTimeKind.Local).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "UserComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 7, 49, 12, 191, DateTimeKind.Local).AddTicks(5816));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 7, 49, 12, 191, DateTimeKind.Local).AddTicks(5869));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 7, 49, 12, 191, DateTimeKind.Local).AddTicks(5870));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 7, 49, 12, 191, DateTimeKind.Local).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "VerifiedAt" },
                values: new object[] { new DateTime(2023, 8, 20, 7, 49, 12, 191, DateTimeKind.Local).AddTicks(5652), new DateTime(2023, 8, 20, 7, 49, 12, 191, DateTimeKind.Local).AddTicks(5665) });
        }
    }
}
