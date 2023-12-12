using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class db_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dde365a5-0054-463c-a5eb-d56d754adf10"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("36262f2c-da5d-46a3-bb0f-8cd67879b3a8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4e45e99-c32a-4b84-b194-5495bf5582cc"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5bf58dc-f4b3-4346-a3bf-2d4f4f83ccb6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e81ecf36-17d9-4e3f-ad1b-00e15f67c40a"));

            migrationBuilder.AddColumn<int>(
                name: "AttendanceType",
                table: "Attendances",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("0f1051eb-3f9d-4ab2-a914-a1e013400018"), "23028d27-70dd-4f6a-8ed1-44ffccc29af4", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "Branch", "ConcurrencyStamp", "Email", "EmailConfirmed", "FamilyInfoId", "Gender", "Grade", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StudentNumber", "Surname", "TermId", "TermId1", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("460041a9-91f7-4215-b9eb-c08a5b3d1ae1"), 0, new DateTime(2023, 12, 12, 11, 53, 4, 369, DateTimeKind.Utc).AddTicks(645), "A", "8db8674b-8951-4fc8-8c1f-2d5899c20f86", "sabit@sabit.com", true, null, null, 11, false, new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)), "Egemen", "SABIT@SABIT.COM", "SABIT@SABIT.COM", "AQAAAAIAAYagAAAAEAiyVtXaAwVz2qLpoDtzH28kHzTbWuUD8lUauK8ZQDwNz/HHcWfZoyl/LHI5ZK5PKQ==", "+905423849022", true, "3bee0ace-465e-45b2-9854-bf64f9406229", 1532, "Ünsür", new Guid("3f572701-8f6a-4e91-b165-721b6fbdd2c5"), null, false, "sabit@sabit.com" },
                    { new Guid("5550af7e-707c-468b-864e-767f397eaafb"), 0, new DateTime(2023, 12, 12, 11, 53, 4, 410, DateTimeKind.Utc).AddTicks(9910), "C", "5a6ad5b7-d4b2-43a5-9391-73c7bc03af3a", "mikdat@simsek.com", true, null, null, 12, false, new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)), "Mikdat Can", "MIKDAT@MIKDAT.COM", "MIKDAT@MIKDAT.COM", "AQAAAAIAAYagAAAAENXRKC96hW61Spti44b16GZj8bXCpgTNJulCwix3BYdlT0uRRj+Eqfw55u49om/vjg==", "+905397159877", true, "3ddc8287-7696-4024-96e2-416cd478ec53", 16, "Şimşek", new Guid("c9bafc2c-0dc1-4203-8773-f77a1abee7b2"), null, false, "mikdat@simsek.com" },
                    { new Guid("6b29e2da-46f1-49f1-be5c-52df74c8c48a"), 0, new DateTime(2023, 12, 12, 11, 53, 4, 326, DateTimeKind.Utc).AddTicks(7731), null, "618673e7-9f7f-4494-8623-9117a35b41e0", "admin@admin.com", true, null, null, null, false, new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)), "Admin", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEHKvb9uCFCpk2e0wIIcthIcn6bdi4iMpEc2bzlSyi6tigao3Uep5I6GBF/1BLEHVFA==", null, false, "af6b988e-78f0-4297-bfd0-8a5ac5ade0b3", null, null, null, null, false, "admin@admin.com" },
                    { new Guid("e7e53f69-5646-41e7-bc12-8cbb06a67201"), 0, new DateTime(2023, 12, 12, 11, 53, 4, 282, DateTimeKind.Utc).AddTicks(834), "B", "93facf65-219b-4092-9977-8d443c6b0c68", "example@example.com", true, null, null, 12, false, new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)), "Sabit", "EXAMPLE@EXAMPLE.COM", "EXAMPLE@EXAMPLE.COM", "AQAAAAIAAYagAAAAECFxHxCKixPMBsaemd7+r9abaMSkCd98+uouRcauCfooonYahzo8wvCSckZjM5mRwA==", "+905423849022", true, "0d327fab-15b3-48c8-adc1-52ebf041b16e", 653, "Ünsür", new Guid("a935905d-87e3-4fc0-a27a-f671b763af8e"), null, false, "example@example.com" }
                });

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 12, 12, 11, 53, 4, 453, DateTimeKind.Utc).AddTicks(8972));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0f1051eb-3f9d-4ab2-a914-a1e013400018"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("460041a9-91f7-4215-b9eb-c08a5b3d1ae1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5550af7e-707c-468b-864e-767f397eaafb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6b29e2da-46f1-49f1-be5c-52df74c8c48a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7e53f69-5646-41e7-bc12-8cbb06a67201"));

            migrationBuilder.DropColumn(
                name: "AttendanceType",
                table: "Attendances");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("dde365a5-0054-463c-a5eb-d56d754adf10"), "60e54890-20ed-4f39-96bf-4f190c1a551f", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "Branch", "ConcurrencyStamp", "Email", "EmailConfirmed", "FamilyInfoId", "Gender", "Grade", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StudentNumber", "Surname", "TermId", "TermId1", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("36262f2c-da5d-46a3-bb0f-8cd67879b3a8"), 0, new DateTime(2023, 12, 12, 7, 23, 10, 357, DateTimeKind.Utc).AddTicks(7328), "C", "9dd51211-24d5-4340-beb0-375949d6743b", "mikdat@simsek.com", true, null, null, 12, false, new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)), "Mikdat Can", "MIKDAT@MIKDAT.COM", "MIKDAT@MIKDAT.COM", "AQAAAAIAAYagAAAAELF3R7H/HdYr7a5gpITXWMooKEewSr0EW3VJiJNPsjGNOqv3B8+ncnMzyBxzRctnZg==", "+905397159877", true, "a0ae6571-ae33-4a5a-9a78-8f5ee5e18e28", 16, "Şimşek", new Guid("b2d796df-1460-4a3a-86bd-13e9db3c3f8b"), null, false, "mikdat@simsek.com" },
                    { new Guid("b4e45e99-c32a-4b84-b194-5495bf5582cc"), 0, new DateTime(2023, 12, 12, 7, 23, 10, 224, DateTimeKind.Utc).AddTicks(115), "B", "8b80e4b1-71e3-413d-9ff1-9a759c699f01", "example@example.com", true, null, null, 12, false, new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)), "Sabit", "EXAMPLE@EXAMPLE.COM", "EXAMPLE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEJbTPOtXd5Fn4wYRUhryzTdkKTE+Rwjys7BUsqpFBMHZeRyGZ8vINyjWzT/BJTq1Xg==", "+905423849022", true, "4569dfee-dbc4-45d5-9929-1d7880ba068b", 653, "Ünsür", new Guid("3001ec3f-f507-459e-9c90-2861910a76b6"), null, false, "example@example.com" },
                    { new Guid("e5bf58dc-f4b3-4346-a3bf-2d4f4f83ccb6"), 0, new DateTime(2023, 12, 12, 7, 23, 10, 268, DateTimeKind.Utc).AddTicks(6617), null, "6d9cbd56-ded1-40e9-8462-a79a6c276dcb", "admin@admin.com", true, null, null, null, false, new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)), "Admin", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEI6DrJ0J7TIo+6FCKxADnAA21y6ECihqI7rrIVDnwTL60oSkTDCRHKxuGmXv/hQRtA==", null, false, "cd8cba7d-301d-4359-a70d-f7f420901443", null, null, null, null, false, "admin@admin.com" },
                    { new Guid("e81ecf36-17d9-4e3f-ad1b-00e15f67c40a"), 0, new DateTime(2023, 12, 12, 7, 23, 10, 312, DateTimeKind.Utc).AddTicks(8861), "A", "37abb1a9-3c32-4974-bda1-bc1b0fe5db34", "sabit@sabit.com", true, null, null, 11, false, new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)), "Egemen", "SABIT@SABIT.COM", "SABIT@SABIT.COM", "AQAAAAIAAYagAAAAEMBduTlN+z2AQ9QhM6ShhHmDhxVYXfkttPTHXa7ylCA3u3SGEI6RHRVcb8gcAixUTQ==", "+905423849022", true, "7b3cee32-a831-4e49-b144-2d186dd89b0a", 1532, "Ünsür", new Guid("0207b83f-241c-4677-92cb-2bc7cd72e3e2"), null, false, "sabit@sabit.com" }
                });

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 12, 12, 7, 23, 10, 402, DateTimeKind.Utc).AddTicks(6844));
        }
    }
}
