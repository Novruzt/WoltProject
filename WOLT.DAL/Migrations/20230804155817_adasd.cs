using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WOLT.DAL.Migrations
{
    /// <inheritdoc />
    public partial class adasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkHours_Branches_BranchId",
                table: "WorkHours");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropColumn(
                name: "BracnhId",
                table: "WorkHours");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "WorkHours",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkHours_BranchId",
                table: "WorkHours",
                newName: "IX_WorkHours_RestaurantId");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "UserComments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 4, 19, 58, 17, 469, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationTime", "DeleteTime", "Email", "IsDeleted", "Name", "Password", "PasswordResetToken", "Phone", "ProfilePicture", "ResetExpirationDate", "Surname", "UpdateTime", "VerificationToken", "VerifiedAt" },
                values: new object[] { 1, new DateTime(2023, 8, 4, 19, 58, 17, 469, DateTimeKind.Local).AddTicks(1636), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "asdad@gmaik.com", false, "Novruz", "salam", null, "12313", null, null, "Tarverdiyev", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 8, 4, 19, 58, 17, 469, DateTimeKind.Local).AddTicks(1638) });

            migrationBuilder.InsertData(
                table: "UserComments",
                columns: new[] { "Id", "CommentDate", "CreationTime", "DeleteTime", "Details", "IsDeleted", "RestaurantId", "UpdateTime", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 4, 19, 58, 17, 469, DateTimeKind.Local).AddTicks(1618), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sadad", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHours_Restaurants_RestaurantId",
                table: "WorkHours",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkHours_Restaurants_RestaurantId",
                table: "WorkHours");

            migrationBuilder.DeleteData(
                table: "UserComments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "WorkHours",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkHours_RestaurantId",
                table: "WorkHours",
                newName: "IX_WorkHours_BranchId");

            migrationBuilder.AddColumn<int>(
                name: "BracnhId",
                table: "WorkHours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "UserComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkHourdsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "CreationTime", "DeleteTime", "IsDeleted", "Phone", "RestaurantId", "UpdateTime", "WorkHourdsId" },
                values: new object[,]
                {
                    { 1, "Goyercin", new DateTime(2023, 8, 4, 19, 36, 37, 432, DateTimeKind.Local).AddTicks(3390), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "123 123 123", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, "Qayali", new DateTime(2023, 8, 4, 19, 36, 37, 432, DateTimeKind.Local).AddTicks(3393), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "123 123 11", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 8, 4, 19, 36, 37, 432, DateTimeKind.Local).AddTicks(3189));

            migrationBuilder.CreateIndex(
                name: "IX_Branches_RestaurantId",
                table: "Branches",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHours_Branches_BranchId",
                table: "WorkHours",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
