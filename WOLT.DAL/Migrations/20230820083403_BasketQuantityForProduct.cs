using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WOLT.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BasketQuantityForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_PromoCodes_PromoCodeId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_PromoCodeId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "PromoCodeId",
                table: "Baskets");

            migrationBuilder.CreateTable(
                name: "BasketProductQuantities",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketProductQuantities", x => new { x.ProductId, x.BasketId });
                    table.ForeignKey(
                        name: "FK_BasketProductQuantities_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketProductQuantities_Products_ProductId",
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
                name: "IX_BasketProductQuantities_BasketId",
                table: "BasketProductQuantities",
                column: "BasketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketProductQuantities");

            migrationBuilder.AddColumn<int>(
                name: "PromoCodeId",
                table: "Baskets",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_PromoCodeId",
                table: "Baskets",
                column: "PromoCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_PromoCodes_PromoCodeId",
                table: "Baskets",
                column: "PromoCodeId",
                principalTable: "PromoCodes",
                principalColumn: "Id");
        }
    }
}
