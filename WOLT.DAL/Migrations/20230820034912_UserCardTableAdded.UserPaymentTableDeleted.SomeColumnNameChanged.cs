using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WOLT.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserCardTableAddedUserPaymentTableDeletedSomeColumnNameChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CCV",
                table: "UserPayments",
                newName: "CVV");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CVV",
                table: "UserPayments",
                newName: "CCV");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 18, 16, 1, 10, 405, DateTimeKind.Local).AddTicks(4460));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 18, 16, 1, 10, 405, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 18, 12, 1, 10, 405, DateTimeKind.Utc).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 18, 12, 1, 10, 405, DateTimeKind.Utc).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 18, 16, 1, 10, 405, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "UserComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 18, 16, 1, 10, 405, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 18, 16, 1, 10, 405, DateTimeKind.Local).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 18, 16, 1, 10, 405, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 8, 18, 16, 1, 10, 405, DateTimeKind.Local).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "VerifiedAt" },
                values: new object[] { new DateTime(2023, 8, 18, 16, 1, 10, 405, DateTimeKind.Local).AddTicks(4221), new DateTime(2023, 8, 18, 16, 1, 10, 405, DateTimeKind.Local).AddTicks(4238) });
        }
    }
}
