using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTotalAttendanceComputedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"UPDATE ""Attendances""
            SET ""TotalAttendance"" = 
                CASE
                    WHEN ""AttendanceType"" = 0 THEN 1.0 
                    WHEN ""AttendanceType"" = 1 THEN 0.5 
                    ELSE 0.0
                END;"
            );

            migrationBuilder.Sql(
                @"ALTER TABLE ""Attendances""
            ALTER COLUMN ""TotalAttendance"" DROP DEFAULT;"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Dönüş işlemi için bir kod eklenmelidir, geri alma işlemini tanımlayabilirsiniz.
        }
    }
}
