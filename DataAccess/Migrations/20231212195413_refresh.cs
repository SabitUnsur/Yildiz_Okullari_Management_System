using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class refresh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FatherFullName = table.Column<string>(type: "text", nullable: true),
                    MotherFullName = table.Column<string>(type: "text", nullable: true),
                    FatherPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    MotherPhoneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    StudentNumber = table.Column<int>(type: "integer", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: true),
                    TermId = table.Column<Guid>(type: "uuid", nullable: true),
                    TermId1 = table.Column<int>(type: "integer", nullable: true),
                    Grade = table.Column<int>(type: "integer", nullable: true),
                    Branch = table.Column<string>(type: "text", nullable: true),
                    FamilyInfoId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_FamilyInfos_FamilyInfoId",
                        column: x => x.FamilyInfoId,
                        principalTable: "FamilyInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Terms_TermId1",
                        column: x => x.TermId1,
                        principalTable: "Terms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AttendanceLectureHour = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttendanceType = table.Column<int>(type: "integer", nullable: true),
                    ExcuseType = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("6fdd35d5-a48a-42c5-ace3-13acbbcb040d"), "ef36e4c3-a881-4e82-a872-69a767824721", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "Branch", "ConcurrencyStamp", "Email", "EmailConfirmed", "FamilyInfoId", "Gender", "Grade", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StudentNumber", "Surname", "TermId", "TermId1", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1ced32ba-a37f-4d43-8878-7e90057febf1"), 0, new DateTime(2023, 12, 12, 19, 54, 13, 385, DateTimeKind.Utc).AddTicks(5020), null, "7d374fb5-6136-4b3b-814c-b4dd3194dce7", "admin@admin.com", true, null, null, null, false, new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)), "Admin", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEAs1C0EX0JqYUu2GLgMBARpQPE3HjX/QykG9bCeUp5PHzmT8BNeNkTJ2BeqsS7+XJg==", null, false, "3593fe6b-a60b-4f8f-ae6c-f0360f38f1d7", null, null, null, null, false, "admin@admin.com" },
                    { new Guid("59ac6442-3a6e-412c-83fa-97fdd6ccbbf6"), 0, new DateTime(2023, 12, 12, 19, 54, 13, 428, DateTimeKind.Utc).AddTicks(8394), "A", "0fed07b2-0b8a-40bb-b55d-7af03de5c3d2", "sabit@sabit.com", true, null, null, 11, false, new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)), "Egemen", "SABIT@SABIT.COM", "SABIT@SABIT.COM", "AQAAAAIAAYagAAAAEE0fbAsBw+7L+pwZV1FZQLQ/jLS0JFmzy27dIMZSuBSHflffSPnR6Jy3l+CBWyeKiA==", "+905423849022", true, "804cba94-923d-4965-8f90-16513f6bb04d", 1532, "Ünsür", new Guid("9620b3fa-d8c5-4043-8f5a-33e997e47a1b"), null, false, "sabit@sabit.com" },
                    { new Guid("a551377f-85a1-4de9-a697-11e1114c307e"), 0, new DateTime(2023, 12, 12, 19, 54, 13, 344, DateTimeKind.Utc).AddTicks(5134), "B", "e8a5e257-a367-4b3e-95bb-2aa13b78dc4b", "example@example.com", true, null, null, 12, false, new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)), "Sabit", "EXAMPLE@EXAMPLE.COM", "EXAMPLE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEBAg+SyzyRZddVImo+tDs8fnb/3lqRJm3UzbUpSL8N/9FcLaizxYoe0b21T/o6iqaA==", "+905423849022", true, "ba72f5df-cd7c-490c-a135-d4966df17745", 653, "Ünsür", new Guid("b50af227-a03d-4366-8a6e-a7c86c080adb"), null, false, "example@example.com" },
                    { new Guid("d74315eb-95aa-4813-bf51-f73998e966d4"), 0, new DateTime(2023, 12, 12, 19, 54, 13, 473, DateTimeKind.Utc).AddTicks(5085), "C", "49da3796-ce72-4b26-ac6c-785c9f2fae4c", "mikdat@simsek.com", true, null, null, 12, false, new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)), "Mikdat Can", "MIKDAT@MIKDAT.COM", "MIKDAT@MIKDAT.COM", "AQAAAAIAAYagAAAAEITCqCocIll8cT3GJkkMEJU1zQgQEpMT1fJduRqQAkCwovNY8EfkJfQ7PY/ASGg4Ew==", "+905397159877", true, "362b6f71-43b5-4bce-9a1e-08316d9c8db3", 16, "Şimşek", new Guid("26b98668-212a-4cbc-9239-b083ec36b33a"), null, false, "mikdat@simsek.com" }
                });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "Id", "EndDate", "StartDate" },
                values: new object[] { 1, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(2023, 12, 12, 19, 54, 13, 517, DateTimeKind.Utc).AddTicks(9009) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FamilyInfoId",
                table: "AspNetUsers",
                column: "FamilyInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TermId1",
                table: "AspNetUsers",
                column: "TermId1");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_PersonId",
                table: "Attendances",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FamilyInfos");

            migrationBuilder.DropTable(
                name: "Terms");
        }
    }
}
