using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seeding_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd575ebe-a1a2-4c1c-84df-ff695766f819"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Terms",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Terms",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Attendances",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("0ac4b45d-251c-451c-abc8-b84807372fb9"), "636f7f05-eb3c-4647-9fb1-fbd2632317ef", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "Branch", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "Grade", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StudentNumber", "Surname", "TermId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("53d2f09d-2916-4f30-a741-217376c8ef90"), 0, new DateTime(2023, 12, 11, 23, 21, 20, 124, DateTimeKind.Utc).AddTicks(2604), "B", "64732a88-79e2-447c-8cd8-c0d099e96d29", "example@example.com", true, null, 12, false, new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)), "Sabit", "EXAMPLE@EXAMPLE.COM", "EXAMPLE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAUAUA5i0dbhJmbRd/s2ewvfJMDik+8gjoJDYfQZFQDMkTKpRKZJ39c3SEqzRgg6FA==", "+905423849022", true, "0a503112-3372-464d-9554-e397d3a42051", 653, "Ünsür", 1, false, "example@example.com" });

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 12, 11, 23, 21, 20, 170, DateTimeKind.Utc).AddTicks(2741));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0ac4b45d-251c-451c-abc8-b84807372fb9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("53d2f09d-2916-4f30-a741-217376c8ef90"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Terms",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Terms",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Attendances",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "Branch", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "Grade", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StudentNumber", "Surname", "TermId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("fd575ebe-a1a2-4c1c-84df-ff695766f819"), 0, new DateTime(2023, 12, 11, 13, 14, 43, 774, DateTimeKind.Utc).AddTicks(1851), "B", "1b8ed708-100f-42d0-b26f-27a4e42fb6bb", "example@example.com", true, null, 12, false, new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)), "Sabit", "EXAMPLE@EXAMPLE.COM", "EXAMPLE@EXAMPLE.COM", "AQAAAAIAAYagAAAAELOhzI3XhxBkgrN9PioKAtHgVCf3PGufmVy6ODx0wNEn9jWbTOX3HR0ZJEfOdvUkmw==", "+905423849022", true, "03bc40d7-ad72-41ae-a02b-ce16c5e0ac58", 653, "Ünsür", 1, false, "example@example.com" });

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 12, 11, 13, 14, 43, 824, DateTimeKind.Utc).AddTicks(8290));
        }
    }
}
