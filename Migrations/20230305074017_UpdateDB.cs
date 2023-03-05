using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment3.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "Posts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "Posts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PublishStatus",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PostCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "AuthorID", "Address", "Email", "FullName", "Password" },
                values: new object[] { 1, "HCM", "admin@gmail.com", "admin", "123456" });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Education", "Education..." },
                    { 2, "Healthcare", "Healthcare..." },
                    { 3, "Science", "Science..." },
                    { 4, "Technology", "Technology..." }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "AuthorID", "CategoryID", "Content", "created_date", "PublishStatus", "Title", "updated_date" },
                values: new object[,]
                {
                    { 4, 1, 1, null, new DateTime(2023, 3, 5, 14, 40, 16, 952, DateTimeKind.Local).AddTicks(1351), 0, "The Story Of Studying Abroad", new DateTime(2023, 3, 5, 14, 40, 16, 952, DateTimeKind.Local).AddTicks(1353) },
                    { 2, 1, 2, null, new DateTime(2023, 3, 5, 14, 40, 16, 952, DateTimeKind.Local).AddTicks(1333), 0, "50 Good Dishes For Breakfast", new DateTime(2023, 3, 5, 14, 40, 16, 952, DateTimeKind.Local).AddTicks(1342) },
                    { 3, 1, 3, null, new DateTime(2023, 3, 5, 14, 40, 16, 952, DateTimeKind.Local).AddTicks(1347), 0, "NASA And The Great Scientific Work", new DateTime(2023, 3, 5, 14, 40, 16, 952, DateTimeKind.Local).AddTicks(1348) },
                    { 1, 1, 4, null, new DateTime(2023, 3, 5, 14, 40, 16, 950, DateTimeKind.Local).AddTicks(8510), 0, "OOP Concepts in C#", new DateTime(2023, 3, 5, 14, 40, 16, 951, DateTimeKind.Local).AddTicks(8927) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "AuthorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "CategoryID",
                keyValue: 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PublishStatus",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PostCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
