using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vpsAPI.Migrations
{
    /// <inheritdoc />
    public partial class rel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 16, 54, 53, 771, DateTimeKind.Local).AddTicks(3161));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 16, 54, 53, 771, DateTimeKind.Local).AddTicks(3179));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 16, 54, 53, 771, DateTimeKind.Local).AddTicks(3181));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 16, 43, 1, 53, DateTimeKind.Local).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 16, 43, 1, 53, DateTimeKind.Local).AddTicks(8514));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 16, 43, 1, 53, DateTimeKind.Local).AddTicks(8516));
        }
    }
}
