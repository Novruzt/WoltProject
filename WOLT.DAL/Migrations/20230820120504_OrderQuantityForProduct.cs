using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WOLT.DAL.Migrations
{
    /// <inheritdoc />
    public partial class OrderQuantityForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderProductQuantities",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductQuantities", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderProductQuantities_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProductQuantities_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductQuantities_OrderId",
                table: "OrderProductQuantities",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProductQuantities");

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
        }
    }
}
