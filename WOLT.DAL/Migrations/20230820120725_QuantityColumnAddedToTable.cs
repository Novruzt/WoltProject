using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WOLT.DAL.Migrations
{
    /// <inheritdoc />
    public partial class QuantityColumnAddedToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderProductQuantities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 16, 7, 25, 260, DateTimeKind.Local).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 16, 7, 25, 260, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 12, 7, 25, 260, DateTimeKind.Utc).AddTicks(4127));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 12, 7, 25, 260, DateTimeKind.Utc).AddTicks(4128));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 16, 7, 25, 260, DateTimeKind.Local).AddTicks(4075));

            migrationBuilder.UpdateData(
                table: "UserComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 16, 7, 25, 260, DateTimeKind.Local).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 16, 7, 25, 260, DateTimeKind.Local).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 16, 7, 25, 260, DateTimeKind.Local).AddTicks(4148));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 16, 7, 25, 260, DateTimeKind.Local).AddTicks(4149));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "VerifiedAt" },
                values: new object[] { new DateTime(2023, 8, 20, 16, 7, 25, 260, DateTimeKind.Local).AddTicks(3877), new DateTime(2023, 8, 20, 16, 7, 25, 260, DateTimeKind.Local).AddTicks(3889) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderProductQuantities");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 16, 5, 4, 402, DateTimeKind.Local).AddTicks(3727));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 16, 5, 4, 402, DateTimeKind.Local).AddTicks(3729));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 12, 5, 4, 402, DateTimeKind.Utc).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 12, 5, 4, 402, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 16, 5, 4, 402, DateTimeKind.Local).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "UserComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 16, 5, 4, 402, DateTimeKind.Local).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 16, 5, 4, 402, DateTimeKind.Local).AddTicks(3781));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 16, 5, 4, 402, DateTimeKind.Local).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 16, 5, 4, 402, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "VerifiedAt" },
                values: new object[] { new DateTime(2023, 8, 20, 16, 5, 4, 402, DateTimeKind.Local).AddTicks(3515), new DateTime(2023, 8, 20, 16, 5, 4, 402, DateTimeKind.Local).AddTicks(3533) });
        }
    }
}
