using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopData.Migrations
{
    /// <inheritdoc />
    public partial class fixMissp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApUserLogins",
                table: "ApUserLogins");

            migrationBuilder.RenameTable(
                name: "ApUserLogins",
                newName: "AppUserLogins");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 20, 16, 19, 44, 784, DateTimeKind.Local).AddTicks(729),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 20, 16, 16, 48, 995, DateTimeKind.Local).AddTicks(219));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserLogins",
                table: "AppUserLogins",
                column: "UserId");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "0b4b958a-9b69-4a75-88bc-dedf19243ba8");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "33bdc2a4-91e0-44d2-80d8-3f23bd4b6d08", "AQAAAAEAACcQAAAAEFrX2wpFKKY0q8g+zF4z9wnKT7q6fRTUcxVingkAb1fqXK05DK22Cx0hNbOHmmw0+A==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 20, 16, 19, 44, 786, DateTimeKind.Local).AddTicks(9198));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserLogins",
                table: "AppUserLogins");

            migrationBuilder.RenameTable(
                name: "AppUserLogins",
                newName: "ApUserLogins");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 20, 16, 16, 48, 995, DateTimeKind.Local).AddTicks(219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 20, 16, 19, 44, 784, DateTimeKind.Local).AddTicks(729));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApUserLogins",
                table: "ApUserLogins",
                column: "UserId");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b4e15811-5deb-4273-a444-76052db5f2f0");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a53a437a-1938-4238-9dd1-e44d85820eab", "AQAAAAEAACcQAAAAEHeBOccqyC0PZrkqAZL2g8kKiVSeW6h5OP5kzWc693Soawf/7kHowmPwOu3fFSylKQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 20, 16, 16, 48, 997, DateTimeKind.Local).AddTicks(7588));
        }
    }
}
