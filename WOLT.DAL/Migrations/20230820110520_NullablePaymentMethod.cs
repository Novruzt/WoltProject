using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WOLT.DAL.Migrations
{
    /// <inheritdoc />
    public partial class NullablePaymentMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserPayments_UserPaymentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserAddressId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "UserPaymentId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserAddressId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 15, 5, 19, 918, DateTimeKind.Local).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 15, 5, 19, 918, DateTimeKind.Local).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 11, 5, 19, 918, DateTimeKind.Utc).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 11, 5, 19, 918, DateTimeKind.Utc).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 15, 5, 19, 918, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "UserComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 15, 5, 19, 918, DateTimeKind.Local).AddTicks(7981));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 15, 5, 19, 918, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 15, 5, 19, 918, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 15, 5, 19, 918, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "VerifiedAt" },
                values: new object[] { new DateTime(2023, 8, 20, 15, 5, 19, 918, DateTimeKind.Local).AddTicks(7812), new DateTime(2023, 8, 20, 15, 5, 19, 918, DateTimeKind.Local).AddTicks(7823) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserAddressId",
                table: "Orders",
                column: "UserAddressId",
                unique: true,
                filter: "[UserAddressId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserPayments_UserPaymentId",
                table: "Orders",
                column: "UserPaymentId",
                principalTable: "UserPayments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserPayments_UserPaymentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserAddressId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "UserPaymentId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserAddressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 12, 34, 3, 563, DateTimeKind.Local).AddTicks(8575));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 12, 34, 3, 563, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 8, 34, 3, 563, DateTimeKind.Utc).AddTicks(8590));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 8, 34, 3, 563, DateTimeKind.Utc).AddTicks(8592));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 12, 34, 3, 563, DateTimeKind.Local).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "UserComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 12, 34, 3, 563, DateTimeKind.Local).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 12, 34, 3, 563, DateTimeKind.Local).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 12, 34, 3, 563, DateTimeKind.Local).AddTicks(8612));

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 8, 20, 12, 34, 3, 563, DateTimeKind.Local).AddTicks(8613));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "VerifiedAt" },
                values: new object[] { new DateTime(2023, 8, 20, 12, 34, 3, 563, DateTimeKind.Local).AddTicks(8377), new DateTime(2023, 8, 20, 12, 34, 3, 563, DateTimeKind.Local).AddTicks(8390) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserAddressId",
                table: "Orders",
                column: "UserAddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserPayments_UserPaymentId",
                table: "Orders",
                column: "UserPaymentId",
                principalTable: "UserPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
