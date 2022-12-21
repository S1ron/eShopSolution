using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopData.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFileLengthType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 21, 20, 22, 49, 597, DateTimeKind.Local).AddTicks(6245),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 20, 21, 20, 52, 37, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a22fbc14-920e-4acf-abd2-fbedc787533f");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "03a0c889-661c-4529-ac38-fe8a61237591", "AQAAAAEAACcQAAAAEFi9XyShl+kjOiYi978jUd18/iSzFaTbb6gxlj5JTDeibncgrKg1Xmaew51XQo6RAg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 21, 20, 22, 49, 600, DateTimeKind.Local).AddTicks(7569));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 20, 21, 20, 52, 37, DateTimeKind.Local).AddTicks(9170),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 21, 20, 22, 49, 597, DateTimeKind.Local).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "d6f4d58b-c699-42c4-afc4-be69cebb6793");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "420c4f32-ed5e-4711-bf79-18353dcb74ee", "AQAAAAEAACcQAAAAEL6602dR7gDidYq4Unq3BYsqKJ4OvpBW6AT4Coyjqoadru/z/ArZ6g3cjyoCzONAxQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 20, 21, 20, 52, 41, DateTimeKind.Local).AddTicks(3214));
        }
    }
}
